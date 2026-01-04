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
        public static string storyContent = "In the depths of the system lies the Neggatrix—a subroutine designed to isolate and eradicate corrupted data. Players control Unit Null, a rogue entity attempting to escape deletion. The world is rendered in stark, jagged polygons representing the raw, unrefined geometry of the machine's subconscious. To survive, Unit Null must evade the gaze of the System Sentinels and exploit glitches (physics anomalies) to traverse the unstable memory blocks of the Shadow World.";
        public static string tutorialContent = "To survive the Neggatrix, you must exploit the system's own glitches. Scattered throughout the memory blocks are Chromatic Orbs—unstable fragments of data that temporarily rewrite your rendering code.\r\n\r\nHow to Evade Detection:\r\n\r\nIdentify the Sentinel: Observe the color of the enemy's vision cone (e.g., Red).\r\n\r\nLocate a Glitch: Find a matching Red Orb nearby.\r\n\r\nSync: Touch the orb to override your color value.\r\n\r\nInfiltrate: While your color matches the Sentinel's light, you become invisible to their sensors. Walk freely through their vision cones to reach the next sector.\r\n\r\nWarning: The override is temporary.";

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
            foreach (Control oldControl in container.Controls)
            {
                oldControl.Dispose();
            }
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
