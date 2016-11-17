using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using WPF.Common.Input;


namespace WPF.Common.UI.Commands
{
    /// <summary>
    /// Command for minimizing a window
    /// </summary>
    public class WindowMinimizeCommand : CommandBase
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
                window.WindowState = WindowState.Minimized;
            }
        }
    }
}
