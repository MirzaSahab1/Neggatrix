using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neggatrix.Common;

namespace Neggatrix.Scenes
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            this.Width = Utils.gameWindowWidth;
            this.Height = Utils.gameWindowHeight;
            DoubleBuffered = true;
            BackgroundImage = Properties.Resources.MainMenuArt__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            Level1? level1 = Controls.OfType<Level1>().FirstOrDefault();

            if (level1 != null) Controls[Controls.IndexOf(level1)].Dispose();
            titleLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.035f, Width, Height));
            foreach (Control control in buttonsPanel.Controls)
            {
                if (control is Label label)
                {
                    label.Cursor = Cursors.Hand;
                    label.Font = new Font(Utils.Font, Utils.KFontSize(0.03f, Width, Height));
                    StyleUtils.ApplyHoverEffect(label);
                }
            }
        }

        private void mainLayout_Resize(object sender, EventArgs e)
        {
            
            titleLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.035f, Width, Height));
            foreach (Control control in buttonsPanel.Controls)
            {
                if (control is Label label)
                {
                    label.Font = new Font(Utils.Font, Utils.KFontSize(0.03f, Width, Height));
                }
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (TopLevelControl is Form form)
            {
                form.BackgroundImage = null;
            }
            if (Parent is Panel panel)
            {
                panel.ShowView<Level1>();
            }
        }

        private void levelsButton_Click(object sender, EventArgs e)
        {
            if (Parent is Panel panel)
            {
                panel.ShowView<LevelsScreen>();
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (Parent is Panel panel)
            {
                panel.ShowView<Settings>();
            }
        }

        private void creditsButton_Click(object sender, EventArgs e)
        {
            if (Parent is Panel panel)
            {
                panel.ShowView<Credits>();
            }
        }
    }
}
