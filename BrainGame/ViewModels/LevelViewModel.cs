using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data;
namespace ViewModels
{
    public class LevelViewModel: NotificationBase<Level>
    {
        public LevelViewModel(Level level = null) : base(level) { }

        public short Raiting
        {
            get { return This.Raiting; }
            set { SetProperty(This.Raiting, value, () => This.Raiting = value); }
        }

        public bool IsOpen
        {
            get { return This.IsOpen; }
            set { SetProperty(This.IsOpen, value, () => This.IsOpen = value); }
        }

        public Difficult Diff
        {
            get { return This.Diff; }
            set { SetProperty(This.Diff, value, () => This.Diff = Diff); }
        }
    }
}
