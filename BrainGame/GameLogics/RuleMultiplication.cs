using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace GameLogics
{
    public class RuleMultiplication : BaseRule
    {
        public RuleMultiplication(ref FieldViewModel fieldModel) : base(ref fieldModel)
        {
            funcAggregate = FuncAggregate;
        }
        private int FuncAggregate(int sum, SlotViewModel slot)
        {
            if (sum == 0)
                sum = 1;
            sum *= slot.Value;
            return sum;
        }

        override protected int GetRandomAnswer()
        {
            int result = 1;
            var rand = new Random();
            var count = fieldModel.VisibleSlot.Count;
            var rand1 = rand.Next(0, count);
            var rand2 = rand.Next(0, count);

            if (count <= 2)
            {
                for (var i = 0; i < count; i++)
                    result *= fieldModel.VisibleSlot[i].Value;
            }
            else
            {
                while (rand1 == rand2)
                    rand2 = rand.Next(0, count);
                result = fieldModel.VisibleSlot[rand1].Value * fieldModel.VisibleSlot[rand2].Value;
            }

            return result;
        }
    }
}
