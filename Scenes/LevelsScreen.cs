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
                    btn.BackColor = Color.FromArgb(128, 255, 0, 0);
                    btn.Font = new Font(Utils.Font, Utils.KFontSize(0.05f, Width, Height));
                    btn.Cursor = Cursors.Hand;

                }
            }
            int savedLevel = int.Parse(FileUtils.GetField("data.txt", 1));
            foreach(var btn in buttonsPanel.Controls)
            {
                if (btn is Button bttn)
                {
                    if (int.Parse(bttn.Text) > savedLevel)
                    {
                        bttn.BackColor = Color.Gray;
                        bttn.Enabled = false;
                    }
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
            if (Parent?.TopLevelControl is Form mainForm)
            {
                if (mainForm.WindowState == FormWindowState.Minimized) return;
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

        private void button1_Click(object sender, EventArgs e)
        {
            FileUtils.SaveField("data.txt", 5, "1");
            if (Parent is Panel panel)
            {
                panel.ShowView<GamePlay>();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileUtils.SaveField("data.txt", 5, "2");
            if (Parent is Panel panel)
            {
                panel.ShowView<GamePlay>();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileUtils.SaveField("data.txt", 5, "3");
            if (Parent is Panel panel)
            {
                panel.ShowView<GamePlay>();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileUtils.SaveField("data.txt", 5, "4");
            if (Parent is Panel panel)
            {
                panel.ShowView<GamePlay>();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileUtils.SaveField("data.txt", 5, "5");
            if (Parent is Panel panel)
            {
                panel.ShowView<GamePlay>();
            }
        }
    }
}
