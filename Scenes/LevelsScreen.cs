using Neggatrix.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neggatrix.Scenes
{
    public partial class LevelsScreen : UserControl
    {
        public LevelsScreen()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Width = Utils.gameWindowWidth;
            Height = Utils.gameWindowHeight;
            mainLayout.ForeColor = Color.White;
            titleLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
            backButton.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
            backButton.Cursor = Cursors.Hand;
            StyleUtils.ApplyHoverEffect(backButton);
            foreach (Control control in buttonsPanel.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = Color.FromArgb(128, 255, 0,0);
                    btn.Font = new Font(Utils.Font, Utils.KFontSize(0.05f, Width, Height));
                    btn.Cursor = Cursors.Hand;

                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (Parent is Panel panel)
            {
                panel.ShowView<MainMenu>();
            }
        }

        private void mainLayout_Resize(object sender, EventArgs e)
        {
            titleLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
            backButton.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
            foreach (Control control in buttonsPanel.Controls)
            {
                if (control is Button btn)
                {
                    btn.Font = new Font(Utils.Font, Utils.KFontSize(0.05f, Width, Height));
                }
            }
        }
    }
}
