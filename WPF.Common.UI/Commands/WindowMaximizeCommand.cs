using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WPF.Common.Input;

namespace WPF.Common.UI.Commands
{
    /// <summary>
    /// Command for maximizing a window
    /// </summary>
    public class WindowMaximizeCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        
        public override void Execute(object parameter)
        {
            Window window = parameter as Window;

            if (window != null)
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }
            }
        }
    }
}
