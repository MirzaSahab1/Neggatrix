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
    public partial class Tutorial : UserControl
    {
        public Tutorial()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.Width = Utils.gameWindowWidth;
            this.Height = Utils.gameWindowHeight;
            mainLayout.ForeColor = Color.White;
            titleLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
            mainLayout.Font = new Font(Utils.Font, Utils.KFontSize(0.04f, Width, Height));
            backButton.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
            backButton.Cursor = Cursors.Hand;
            StyleUtils.ApplyHoverEffect(backButton);
            storyTextBox.Text = Utils.tutorialContent;
            storyTextBox.ForeColor = Color.White;
            storyTextBox.Font = new Font(Utils.Font, Utils.KFontSize(0.03f, Width, Height));
            this.Focus();
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
                mainLayout.Font = new Font(Utils.Font, Utils.KFontSize(0.04f, Width, Height));
                backButton.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
                storyTextBox.Font = new Font(Utils.Font, Utils.KFontSize(0.03f, Width, Height));
            }
        }
    }
}
