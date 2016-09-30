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

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace BrainGame
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
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
    }
}
