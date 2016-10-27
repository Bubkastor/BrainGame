using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data;
using GameLogics;
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
            get { return This.IsOpen;  }
            set { SetProperty(This.IsOpen, value, () => This.IsOpen = value); }
        }

        private int index;
        public int Index
        {
            get { return this.index; }
            set { SetProperty(this.index, value, () => this.index = value); }
        }
        public OptionGame OptionGame {
            get
            {
                var option = new OptionGame();
                option.BeginRange = This.BeginRange;
                option.EndRange = This.EndRange;
                option.Count = This.Count;
                option.RuleMode = This.RuleMode;
                return option;
            }
        }
            
    }
}
