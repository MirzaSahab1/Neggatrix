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
            musicVolume.VolumeChanged += musicVloume_OnChange;
            sfxVolume.VolumeChanged += sfxVloume_OnChange;
            musicVolume.Volume = float.Parse(FileUtils.GetField("data.txt", 2));
            sfxVolume.Volume = float.Parse(FileUtils.GetField("data.txt", 3));
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
                MVLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.04f, Width, Height));
                SFXVLabel.Font = new Font(Utils.Font, Utils.KFontSize(0.04f, Width, Height));
            }
        }
        private void musicVloume_OnChange(object sender, EventArgs e)
        {
            FileUtils.SaveField("data.txt", 2, musicVolume.Volume.ToString());
        }
        private void sfxVloume_OnChange(object sender, EventArgs e)
        {
            FileUtils.SaveField("data.txt", 3, sfxVolume.Volume.ToString());
        }
    }
}
