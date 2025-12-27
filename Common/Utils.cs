using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Common
{
    public static class Utils
    {
        public static int gameWindowWidth = 1000;
        public static int gameWindowHeight = 600;
        public static float GlobalGravity = 2000f;
        public static string Font = "Curlz MT";

        public static float Distance(PointF a, PointF b)
        {
            return (float)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static int CalculateFPS(float deltaTime)
        {
            if (deltaTime <= 0) return 0;
            return (int)(1f / deltaTime);
        }
        public static int KFontSize(float k, int width, int height)
        {
            return (int)(Math.Sqrt(width * height) * k);
        }

        public static void ShowView<T>(this Panel container) where T : UserControl, new()
        {
            container.Controls.Clear();
            T view = new T();
            view.Dock = DockStyle.Fill;
            container.Controls.Add(view);
        }
        public static bool IsAppIdle()
        {
            return !PeekMessage(out _, IntPtr.Zero, 0, 0, 0);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public UIntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point pt;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage(
            out MSG lpMsg,
            IntPtr hWnd,
            uint wMsgFilterMin,
            uint wMsgFilterMax,
            uint wRemoveMsg
        );
    }
}
