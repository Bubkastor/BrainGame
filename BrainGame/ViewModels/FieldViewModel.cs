using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Models;

namespace ViewModels
{
    public class FieldViewModel : NotificationBase
    {
        FieldSlot fieldSlot;
        public FieldViewModel(String name)
        {
            fieldSlot = new FieldSlot(name);
            foreach (var it in fieldSlot.Numbers)
            {
                var np = new SlotViewModel(it);
                np.PropertyChanged += Slot_OnNotifyPropertyChanged;
                _Slot.Add(np);
            }
        }
        public string Name
        {
            get { return fieldSlot.Name; }
        }

        private ObservableCollection<SlotViewModel> _Slot = new ObservableCollection<SlotViewModel>();

        public ObservableCollection<SlotViewModel> Slot
        {
            get { return _Slot; }
            set { SetProperty(ref _Slot, value); }
        }

        private int _SelectedIndex;

        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedSlot)); }
            }
        }

        public SlotViewModel SelectedSlot
        {
            get { return (_SelectedIndex >= 0) ? _Slot[_SelectedIndex] : null; }
        }

        void Slot_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            //fieldSlot.Update((SlotViewModel)sender);
        }
    }
}
