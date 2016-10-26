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
using Microsoft.EntityFrameworkCore;

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

              
                db.SaveChanges();
            }

        }
        private List<GameMultiplication> GamesMultiplication()
        {
            List<GameMultiplication> result = new List<GameMultiplication>();
            result.Add(new GameMultiplication { IsOpen = true, Raiting = 0, BeginRange = 1, EndRange = 10 });
            result.Add(new GameMultiplication { IsOpen = false, Raiting = 0, BeginRange = 2, EndRange = 11 });
            result.Add(new GameMultiplication { IsOpen = false, Raiting = 0, BeginRange = 3, EndRange = 12 });
            result.Add(new GameMultiplication { IsOpen = false, Raiting = 0, BeginRange = 4, EndRange = 13 });
            result.Add(new GameMultiplication { IsOpen = false, Raiting = 0, BeginRange = 5, EndRange = 14 });
            result.Add(new GameMultiplication { IsOpen = false, Raiting = 0, BeginRange = 6, EndRange = 15 });
            result.Add(new GameMultiplication { IsOpen = false, Raiting = 0, BeginRange = 7, EndRange = 16 });
            result.Add(new GameMultiplication { IsOpen = false, Raiting = 0, BeginRange = 8, EndRange = 17 });
            result.Add(new GameMultiplication { IsOpen = false, Raiting = 0, BeginRange = 9, EndRange = 18 });
            result.Add(new GameMultiplication { IsOpen = false, Raiting = 0, BeginRange = 10, EndRange = 19 });
            return result;
        }
    }
}
