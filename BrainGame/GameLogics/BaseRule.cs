﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using System.Diagnostics;
namespace GameLogics
{
    public class BaseRule: NotificationBase
    {
        protected List<SlotViewModel> usedSlot;
        protected FieldViewModel fieldModel;
        protected int answer;
        protected Func<int, SlotViewModel, int> funcAggregate;

        public delegate void SampleEventHandler(object sender, EventArgs e);
        
        
        public event EventHandler eventHandler;


        public BaseRule(ref FieldViewModel fieldModel)
        {
            this.fieldModel = fieldModel;
            usedSlot = new List<SlotViewModel>();            
        }

        public int Answer
        {
            get { return this.answer; }
            set { this.SetProperty(ref this.answer, value); }
        }

        public void RunGame()
        {
            Answer = GetRandomAnswer();
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
                    Answer = GetRandomAnswer();
                }
                else
                {
                    eventHandler?.Invoke(this,null);
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
