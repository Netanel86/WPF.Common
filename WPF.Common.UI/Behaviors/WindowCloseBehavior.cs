using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Interactivity;
using WPF.Common.ViewModel;

namespace WPF.Common.UI.Behaviors
{
    /// <summary>
    /// Closes a window that is handled by a viewmodel implementing <see cref="IClosableElement"/>
    /// </summary>
    public class WindowCloseBehavior : Behavior<Window>
    {
        private IClosableElement m_Handler;

        protected override void OnAttached()
        {
            this.m_Handler = this.AssociatedObject.TryGetViewModel() as IClosableElement;

            if (m_Handler == null)
            {
                throw new ArgumentNullException(this.AssociatedObject.Name + " not implenting IClosableElement interface");
            }

            this.m_Handler.CloseRequest += close;

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            this.m_Handler.CloseRequest -= close;

            base.OnDetaching();
        }

        private void close(object i_Sender, EventArgs i_Args)
        {
            this.AssociatedObject.Close();
        }
    }
}
