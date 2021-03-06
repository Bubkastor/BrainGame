﻿using Windows.UI.Xaml.Controls;
using ViewModels;
using Windows.UI.Xaml.Media;
using Windows.UI;
using GameLogics;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Composition;
using Microsoft.Graphics.Canvas.Effects;
using System;
using Windows.UI.Core;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;


namespace BrainGame
{    
    public sealed partial class FieldPage : Page
    {
        public FieldSlotViewModel FieldModel;
        private BaseRule rule;
        private LevelViewModel level;

        public FieldPage()
        {
            this.InitializeComponent();                                                   
        }

        private void InitGameAndRun()
        {
            rule.onEndGame += EndGame;
            rule.SetOnUpdateInterface(Update);
            rule.RunGame();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            level = e.Parameter as LevelViewModel;
            FieldModel = new FieldSlotViewModel(level.OptionGame);
            switch (level.OptionGame.RuleMode)
            {
                case "RuleAddition":
                    rule = new RuleAddition(ref FieldModel, "RuleAddition");
                    break;
                case "RuleMultiplication":
                    rule = new RuleMultiplication(ref FieldModel, "RuleMultiplication");
                    break;
                default:
                    break;
            }            
            Description.Text = rule.Description;
            InitGameAndRun();
        }

        private async void  Update(TimeSpan ts)
        {
            await Dispatcher.TryRunAsync(CoreDispatcherPriority.High,  () => {
                timer.Text = ts.ToString("mm\\:ss");
            });
        }

        private async void EndGame(object sender, EventArgs e)
        {
            await Dispatcher.TryRunAsync(CoreDispatcherPriority.High, () => {
                var arg = (EndEventArgs)e;
                arg.level = level;
                if (arg.IsWin)
                    level.Raiting = (short)(arg.Time.TotalSeconds * 10);
                Frame.Navigate(typeof(GameOverPage), arg);

            });
            
        }
       

        private void TextBlock_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            
            var slot = FieldModel.SelectedSlot;
            if (!slot.IsSelected)
            {
                rule.AddSlot(ref slot);
            }
            else
            {
                rule.DeleteSlot(ref slot);
            }
        }

        private void onPause(Object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if(pause.Visibility == Windows.UI.Xaml.Visibility.Visible)
            {
                OnStart.Begin();
                pause.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                rule.isPause = false;
            }
            else
            {
                OnPause.Begin();
                pause.Visibility = Windows.UI.Xaml.Visibility.Visible;
                rule.isPause = true;
            }
        }
    }
}
