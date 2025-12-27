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
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            Width = Utils.gameWindowWidth;
            Height = Utils.gameWindowHeight;
            mainLayout.ForeColor = Color.White;
            titleLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
            backButton.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
            MVLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.04f, Width, Height));
            SFXVLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.04f, Width, Height));
            backButton.Cursor = Cursors.Hand;
            StyleUtils.ApplyHoverEffect(backButton);
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
            MVLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.04f, Width, Height));
            SFXVLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.04f, Width, Height));
        }
    }
}
