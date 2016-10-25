using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace GameLogics
{
    public class RuleSubtraction : BaseRule
    {
        public RuleSubtraction(ref FieldSlotViewModel fieldModel, String gameMode) : base(ref fieldModel, gameMode)
        {
        }
    }
}
