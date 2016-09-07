using Windows.UI.Xaml.Controls;
using ViewModels;
namespace BrainGame
{
    
    public sealed partial class FieldPage : Page
    {
        public FieldViewModel FieldModel { get; set; }
        public FieldPage()
        {
            this.InitializeComponent();
            FieldModel = new FieldViewModel("asd");
        }
    }
}
