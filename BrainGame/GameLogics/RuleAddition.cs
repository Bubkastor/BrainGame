using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Diagnostics;
using ViewModels;

namespace GameLogics
{
    public class RuleAddition: NotificationBase
    {
        private List<SlotViewModel> usedSlot;
        private FieldViewModel fieldModel;
        private int answer;
        public int Answer
        {
            get { return this.answer; }
            set { this.SetProperty(ref this.answer, value); }
        }

        public RuleAddition(ref FieldViewModel fieldModel)
        {
            this.fieldModel = fieldModel;
            usedSlot = new List<SlotViewModel>();
        }

        public void RunGame()
        {
            Answer = GetRandomAnswer();
        }

        private int GetRandomAnswer()
        {
            int result = 0;
            var rand = new Random();
            var count = fieldModel.VisibleSlot.Count;
            var rand1 = rand.Next(0, count);
            var rand2 = rand.Next(0, count);        
            while (rand1 == rand2)
                rand2 = rand.Next(0, count);
            if (count <= 2)
            {
                for(var i = 0; i < count;i++)
                result += fieldModel.VisibleSlot[i].Value;
            }
            else
            {
                result = fieldModel.VisibleSlot[rand1].Value + fieldModel.VisibleSlot[rand2].Value;        
            }

            return result;
        }

        void CheckedRule()
        {
            var summ = usedSlot.Aggregate(0, (sum, value) => {
                sum += value.Value;
                return sum;
            });
            Debug.WriteLine("Sum == " + summ );
            if(summ == Answer)
            {
                Answer = GetRandomAnswer();
                DisableSlot();
                if (fieldModel.VisibleSlot.Count != 0)
                {
                    Answer = GetRandomAnswer();
                }
                else
                {
                    Answer = 999;
                }
            }
        }

        public void DisableSlot()
        {
            foreach (var item in usedSlot)
            {
                item.Visible = !item.Visible;
            }
            //usedSlot.All(item => item.Visible = false);
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
