using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace WPF.Common.UI.Behaviors
{
    public class WindowDragBehavior : Behavior<FrameworkElement>
    {
        public static readonly DependencyProperty WindowProperty =
            DependencyProperty.Register("TargetWindow", typeof(Window), typeof(WindowDragBehavior));

        public Window TargetWindow
        {
            get { return this.GetValue(WindowProperty) as Window; }
            set { this.SetValue(WindowProperty, value); }
        }
        protected override void OnAttached()
        {
            this.AssociatedObject.MouseDown += dragMove;

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.MouseDown -= dragMove;
            base.OnDetaching();
        }
        private void dragMove(object i_Sender, MouseButtonEventArgs i_Args)
        {
            if (i_Args.ChangedButton == MouseButton.Left)
            {
                TargetWindow.DragMove();
            }
        }
    }
}
