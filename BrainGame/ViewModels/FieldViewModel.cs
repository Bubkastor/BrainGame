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
        public FieldViewModel()
        {
            fieldSlot = new FieldSlot();
            foreach(var row in fieldSlot.Numbers)
            {
                foreach (var slot in row)
                {
                    var np = new SlotViewModel(slot);
                    np.PropertyChanged += Slot_OnNotifyPropertyChanged;                    
                }
                
            }
        }

        ObservableCollection<SlotViewModel> _Slot = new ObservableCollection<SlotViewModel>() ;
        public ObservableCollection<SlotViewModel> Slot
        {
            get { return _Slot; }
            set { SetProperty(ref _Slot, value); }
        }
        int _SelectedIndex;
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
