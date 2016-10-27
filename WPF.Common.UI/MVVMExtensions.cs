using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace WPF.Common.UI
{
    static class MVVMExtensions
    {
        public static object TryGetViewModel(this ContentControl i_Control)
        {
            object viewModel = null;

            if (i_Control.Content is Panel)
            {
                viewModel = (i_Control.Content as Panel).DataContext;
            }
            else
            {
                viewModel = i_Control.DataContext;
            }
            
            if (viewModel == null)
            {
                throw new ArgumentNullException(i_Control.Name + " does not have a bounded view model");
            }

            return viewModel;
        }
    }
}
