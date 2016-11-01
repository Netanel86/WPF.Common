using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using WPF.Common.UI.Resources;
using System.Windows.Media.Imaging;
using WPF.Common.Messaging;

namespace WPF.Common.UI.Converters
{
    public class GeneralBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object newValue = null;
            

            newValue = new BitmapImage(new Uri((parameter as IResourceAdapter).GetResource(value) as string));
           
            
            return newValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
