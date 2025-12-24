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
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (Parent is Panel panel)
            {
                panel.ShowView<Level1>();
            }
        }
    }
}
