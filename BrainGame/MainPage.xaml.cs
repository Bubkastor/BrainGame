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
            Frame.Navigate(typeof(FieldPage), "RuleMultiplication");
            CloseGameMode.Begin();
        }

        private void GamePlus(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(FieldPage), "RuleAddition");
            CloseGameMode.Begin();            
        }

        private void Image_Tapped(Object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LevelPage));
        }
    }
}
