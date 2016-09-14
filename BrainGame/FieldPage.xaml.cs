using Windows.UI.Xaml.Controls;
using ViewModels;
using Windows.UI.Xaml.Media;
using Windows.UI;
using GameLogics;
namespace BrainGame
{
    
    public sealed partial class FieldPage : Page
    {
        public FieldViewModel FieldModel;
        private RuleAddition rule;
        public FieldPage()
        {
            this.InitializeComponent();
            FieldModel = new FieldViewModel("asd");
            rule = new RuleAddition(ref FieldModel);
            rule.RunGame();            
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
