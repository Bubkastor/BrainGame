using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI;

namespace Converters
{
    public class ObjectIsSelected : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            return ((bool)value == true)

                ? new SolidColorBrush(Colors.Green)
                : new SolidColorBrush(Colors.Gray);


        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
