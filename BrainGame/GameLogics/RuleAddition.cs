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
    public class RuleAddition:  BaseRule 
    {

        private int FuncAggregate(int sum, SlotViewModel slot)
        {
            sum += slot.Value;
            return sum;
        }

        public RuleAddition(ref FieldViewModel fieldModel) : base(ref fieldModel)
        {
            funcAggregate = FuncAggregate;
        }

        override protected int GetRandomAnswer()
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
                for (var i = 0; i < count; i++)
                    result += fieldModel.VisibleSlot[i].Value;
            }
            else
            {
                result = fieldModel.VisibleSlot[rand1].Value + fieldModel.VisibleSlot[rand2].Value;
            }

            return result;
        }
    }
}
