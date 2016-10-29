using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using WPF.Common.ViewModel;
using System.Windows.Controls;
using System.Reflection;
//using WPF.Common.UI.View;
using System.Windows.Input;
using WPF.Common.Services;
using WPF.Common.Messaging;

namespace WPF.Common.UI.Behaviors
{
    public interface INavigationHeader
    {
        INavigationService Navigator { get; set; }
    }
    
    public class Navigator : Behavior<Window>, INavigationService
    {
        public readonly DependencyProperty HandlerProperty =
            DependencyProperty.Register("Handler", typeof(INavigationHeader), typeof(Navigator));
        public INavigationHeader Handler
        {
            get { return this.GetValue(HandlerProperty) as INavigationHeader; }
            set { this.SetValue(HandlerProperty, value); }
        }

        public readonly DependencyProperty MessageTypeProperty =
            DependencyProperty.Register("MessageType", typeof(Type), typeof(Navigator));
        public Type MessageType 
        {
            get { return this.GetValue(MessageTypeProperty) as Type; }
            set { this.SetValue(MessageTypeProperty, value); }
        }
        
        private Panel m_RootPanel = null;

        protected override void OnAttached()
        {
            //retrieve the root panel of the window
            m_RootPanel = this.AssociatedObject.Content as Panel;

            INavigable viewModel = this.AssociatedObject.TryGetViewModel() as INavigable;

            if (m_RootPanel == null)
            {
                throw new ArgumentNullException(this.AssociatedObject.Name + " Has no root element of type Panel.");
            }

            if (viewModel == null)
            {
                throw new ArgumentNullException(this.AssociatedObject.Name + " Has no datacontext/viewmodel implementing INavigable interface.");
            }

            if (this.Handler != null)
            {
                Handler.Navigator = this;
            }
            
            viewModel.Navigator = this;

            base.OnAttached();
        }

        private Stack<Action<object>> m_CallBackFunctions
            = new Stack<Action<object>>();

        public object GetCurrentDataContext()
        {
            object handler = null;

            if (m_RootPanel.Children.Count == 1)
            {
                handler = this.AssociatedObject.TryGetViewModel();
            }
            else
            {
                handler = (m_RootPanel.Children[m_RootPanel.Children.Count - 1] as ContentControl).TryGetViewModel();
            }
            
            return handler;
        }

        public void OverrideBy(Type i_ControlType, Action<object> i_Completed)
        {
            this.m_RootPanel.Children.RemoveAt(m_RootPanel.Children.Count - 1);

            this.NavigateTo(i_ControlType, i_Completed);
        }

        public void NavigateBackwards(object i_Result)
        {
            m_RootPanel.Children.RemoveAt(m_RootPanel.Children.Count - 1);

            UIElement element = m_RootPanel.Children[m_RootPanel.Children.Count - 1];
            element.IsEnabled = true;
            element.Visibility = Visibility.Visible;

            Action<object> completedMethod = m_CallBackFunctions.Pop();
            if (completedMethod != null)
            {
                completedMethod(i_Result);
            }

            OnViewChanged(GetCurrentDataContext());
        }

        public void NavigateTo(Type i_ControlType, Action<object> i_Completed)
        {
            ContentControl view = invokeControl(i_ControlType);

            navigate(view, i_Completed);
        }

        public void NavigateTo(Type i_ControlType, Action<object> i_Completed, object i_InitialValue)
        {
            ContentControl view = invokeControl(i_ControlType);

            IDialogModel dialog = null;
            
            if (i_InitialValue != null )
            {
                if ((dialog = view.TryGetViewModel() as IDialogModel) != null)
                {
                    dialog.DefaultValue = i_InitialValue;
                }
                else
                {
                    throw new ArgumentNullException(view.Name + " has no viewmodel implementing IDialogModel");
                }
            }

            navigate(view, i_Completed);
        }

        public void NavigateTo(IMessageModel i_MessageModel, Action<object> i_Completed) 
        {
            UserControl message = invokeControl(MessageType) as UserControl;
            message.DataContext = i_MessageModel;

            navigate(message, i_Completed);
        }

        private void navigate(ContentControl i_Control, Action<object> i_Completed)
        {
            if (i_Control != null)
            {
                INavigable controlModel = i_Control.TryGetViewModel() as INavigable;

                if (controlModel != null)
                {
                    controlModel.Navigator = this;
                }
                else
                {
                    throw new ArgumentNullException(i_Control.Name + " does not have a view model implementing INavigable interface");
                }


                if (controlModel is IMessageModel)
                {
                    foreach (UIElement element in this.m_RootPanel.Children)
                    {
                        element.IsEnabled = false;
                    }
                }
                else
                {
                    foreach (UIElement element in this.m_RootPanel.Children)
                    {
                        element.IsEnabled = false;
                        element.Visibility = Visibility.Collapsed;
                    }
                }

                this.m_RootPanel.Children.Add(i_Control);

                m_CallBackFunctions.Push(i_Completed);

                OnViewChanged(GetCurrentDataContext());
            }
        }

        public void Close()
        {
            this.AssociatedObject.Close();
        }

        public event EventHandler ViewChanged;
        protected void OnViewChanged(object i_ViewModel)
        {
            if (ViewChanged != null)
            {
                ViewChanged(this, new NotificationEventArgs<object>(i_ViewModel));
            }
        }

        private ContentControl invokeControl(Type i_ControlType)
        {
            ConstructorInfo ctor = i_ControlType.GetConstructor(new Type[0]);
            ContentControl view = null;

            if (ctor != null)
            {
                if ((view = ctor.Invoke(new object[0]) as ContentControl) == null)
                {
                    throw new ArgumentNullException(i_ControlType.Name + " is not derived from ContentControl");
                }
            }
            else
            {
                throw new ArgumentNullException(i_ControlType.Name + ": has no empty constructor");
            }

            return view;
        }
    }
}
