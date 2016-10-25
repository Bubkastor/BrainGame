﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Models;


namespace ViewModels
{
    public class FieldLevelViewModel : NotificationBase
    {

        public FieldLevelViewModel()
        {
            //todo init
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
            SelectedIndex = Levels.IndexOf(level);
        }

        private void Level_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            //TODO Notify BD
        }
    }
}
