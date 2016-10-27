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
    public class OptionGame
    {
        public int BeginRange { get; set; } = 1;
        public int EndRange { get; set; } = 10;
        public int Count { get; set; } = 49;
        public string RuleMode { get; set; } = "RuleAddition";
    }
    public class EndEventArgs : EventArgs
    {
        public EndEventArgs(TimeSpan time, bool isWin, String gameMode) {
            Time = time;
            IsWin = isWin;
            GameMode = gameMode;
        }
        public TimeSpan Time { get; private set; } 
        public bool IsWin { get; private set; } 
        public String GameMode { get; set; }
    }

    public class BaseRule : NotificationBase
    {
        public String Description;
        protected List<SlotViewModel> usedSlot;
        protected FieldSlotViewModel fieldModel;
        protected int answer;
        protected int countNumber = 2;        
        protected Func<int, SlotViewModel, int> funcAggregate;
        protected Func<int, int, int> funcAggregateAnswer;

        private TimeSpan delay;
        private ThreadPoolTimer DelayTimer;
        public bool isPause { get; set; } = false;

        private TimeSpan tick = TimeSpan.FromSeconds(1);
        private TimeSpan addTick = TimeSpan.FromSeconds(5);

        public event EventHandler onEndGame;
        public String GameMode;

        public delegate void OnUpdateInterface(TimeSpan time);
        private OnUpdateInterface Update;

        private void OnEndGame(TimeSpan time, bool isWin)
        {
            onEndGame?.Invoke(this, new EndEventArgs(time, isWin, GameMode));
        }

        public BaseRule(ref FieldSlotViewModel fieldModel,String gameMode)
        {
            this.GameMode = gameMode;
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
                        if (!isPause)
                        {
                            Update?.Invoke(delay);
                            delay = delay.Subtract(tick);
                        }                        
                    }

                }, tick);
        }

        private void CheckedRule()
        {
            var summ = usedSlot.Aggregate(0, funcAggregate);
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

        private List<int> RandomNumber(int count)
        {
            List<int> result = new List<int>();
            var rand = new Random();
            var countSlot = fieldModel.VisibleSlot.Count;
            while (result.Count != count)
            {
                var randNumber = rand.Next(1, countSlot);
                if (!result.Contains(randNumber))
                    result.Add(randNumber);
            }
            return result;
        }

        private int GetRandomAnswer()
        {
            int result = 0;

            var count = fieldModel.VisibleSlot.Count;
            List<int> usedNumber = new List<int>();

            if (count <= countNumber)
            {
                for (var i = 0; i < count; i++)
                    usedNumber.Add(fieldModel.VisibleSlot[i].Value);
            }
            else
            {
                var randNumber = RandomNumber(countNumber);
                foreach (var item in randNumber)
                    usedNumber.Add(fieldModel.VisibleSlot[item].Value);
            }
            result = usedNumber.Aggregate(0, funcAggregateAnswer);
            return result;
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
