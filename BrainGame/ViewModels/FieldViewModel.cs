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
            foreach (var it in fieldSlot.Numbers)
            {
                var np = new SlotViewModel(it);
                np.PropertyChanged += Slot_OnNotifyPropertyChanged;
                _Slot.Add(np);
            }
        }

        private ObservableCollection<SlotViewModel> _Slot = new ObservableCollection<SlotViewModel>();

        public ObservableCollection<SlotViewModel> Slot
        {
            get { return _Slot; }
            set { SetProperty(ref _Slot, value); }
        }

        private int _SelectedIndex;
        public void Add()
        {
            var slot = new SlotViewModel();
            slot.PropertyChanged += Slot_OnNotifyPropertyChanged;
            Slot.Add(slot);            
            SelectedIndex = Slot.IndexOf(slot);
        }
        public void Show()
        {
            if ( SelectedIndex != -1)
            {
                var slot = Slot[SelectedIndex];
                slot.Visible = !slot.Visible;
            }
        }
        public void Delete()
        {
            if (SelectedIndex != -1)
            {
                var slot = Slot[SelectedIndex];
                Slot.RemoveAt(SelectedIndex);
            }
        }

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

        public List<SlotViewModel> VisibleSlot
        {
            get {
                List<SlotViewModel> list = new List<SlotViewModel>();
                foreach(var item in Slot)                
                    if (item.Visible)
                        list.Add(item);
                return list;
                }
        }
        void Slot_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            //fieldSlot.Update((SlotViewModel)sender);
        }
    }
}
