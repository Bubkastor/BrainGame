using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Models;
using Data;


namespace ViewModels
{
    public class FieldLevelViewModel : NotificationBase
    {
        FieldLevel fieldLevel;
        public FieldLevelViewModel(GameMode mode)
        {
            
            fieldLevel = new FieldLevel(mode);
            _SelectedIndex = -1;            
            foreach (var level in fieldLevel.Levels)
            {
                var np = new LevelViewModel(level);
                np.PropertyChanged += Level_OnNotifyPropertyChanged;
                _Levels.Add(np);
            }
        }

        private ObservableCollection<LevelViewModel> _Levels = new ObservableCollection<LevelViewModel>();

        public ObservableCollection<LevelViewModel> Levels
        {
            get { return _Levels; }
            set { SetProperty(ref _Levels, value); }
        }

        private int _SelectedIndex;

        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                    RaisePropertyChanged(nameof(SelectedLevel));
            }
        }

        public LevelViewModel SelectedLevel
        {
            get { return (_SelectedIndex >= 0) ? _Levels[_SelectedIndex] : null; }
        }

        public void Add(LevelViewModel level)
        {
            level.PropertyChanged += Level_OnNotifyPropertyChanged;
            Levels.Add(level);
            fieldLevel.Add(level);
            SelectedIndex = Levels.IndexOf(level);
        }

        private void Level_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            fieldLevel.Update((LevelViewModel)sender);
        }
    }
}

