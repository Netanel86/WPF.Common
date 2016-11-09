using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WPF.Common.Services;
using System.Windows.Interop;

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

        //public CustomWindow()
        //    :base()
        //{
        //    this.SourceInitialized += sourceInitialized;
        //}

        //private void sourceInitialized(object i_Sender, EventArgs i_Args)
        //{
        //    System.IntPtr handle = (new WindowInteropHelper(this)).Handle;
        //    HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowProc));
        //}
    }
}
