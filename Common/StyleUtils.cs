using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Common
{
    public static class StyleUtils
    {
        public static Color defaultColor = Color.Transparent;
        public static Color defaultForeColor = Color.FromArgb(200, 255, 255, 255);
        public static Color hoverBackColor = Color.Transparent;
        public static Color hoverForeColor = Color.FromArgb(255, 255, 0, 0);
        public static void ApplyHoverEffect(Control ctrl)
        {
            ctrl.BackColor = defaultColor;
            if (ctrl is Label || ctrl is Button)
            {
                ctrl.ForeColor = defaultForeColor;
            }
            ctrl.MouseEnter += (s, e) =>
            {
                ctrl.BackColor = hoverBackColor;
                if (ctrl is Label || ctrl is Button)
                {
                    ctrl.ForeColor = hoverForeColor;
                }
            };
            ctrl.MouseLeave += (s, e) =>
            {
                ctrl.BackColor = defaultColor;
                if (ctrl is Label || ctrl is Button)
                {
                    ctrl.ForeColor = defaultForeColor;
                }
            };
        }
    }
}
