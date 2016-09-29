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
            //rule = new RuleAddition(ref FieldModel);
            rule = new RuleMultiplication(ref FieldModel);
            rule.onEndGame += EndGame;
            rule.SetOnUpdateInterface(Update);
            rule.RunGame();
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
                
                Description.Text = arg.IsWin.ToString();
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
