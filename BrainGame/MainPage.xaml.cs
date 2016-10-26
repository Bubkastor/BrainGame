using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GameLogics;
using Windows.Storage;
using BrainGame.View;
using Data;

namespace BrainGame
{

    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ShowGameMode(object sender, RoutedEventArgs e)
        {
            OpenGameMode.Begin();
        }

        private void GameMultip(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LevelPage), "RuleMultiplication");
            CloseGameMode.Begin();
        }

        private void GamePlus(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LevelPage), "RuleAddition");
            CloseGameMode.Begin();
        }

        private void Image_Tapped(Object sender, TappedRoutedEventArgs e)
        {
            using (var db = new GameContext())
            {
                db.GamesAddition.Add(new GameAddition(true, 0, new Difficult(1, 10)));
                db.SaveChanges();
            }

        }
        private List<GameAddition> GetGameAddition()
        {
            List<GameAddition> result = new List<GameAddition>();
            var dif = new Difficult(1, 10);
            result.Add(new GameAddition(true, 0, new Difficult(1, 10)));
            result.Add(new GameAddition(false, 0, new Difficult(2, 11)));
            result.Add(new GameAddition(false, 0, new Difficult(3, 12)));
            result.Add(new GameAddition(false, 0, new Difficult(4, 13)));
            result.Add(new GameAddition(false, 0, new Difficult(5, 14)));
            result.Add(new GameAddition(false, 0, new Difficult(6, 15)));
            result.Add(new GameAddition(false, 0, new Difficult(7, 16)));
            result.Add(new GameAddition(false, 0, new Difficult(8, 17)));
            result.Add(new GameAddition(false, 0, new Difficult(9, 18)));
            return result;
        }
    }
}
