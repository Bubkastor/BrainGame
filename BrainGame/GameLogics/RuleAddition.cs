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
    public class RuleAddition
    {
        private List<SlotViewModel> usedSlot;
        private FieldViewModel fieldModel;
        private int Answer;

        public RuleAddition(ref FieldViewModel fieldModel)
        {
            this.fieldModel = fieldModel;
            usedSlot = new List<SlotViewModel>();
        }

        public void RunGame()
        {
            
        }

        void CheckedRule()
        {
            var summ = usedSlot.Aggregate(0, (sum, value) => {
                sum += value.Value;
                return sum;
            });
            Debug.WriteLine("Sum == " + summ );
            if(summ == 10)
            {
                DisableSlot();
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
