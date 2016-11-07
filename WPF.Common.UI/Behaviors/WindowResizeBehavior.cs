using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WPF.Common.UI.Behaviors
{
    /// <summary>
    /// Behavior for adding resize options to a custom window
    /// </summary>
    /// <remarks>
    /// the behavior should be registered by the <see cref="Thumb"/> class
    /// </remarks>
    public static class WindowResizeBehavior
    {
        #region Top Resize Logics
        
        /// <summary>
        /// Identifies the TopResize dependency property 
        /// </summary>
        public static readonly DependencyProperty TopResizeProperty =
            DependencyProperty.RegisterAttached("TopResize", typeof(Window), typeof(WindowResizeBehavior), new UIPropertyMetadata(onTopResizeChanged));

        /// <summary>
        /// Gets the target window for Top resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <returns>the target <see cref="Window"/></returns>
        public static Window GetTopResize(DependencyObject i_Object)
        {
            return (Window)i_Object.GetValue(TopResizeProperty);
        }
        
        /// <summary>
        /// Sets the target window for Top resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <param name="i_Window">the target <see cref="Window"/></param>
        public static void SetTopResize(DependencyObject i_Object, Window i_Window)
        {
            i_Object.SetValue(TopResizeProperty, i_Window);
        }

        private static void onTopResizeChanged(object i_Sender, DependencyPropertyChangedEventArgs i_Args)
        {
            (i_Sender as Thumb).DragDelta += dragTop;
        }

        private static void dragTop(object i_Sender, DragDeltaEventArgs i_Args)
        {
            Window window = (i_Sender as Thumb).GetValue(TopResizeProperty) as Window;

            double validatedChange = window.validateHeightChange(i_Args.VerticalChange, false);

            window.Height -= validatedChange;
            window.Top += validatedChange;
        }
        
        #endregion Top Resize Logics

        #region Top Left Resize Logics

        /// <summary>
        /// Identifies the TopLeftResize dependency property 
        /// </summary>
        public static readonly DependencyProperty TopLeftResizeProperty =
            DependencyProperty.RegisterAttached("TopLeftResize", typeof(Window), typeof(WindowResizeBehavior), new UIPropertyMetadata(onTopLeftResizeChanged));

        /// <summary>
        /// Gets the target window for Top Left resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <returns>the target <see cref="Window"/></returns>
        public static Window GetTopLeftResize(DependencyObject i_Object)
        {
            return (Window)i_Object.GetValue(TopLeftResizeProperty);
        }

        /// <summary>
        /// Sets the target window for Top Left resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <param name="i_Window">the target <see cref="Window"/></param>
        public static void SetTopLeftResize(DependencyObject i_Object, Window i_Window)
        {
            i_Object.SetValue(TopLeftResizeProperty, i_Window);
        }

        private static void onTopLeftResizeChanged(object i_Sender, DependencyPropertyChangedEventArgs i_Args)
        {
            (i_Sender as Thumb).DragDelta += dragTopLeft;
        }

        private static void dragTopLeft(object i_Sender, DragDeltaEventArgs i_Args)
        {
            Window window = (i_Sender as Thumb).GetValue(TopLeftResizeProperty) as Window;

            double verticalChange = window.validateHeightChange(i_Args.VerticalChange, false);
            double horizontalChange = window.validateWidthChange(i_Args.HorizontalChange, false);

            window.Width -= horizontalChange;
            window.Left += horizontalChange;
            window.Height -= verticalChange;
            window.Top += verticalChange;
        }

        #endregion Top Left Resize Logics

        #region Top Right Resize Logics

        /// <summary>
        /// Identifies the TopRightResize dependency property 
        /// </summary>
        public static readonly DependencyProperty TopRightResizeProperty =
            DependencyProperty.RegisterAttached("TopRightResize", typeof(Window), typeof(WindowResizeBehavior), new UIPropertyMetadata(onTopRightResizeChanged));

        /// <summary>
        /// Gets the target window for Top Right resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <returns>the target <see cref="Window"/></returns>
        public static Window GetTopRightResize(DependencyObject i_Object)
        {
            return (Window)i_Object.GetValue(TopRightResizeProperty);
        }

        /// <summary>
        /// Sets the target window for Top Right resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <param name="i_Window">the target <see cref="Window"/></param>
        public static void SetTopRightResize(DependencyObject i_Object, Window i_Window)
        {
            i_Object.SetValue(TopRightResizeProperty, i_Window);
        }

        private static void onTopRightResizeChanged(object i_Sender,DependencyPropertyChangedEventArgs i_Args)
        {
            (i_Sender as Thumb).DragDelta += dragTopRight;
        }

        private static void dragTopRight(object i_Sender, DragDeltaEventArgs i_Args)
        {
            Window window = (i_Sender as Thumb).GetValue(TopRightResizeProperty) as Window;

            double verticalChange = window.validateHeightChange(i_Args.VerticalChange, false);
            double horizontalChange = window.validateWidthChange(i_Args.HorizontalChange);

            window.Height -= verticalChange;
            window.Top += verticalChange;
            window.Width += horizontalChange;
        }

        #endregion Top Right Resize Logics

        #region Left Resize Logics

        /// <summary>
        /// Identifies the LeftResize dependency property 
        /// </summary>
        public static readonly DependencyProperty LeftResizeProperty =
            DependencyProperty.RegisterAttached("LeftResize", typeof(Window), typeof(WindowResizeBehavior), new UIPropertyMetadata(onLeftResizeChanged));

        /// <summary>
        /// Gets the target window for Left resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <returns>the target <see cref="Window"/></returns>
        public static Window GetLeftResize(DependencyObject i_Object)
        {
            return (Window)i_Object.GetValue(LeftResizeProperty);
        }

        /// <summary>
        /// Sets the target window for Left resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <param name="i_Window">the target <see cref="Window"/></param>
        public static void SetLeftResize(DependencyObject i_Object, Window i_Window)
        {
            i_Object.SetValue(LeftResizeProperty, i_Window);
        }

        private static void onLeftResizeChanged(object i_Sender, DependencyPropertyChangedEventArgs i_Args)
        {
            (i_Sender as Thumb).DragDelta += dragLeft;
        }

        private static void dragLeft(object i_Sender, DragDeltaEventArgs i_Args)
        {
            Window window = (i_Sender as Thumb).GetValue(LeftResizeProperty) as Window;

            double horizontalchange = window.validateWidthChange(i_Args.HorizontalChange, false);
            window.Width -= horizontalchange;
            window.Left += horizontalchange;
        }

        #endregion Left Resize Logics

        #region Right Resize Logics

        /// <summary>
        /// Identifies the RightResize dependency property 
        /// </summary>
        public static readonly DependencyProperty RightResizeProperty =
            DependencyProperty.RegisterAttached("RightResize", typeof(Window), typeof(WindowResizeBehavior), new UIPropertyMetadata(onRightResizeChanged));

        /// <summary>
        /// Gets the target window for Right resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <returns>the target <see cref="Window"/></returns>
        public static Window GetRightResize(DependencyObject i_Object)
        {
            return (Window)i_Object.GetValue(RightResizeProperty);
        }

        /// <summary>
        /// Sets the target window for Right resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <param name="i_Window">the target <see cref="Window"/></param>
        public static void SetRightResize(DependencyObject i_Object, Window i_Window)
        {
            i_Object.SetValue(RightResizeProperty, i_Window);
        }

        private static void onRightResizeChanged(object i_Sender, DependencyPropertyChangedEventArgs i_Args)
        {
            (i_Sender as Thumb).DragDelta += dragRight;
        }

        private static void dragRight(object i_Sender, DragDeltaEventArgs i_Args)
        {
            Window window = (i_Sender as Thumb).GetValue(RightResizeProperty) as Window;

            double horizontalchange = window.validateWidthChange(i_Args.HorizontalChange);
            window.Width += horizontalchange;

        }

        #endregion Right Resize Logics

        #region Bottom Resize Logics

        /// <summary>
        /// Identifies the BottomResize dependency property 
        /// </summary>
        public static readonly DependencyProperty BottomResizeProperty =
            DependencyProperty.RegisterAttached("BottomResize", typeof(Window), typeof(WindowResizeBehavior), new UIPropertyMetadata(onBottomResizeChanged));

        /// <summary>
        /// Gets the target window for Bottom resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <returns>the target <see cref="Window"/></returns>
        public static Window GetBottomResize(DependencyObject i_Object)
        {
            return (Window)i_Object.GetValue(BottomResizeProperty);
        }

        /// <summary>
        /// Sets the target window for Bottom resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <param name="i_Window">the target <see cref="Window"/></param>
        public static void SetBottomResize(DependencyObject i_Object, Window i_Window)
        {
            i_Object.SetValue(BottomResizeProperty, i_Window);
        }

        private static void onBottomResizeChanged(object i_Sender, DependencyPropertyChangedEventArgs i_Args)
        {
            (i_Sender as Thumb).DragDelta += dragBottom;
        }

        private static void dragBottom(object i_Sender, DragDeltaEventArgs i_Args)
        {
            Window window = (i_Sender as Thumb).GetValue(BottomResizeProperty) as Window;

            double verticalChange = window.validateHeightChange(i_Args.VerticalChange);
            window.Height += verticalChange; 
        }

        #endregion Bottom Resize Logics

        #region Bottom Left Resize Logics

        /// <summary>
        /// Identifies the BottomLeftResize dependency property 
        /// </summary>
        public static readonly DependencyProperty BottomLeftResizeProperty =
            DependencyProperty.RegisterAttached("BottomLeftResize", typeof(Window), typeof(WindowResizeBehavior), new UIPropertyMetadata(onBottomLeftResizeChanged));

        /// <summary>
        /// Gets the target window for Bottom Left resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <returns>the target <see cref="Window"/></returns>
        public static Window GetBottomLeftResize(DependencyObject i_Object)
        {
            return (Window)i_Object.GetValue(BottomLeftResizeProperty);
        }

        /// <summary>
        /// Sets the target window for Bottom Left resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <param name="i_Window">the target <see cref="Window"/></param>
        public static void SetBottomLeftResize(DependencyObject i_Object, Window i_Window)
        {
            i_Object.SetValue(BottomLeftResizeProperty, i_Window);
        }

        private static void onBottomLeftResizeChanged(object i_Sender, DependencyPropertyChangedEventArgs i_Args)
        {
            (i_Sender as Thumb).DragDelta += dragBottomLeft;
        }

        private static void dragBottomLeft(object i_Sender, DragDeltaEventArgs i_Args)
        {
            Window window = (i_Sender as Thumb).GetValue(BottomLeftResizeProperty) as Window;

            double verticalChange = window.validateHeightChange(i_Args.VerticalChange);
            double horizontalChange = window.validateWidthChange(i_Args.HorizontalChange, false);

            window.Width -= horizontalChange;
            window.Left += horizontalChange;
            window.Height += verticalChange;
        }

        #endregion Bottom Left Resize Logics

        #region Bottom Right Resize Logics

        /// <summary>
        /// Identifies the BottomRightResize dependency property 
        /// </summary>
        public static readonly DependencyProperty BottomRightResizeProperty =
            DependencyProperty.RegisterAttached("BottomRightResize", typeof(Window), typeof(WindowResizeBehavior), new UIPropertyMetadata(onBottomRightResizeChanged));

        /// <summary>
        /// Gets the target window for Bottom Right resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <returns>the target <see cref="Window"/></returns>
        public static Window GetBottomRightResize(DependencyObject i_Object)
        {
            return (Window)i_Object.GetValue(BottomRightResizeProperty);
        }

        /// <summary>
        /// Sets the target window for Bottom Right resize
        /// </summary>
        /// <param name="i_Object">the dependency object who requested the resize</param>
        /// <param name="i_Window">the target <see cref="Window"/></param>
        public static void SetBottomRightResize(DependencyObject i_Object, Window i_Window)
        {
            i_Object.SetValue(BottomRightResizeProperty, i_Window);
        }

        private static void onBottomRightResizeChanged(object i_Sender, DependencyPropertyChangedEventArgs i_Args)
        {
            (i_Sender as Thumb).DragDelta += dragBottomRight;
        }

        private static void dragBottomRight(object i_Sender, DragDeltaEventArgs i_Args)
        {
            Window window = (i_Sender as Thumb).GetValue(BottomRightResizeProperty) as Window;

            double verticalChange = window.validateHeightChange(i_Args.VerticalChange);
            double horizontalChange = window.validateWidthChange(i_Args.HorizontalChange);

            window.Height += verticalChange;
            window.Width += horizontalChange;
        }

        #endregion Bottom Right Resize Logics

        private static double validateHeightChange(this Window i_Window, double i_DeltaY, bool i_Positive = true)
        {
            double result = i_Positive ? i_Window.Height + i_DeltaY : i_Window.Height - i_DeltaY;
            double validatedDelta = i_DeltaY;

            if (result <= i_Window.MinHeight || result >= i_Window.MaxHeight || result < 0)
            {
                validatedDelta = 0;
            }

            return validatedDelta;
        }

        private static double validateWidthChange(this Window i_Window, double i_DeltaX, bool i_Positive = true)
        {
            double result = i_Positive ? i_Window.Width + i_DeltaX : i_Window.Width - i_DeltaX;
            double validatedDelta = i_DeltaX;

            if (result <= i_Window.MinWidth || result >= i_Window.MaxWidth || result < 0)
            {
                validatedDelta = 0;
            }

            return validatedDelta;
        }
    }
}
