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
        public RuleMultiplication(ref FieldSlotViewModel fieldModel,String gameMode) : base(ref fieldModel, gameMode)
        {
            funcAggregate = FuncAggregate;
            funcAggregateAnswer = FuncAggregateAnswer;
            Description = "1 *..*..=";
        }

        private int FuncAggregate(int sum, SlotViewModel slot)
        {
            if (sum == 0)
                sum = 1;
            sum *= slot.Value;
            return sum;
        }

        private int FuncAggregateAnswer(int sum, int value)
        {
            if (sum == 0)
                sum = 1;
            sum *= value;
            return sum;
        }

    }
}
