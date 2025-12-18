using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Common
{
    static class Input
    {
        static HashSet<Keys> down = new HashSet<Keys>();
        static HashSet<Keys> pressed = new HashSet<Keys>();

        public static void KeyDown(Keys k)
        {
            if (!down.Contains(k))
            {
                pressed.Add(k); // edge
            }
            down.Add(k);
        }

        public static void KeyUp(Keys k)
        {
            down.Remove(k);
        }

        public static bool IsDown(Keys k)
        {
            return down.Contains(k);
        }

        public static bool IsPressed(Keys k)
        {
            return pressed.Contains(k);
        }

        public static void EndFrame()
        {
            pressed.Clear();
        }
    }

}
