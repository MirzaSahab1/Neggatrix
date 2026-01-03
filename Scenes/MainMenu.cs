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
            GamePlay? gamePlay = Controls.OfType<GamePlay>().FirstOrDefault();

            if (gamePlay != null) Controls[Controls.IndexOf(gamePlay)].Dispose();
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
            foreach (Control control in buttonsPanel2.Controls)
            {
                if (control is Label label)
                {
                    label.Cursor = Cursors.Hand;
                    label.Font = new Font(Utils.Font, Utils.KFontSize(0.02f, Width, Height));
                    StyleUtils.ApplyHoverEffect(label);
                }
            }
        }

        private void mainLayout_Resize(object sender, EventArgs e)
        {
            if (Parent?.TopLevelControl is Form mainForm)
            {
                if (mainForm.WindowState == FormWindowState.Minimized) return;
                titleLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.035f, Width, Height));
                foreach (Control control in buttonsPanel.Controls)
                {
                    if (control is Label label)
                    {
                        label.Font = new Font(Utils.Font, Utils.KFontSize(0.03f, Width, Height));
                    }
                }
                foreach (Control control in buttonsPanel2.Controls)
                {
                    if (control is Label label)
                    {
                        label.Cursor = Cursors.Hand;
                        label.Font = new Font(Utils.Font, Utils.KFontSize(0.02f, Width, Height));
                        StyleUtils.ApplyHoverEffect(label);
                    }
                }
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            if (Parent is Panel panel)
            {
                panel.ShowView<GamePlay>();
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

        private void storyButton_Click(object sender, EventArgs e)
        {
            if (Parent is Panel panel)
            {
                panel.ShowView<Story>();
            }
        }

        private void tutorialButton_Click(object sender, EventArgs e)
        {
            if (Parent is Panel panel)
            {
                panel.ShowView<Tutorial>();
            }
        }
    }
}
