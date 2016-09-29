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
        private int FuncAggregateAnswer(int sum, int value)
        {
            sum += value;
            return sum;
        }

        public RuleAddition(ref FieldViewModel fieldModel) : base(ref fieldModel)
        {
            funcAggregate = FuncAggregate;
            funcAggregateAnswer = FuncAggregateAnswer;
        }

    }
}
