using Windows.UI.Xaml.Controls;
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
        public FieldViewModel FieldModel;
        private BaseRule rule;

        public FieldPage()
        {
            this.InitializeComponent();
            FieldModel = new FieldViewModel("asd");                                                
        }

        private void InitGameAndRun()
        {
            rule.onEndGame += EndGame;
            rule.SetOnUpdateInterface(Update);
            rule.RunGame();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as string;
            switch (param)
            {
                case "RuleAddition":
                    rule = new RuleAddition(ref FieldModel);
                    break;
                case "RuleMultiplication":
                    rule = new RuleMultiplication(ref FieldModel);
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
                timer.Text = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            });
        }

        private async void EndGame(object sender, EventArgs e)
        {
            await Dispatcher.TryRunAsync(CoreDispatcherPriority.High, () => {
                var arg = (EndEventArgs)e;
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
    }
}
