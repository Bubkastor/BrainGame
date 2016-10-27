using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ViewModels;
using Data;


namespace BrainGame.View
{

    public sealed partial class LevelPage : Page
    {
        private FieldLevelViewModel fieldLevelViewModel;
        private String gameMode;

        public LevelPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as string;
            switch (param)
            {
                case "RuleAddition":
                    fieldLevelViewModel = new FieldLevelViewModel(GameMode.GameAddition);
                    break;
                case "RuleMultiplication":
                    fieldLevelViewModel = new FieldLevelViewModel(GameMode.GameMultiplication);
                    break;
                default:
                    break;
            }            
            gameMode = param;
        }

        private void Border_Tapped(Object sender, TappedRoutedEventArgs e)
        {
            var level = fieldLevelViewModel.SelectedLevel;            
            Frame.Navigate(typeof(FieldPage), level);
        }
    }
}
