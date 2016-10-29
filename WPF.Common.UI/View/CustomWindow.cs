using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WPF.Common.Services;

namespace WPF.Common.UI.View
{
    public class CustomWindow : Window
    {
        public static readonly DependencyProperty HeaderContentProperty =
            DependencyProperty.Register("HeaderContent",typeof(object),typeof(CustomWindow));

        public object HeaderContent
        {
            get { return this.GetValue(HeaderContentProperty); }
            set {this.SetValue(HeaderContentProperty, value);}
        }
    }
}
