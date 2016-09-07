using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ViewModels
{
    public class SlotViewModel: NotificationBase<Slot>
    {
        public SlotViewModel(Slot slot = null) : base(slot) { }
        public int Value
        {
            get { return This.Value; }
            set { SetProperty(This.Value, value, () => This.Value = value); }
        }
        public bool Visible
        {
            get { return This.Visible; }
            set { SetProperty(This.Visible, value, () => This.Visible = value); }
        }

    }
}
