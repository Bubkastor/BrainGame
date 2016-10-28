using Data;
using GameLogics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ViewModels;
using Models;
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
        private LevelViewModel level;
        public GameOverPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as EndEventArgs;
            level = param.level;
            title.Text = param.IsWin ? "You Win" : "You Lose";
            if (param.IsWin)
            {
                next_play.Visibility = Visibility.Visible;
            }
            else
            {
                next_play.Visibility = Visibility.Collapsed;
            }
                score.Text = "Score: " + (param.Time.TotalSeconds * 10).ToString();
            gameMode = param.GameMode;
        }

        private void Button_Click_Current_Game(Object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FieldPage), level);
        }
        private void Button_Click_Next_Level(Object sender, RoutedEventArgs e)
        {            
            Frame.Navigate(typeof(FieldPage), GetNextLevel());
        }

        private void Button_Click_Main_Menu(Object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private LevelViewModel GetNextLevel()
        {
            Level currentLevel = (Level)level;
            LevelViewModel result = new LevelViewModel(currentLevel);
            BaseGame baseGame = new BaseGame();
            using (var db = new GameContext())
            {
                switch (currentLevel.RuleMode)
                {
                    case "RuleAddition":
                        GameAddition additionLevel = db.GamesAddition.Single(p => p.BeginRange == currentLevel.BeginRange
                            && p.EndRange == currentLevel.EndRange);
                        baseGame = db.GamesAddition.Single(p => p.GameAdditionId == (additionLevel.GameAdditionId + 1));
                        break;
                    case "RuleMultiplication":
                        GameMultiplication multiplicationLevel = db.GamesMultiplication.Single(p => p.BeginRange == currentLevel.BeginRange
                            && p.EndRange == currentLevel.EndRange);
                        baseGame = db.GamesMultiplication.Single(p => p.GameMultiplicationId == (multiplicationLevel.GameMultiplicationId + 1));
                        break;
                    default:                        
                        break;
                }
            }
            if(baseGame != new BaseGame())
            {
                Level nextLevel = new Level(baseGame.IsOpen, baseGame.Raiting, baseGame.BeginRange, baseGame.EndRange);
                result = new LevelViewModel(nextLevel);
            }
            return result;
        }
    }
}
