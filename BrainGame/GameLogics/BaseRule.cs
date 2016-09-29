using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using System.Diagnostics;
using Windows.System.Threading;

namespace GameLogics
{
    public class EndEventArgs: EventArgs
    {
        public EndEventArgs(TimeSpan time, bool isWin) { Time = time; IsWin = isWin; }
        public TimeSpan Time { get; private set; } // readonly
        public bool IsWin { get; private set; } // readonly
    }

    public class BaseRule : NotificationBase
    {
        protected List<SlotViewModel> usedSlot;
        protected FieldViewModel fieldModel;
        protected int answer;
        protected Func<int, SlotViewModel, int> funcAggregate;

        protected TimeSpan delay;
        protected ThreadPoolTimer DelayTimer;

        private TimeSpan tick = TimeSpan.FromSeconds(1);
        private TimeSpan addTick = TimeSpan.FromSeconds(5);

        public event EventHandler onEndGame;

        public delegate void OnUpdateInterface(TimeSpan time);
        public OnUpdateInterface Update;

        protected virtual void OnEndGame(TimeSpan time, bool isWin)
        {
            onEndGame?.Invoke(this, new EndEventArgs(time, isWin));
        }

        public BaseRule(ref FieldViewModel fieldModel)
        {
            this.fieldModel = fieldModel;
            usedSlot = new List<SlotViewModel>();                     
        }

        public void SetOnUpdateInterface(OnUpdateInterface onUpdate)
        {
            Update = onUpdate;
        }



        public int Answer
        {
            get { return this.answer; }
            set { this.SetProperty(ref this.answer, value); }
        }

        public void RunGame()
        {
            Answer = GetRandomAnswer();
            delay = TimeSpan.FromSeconds(15);
            DelayTimer = ThreadPoolTimer.CreatePeriodicTimer(
                (source) =>
                {

                    if (delay < tick)
                    {
                        DelayTimer.Cancel();
                        OnEndGame(delay, false);
                        
                    }
                    else
                    {
                        Update?.Invoke(delay);
                        delay = delay.Subtract(tick);                        
                    }

                }, tick);
        }

        void CheckedRule()
        {
            var summ = usedSlot.Aggregate(0, funcAggregate);
            Debug.WriteLine("Answer: " + summ);
            if (summ == Answer)
            {
                Answer = GetRandomAnswer();
                DisableSlot();
                if (fieldModel.VisibleSlot.Count != 0)
                {
                    delay = delay.Add(addTick);
                    Answer = GetRandomAnswer();
                }
                else
                {
                    OnEndGame(delay, true);
                    DelayTimer.Cancel();
                    Answer = 0;

                }
            }
        }

        protected virtual int GetRandomAnswer()
        {
            throw new NotImplementedException();
        }

        public void DisableSlot()
        {
            foreach (var item in usedSlot)
            {
                item.Visible = !item.Visible;
            }
            usedSlot.RemoveRange(0, usedSlot.Count);
        }

        public void AddSlot(ref SlotViewModel slot)
        {
            if (!usedSlot.Contains(slot))
            {
                usedSlot.Add(slot);
                slot.IsSelected = !slot.IsSelected;
                CheckedRule();
            }
        }

        public void DeleteSlot(ref SlotViewModel slot)
        {
            if (usedSlot.Contains(slot))
            {
                slot.IsSelected = !slot.IsSelected;
                usedSlot.Remove(slot);
                CheckedRule();
            }

        }
    }
}
