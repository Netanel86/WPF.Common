using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace WPF.Common.UI.Converters
{
    class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool visible = (bool)value;
            object converted = null;
            if (visible)
            {
                converted = Visibility.Visible;
            }
            else
            {
                converted = Visibility.Collapsed;
            }

            return converted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visiblity = (Visibility)value;
            object converted = null;

            if (visiblity == Visibility.Visible)
            {
                converted = true;
            }
            else
            {
                converted = false;
            }

            return converted;
        }
    }
}
