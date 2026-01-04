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
    public partial class WinScreen : UserControl
    {
        public WinScreen()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.Width = Utils.gameWindowWidth;
            this.Height = Utils.gameWindowHeight;
            BackgroundImage = Properties.Resources.BackGround;
            BackgroundImageLayout = ImageLayout.Stretch;
            winLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.08f, Width, Height));
            winLabel.ForeColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button1.Font = new Font(Utils.Font, Utils.KFontSize(0.02f, Width, Height));
            button2.Font = new Font(Utils.Font, Utils.KFontSize(0.02f, Width, Height));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Parent is Panel panel)
            {
                panel.ShowView<MainMenu>();
            }
        }
    }
}
