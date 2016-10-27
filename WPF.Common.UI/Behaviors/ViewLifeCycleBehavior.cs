using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WPF.Common.ViewModel;
using WPF.Common;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Input;
using System.Reflection;

namespace WPF.Common.UI.Behaviors
{
    public class ViewLifeCycleBehavior : Behavior<DependencyObject>
    {
        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.RegisterAttached(
            "CloseCommand",
            typeof(ICommand),
            typeof(ViewLifeCycleBehavior));

        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        public static readonly DependencyProperty LoadCommandProperty =
            DependencyProperty.RegisterAttached(
            "LoadCommand",
            typeof(ICommand),
            typeof(ViewLifeCycleBehavior));

        public ICommand LoadCommand
        {
            get { return (ICommand)GetValue(LoadCommandProperty); }
            set { SetValue(LoadCommandProperty, value); }
        }

        private UserControl m_Control = null;

        protected override void OnAttached()
        {
            if ((m_Control = this.AssociatedObject as UserControl) != null)
            {
                m_Control.Loaded += onDialogLoaded;
                m_Control.Unloaded += onDialogClosed;
            }

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            if (m_Control != null)
            {
                m_Control.Loaded -= onDialogLoaded;
                m_Control.Unloaded -= onDialogClosed;
            }
            base.OnDetaching();
        }

        private void onDialogLoaded(object i_Sender, EventArgs i_Args)
        {
            if (this.LoadCommand != null && this.LoadCommand.CanExecute(null))
            {
                this.LoadCommand.Execute(null);
            }
        }
        
        private void onDialogClosed(object i_Sender, EventArgs i_Args)
        {
            if (this.CloseCommand != null && this.CloseCommand.CanExecute(null))
            {
                this.CloseCommand.Execute(null);
            }
        }
    }
}
