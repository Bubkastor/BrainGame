using GameLogics;
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

namespace BrainGame
{

    public sealed partial class GameOverPage : Page
    {
        private String gameMode;
        public GameOverPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as EndEventArgs;
            title.Text = param.IsWin ? "You Win" : "You Lose";
            score.Text = "Score: " + (param.Time.TotalSeconds * 10).ToString();
            gameMode = param.GameMode;
        }

        private void Button_Click_New_Game(Object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FieldPage), gameMode);
        }

        private void Button_Click_Main_Menu(Object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), "RuleMultiplication");
        }
    }
}
