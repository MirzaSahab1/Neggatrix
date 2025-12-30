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
    public partial class MessageBox : UserControl
    {
        public string Name  {get; private set;}
        public bool PauseStatus { get; set;}
        public bool restartStatus { get; set;}
        public MessageBox(string message, string action)
        {
            Name = "MessageBox";
            PauseStatus = true;
            restartStatus = false;
            InitializeComponent();
            Width = (int)(Utils.gameWindowWidth / 2);
            Height = (int)(Utils.gameWindowHeight / 2);
            BackColor = Color.Black;
            ForeColor = Color.White;
            Font = new Font(Utils.Font, Utils.KFontSize(0.04f, Width, Height));
            messageLabel.Text = message;
            actionButton.Text = action;
            actionButton.BackColor = Color.Black;
            exitButton.BackColor = Color.Black;
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {

        }

        public void exitButton_Click(object sender, EventArgs e)
        {
            Console.Write("Fuck");
            if (Parent.Parent is Panel panel)
            {
                Console.Write("Fuck2");
                panel.ShowView<MainMenu>();
            }
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            if (actionButton.Text == "Resume")
            {
                PauseStatus = false;
            }
            else if (actionButton.Text == "Restart")
            {
                restartStatus = true;
            }
        }
    }
}
