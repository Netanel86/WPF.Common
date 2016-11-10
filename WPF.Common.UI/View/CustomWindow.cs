using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WPF.Common.Services;
using System.Windows.Interop;
using MS.Win32;
using System.Runtime.InteropServices;

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

        public CustomWindow()
            : base()
        {
            this.SourceInitialized += sourceInitialized;
        }

        private void sourceInitialized(object i_Sender, EventArgs i_Args)
        {
            IntPtr handle = (new WindowInteropHelper(this)).Handle;
            HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowProc));
        }

        private static IntPtr WindowProc(IntPtr i_Hwnd, int i_Msg, IntPtr i_WidthParam, IntPtr i_LengthParam, ref bool o_Handled)
        {
            switch (i_Msg)
            {
                case 0x0024: /* WM_GETMINMAXINFO */
                    wmGetMinMaxInfo(i_Hwnd, i_LengthParam);
                    o_Handled = true;
                    break;
            }

            return (IntPtr)0;
        }

        private static void wmGetMinMaxInfo(IntPtr i_Hwnd, IntPtr i_LengthParam)
        {
            MINMAXINFO minMax = (MINMAXINFO)Marshal.PtrToStructure(i_LengthParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;

            IntPtr monitor = MonitorFromWindow(i_Hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {

                MonitorInfo monitorInfo = new MonitorInfo();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.RectWorkArea;
                RECT rcMonitorArea = monitorInfo.RectMontior;
                minMax.PntMaxPosition.X= (int)Math.Abs(rcWorkArea.Left - rcMonitorArea.Left);
                minMax.PntMaxPosition.Y = (int)Math.Abs(rcWorkArea.Top - rcMonitorArea.Top);
                minMax.PntMaxSize.X = (int)Math.Abs(rcWorkArea.Right - rcWorkArea.Left);
                minMax.PntMaxSize.Y = (int)Math.Abs(rcWorkArea.Bottom - rcWorkArea.Top);
            }

            Marshal.StructureToPtr(minMax, i_LengthParam, true);
        }

        #region Monitor Info Types
        /// <summary>
        /// Holds values for a point in a 2d enviroment
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// X coordinate of a point
            /// </summary>
            public int X;

            /// <summary>
            /// Y coordinate of a point
            /// </summary>
            public int Y;

            /// <summary>
            /// Construct a point with (x,y) coordinates
            /// </summary>
            /// <param name="i_X">X coordinate of a point</param>
            /// <param name="i_Y">Y coordinate of a point</param>
            public POINT(int i_X, int i_Y)
            {
                this.X = i_X;
                this.Y = i_Y;
            }

        }

        /// <summary>
        /// Contanins information about a window's maximized size and poition and its min and max tracking size.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            /// <summary>
            /// A reserved point for system use. leave empty.
            /// </summary>
            public  POINT PntReserved;

            /// <summary>
            /// Window's max size 
            /// </summary>
            public POINT PntMaxSize;

            /// <summary>
            /// Window's max position
            /// </summary>
            public POINT PntMaxPosition;

            /// <summary>
            /// Window's min tracking size
            /// </summary>
            public POINT PntMinTrackSize;

            /// <summary>
            /// Window's max tracking size
            /// </summary>
            public POINT PntMaxTrackSize;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            public int Left;

            public int Top;

            public int Right;

            public int Bottom;

            /// <summary>
            /// Get a rectangle with all 0 values
            /// </summary>
            public static readonly RECT Empty = new RECT();

            public int Width
            {
                get { return Math.Abs(Right - Left); }  // Abs needed for BIDI OS
            }

            public int Height
            {
                get { return Bottom - Top; }
            }

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }

            public RECT(RECT i_RectSource)
            {
                this.Left = i_RectSource.Left;
                this.Top = i_RectSource.Top;
                this.Right = i_RectSource.Right;
                this.Bottom = i_RectSource.Bottom;
            }
            
            /// <summary> 
            /// Return a user friendly representation of this struct
            /// </summary>
            public override string ToString()
            {
                if (this == RECT.Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + Left + " / top : " + Top + " / right : " + Right + " / bottom : " + Bottom + " }";
            }

            /// <summary> 
            /// Determine if 2 RECT are equal (deep compare) 
            /// </summary>
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }

            /// <summary>
            /// Return the HashCode for this struct (not garanteed to be unique)
            /// </summary>
            public override int GetHashCode()
            {
                return Left.GetHashCode() + Top.GetHashCode() + Right.GetHashCode() + Bottom.GetHashCode();
            }

            /// <summary> 
            /// Determine if 2 RECT are equal (deep compare)
            /// </summary>
            public static bool operator ==(RECT rect1, RECT rect2)
            {
                return (rect1.Left == rect2.Left && rect1.Top == rect2.Top && rect1.Right == rect2.Right && rect1.Bottom == rect2.Bottom);
            }

            /// <summary> 
            /// Determine if 2 RECT are different(deep compare)
            /// </summary>
            public static bool operator !=(RECT rect1, RECT rect2)
            {
                return !(rect1 == rect2);
            }
        }  

        /// <summary>
        /// Contains information about a display monitor.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MonitorInfo
        {
            /// <summary>
            /// The size of the structure in bytes
            /// </summary>
            public int StructByteSize = Marshal.SizeOf(typeof(MonitorInfo));

            /// <summary>
            /// Structure that specifies the display monitor rectangle,
            /// </summary>
            public RECT RectMontior = new RECT();

            /// <summary>
            /// Structure that specifies the work area rectangle
            /// </summary>
            public RECT RectWorkArea = new RECT();

            /// <summary>
            /// A set of flags that represent attributes of the display monitor
            /// </summary>
            public int Flags;
 
        }
        #endregion

        #region Imported Monitor Info Method's
        [DllImport("User32.dll")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        [DllImport("User32.dll")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MonitorInfo lpmi);
        #endregion
    }
}
