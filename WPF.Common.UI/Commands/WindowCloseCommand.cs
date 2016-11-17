using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF.Common.Input;
using System.Windows;

namespace WPF.Common.UI.Commands
{
    /// <summary>
    /// Command for closing a <see cref="Window"/>
    /// </summary>
    public class WindowCloseCommand : CommandBase
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
                window.Close();
            }
        }
    }
}
