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
            get { return This.value; }
            set { SetProperty(This.value, value, () => This.value = value); }
        }
        public bool Visible
        {
            get { return This.visible; }
            set { SetProperty(This.visible, value, () => This.visible = value); }
        }

    }
}
