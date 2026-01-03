using System;
using System.Windows.Forms;
using Neggatrix.Core;
using Neggatrix.Components;
using System.ComponentModel;
using System.Diagnostics;
using Topshelf.Runtime;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using Neggatrix.Common;
using Neggatrix.Scenes;

namespace Neggatrix
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Width = Utils.gameWindowWidth;
            this.Height = Utils.gameWindowHeight;
            DoubleBuffered = true;
            KeyPreview = true;
        }
        
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Input.KeyDown(e.KeyCode);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            Input.KeyUp(e.KeyCode);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BackgroundImage = null;
            panel1.ShowView<GamePlay>();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
