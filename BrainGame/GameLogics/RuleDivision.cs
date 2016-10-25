using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace GameLogics
{
    public class RuleDivision : BaseRule
    {
        public RuleDivision(ref FieldSlotViewModel fieldModel, String gameMode) : base(ref fieldModel, gameMode)
        {
        }
    }
}
