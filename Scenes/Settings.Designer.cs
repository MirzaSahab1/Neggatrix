namespace Neggatrix.Scenes
{
    partial class Settings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainLayout = new TableLayoutPanel();
            titleLabel = new Label();
            backButton = new Label();
            volumeSlider1 = new NAudio.Gui.VolumeSlider();
            volumeSlider2 = new NAudio.Gui.VolumeSlider();
            MVLabel = new Label();
            SFXVLabel = new Label();
            mainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 3;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            mainLayout.Controls.Add(titleLabel, 1, 0);
            mainLayout.Controls.Add(backButton, 0, 0);
            mainLayout.Controls.Add(volumeSlider1, 1, 2);
            mainLayout.Controls.Add(volumeSlider2, 1, 4);
            mainLayout.Controls.Add(MVLabel, 1, 1);
            mainLayout.Controls.Add(SFXVLabel, 1, 3);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 7;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            mainLayout.Size = new Size(961, 574);
            mainLayout.TabIndex = 2;
            mainLayout.Resize += mainLayout_Resize;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Location = new Point(99, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(762, 114);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Settings";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.Dock = DockStyle.Fill;
            backButton.Location = new Point(3, 0);
            backButton.Name = "backButton";
            backButton.Size = new Size(90, 114);
            backButton.TabIndex = 2;
            backButton.Text = "←";
            backButton.TextAlign = ContentAlignment.MiddleCenter;
            backButton.Click += backButton_Click;
            // 
            // volumeSlider1
            // 
            volumeSlider1.BackColor = Color.White;
            volumeSlider1.Dock = DockStyle.Fill;
            volumeSlider1.Location = new Point(99, 188);
            volumeSlider1.Name = "volumeSlider1";
            volumeSlider1.Size = new Size(762, 65);
            volumeSlider1.TabIndex = 3;
            // 
            // volumeSlider2
            // 
            volumeSlider2.BackColor = Color.White;
            volumeSlider2.Dock = DockStyle.Fill;
            volumeSlider2.Location = new Point(99, 330);
            volumeSlider2.Name = "volumeSlider2";
            volumeSlider2.Size = new Size(762, 65);
            volumeSlider2.TabIndex = 4;
            // 
            // MVLabel
            // 
            MVLabel.AutoSize = true;
            MVLabel.Dock = DockStyle.Fill;
            MVLabel.Location = new Point(99, 114);
            MVLabel.Name = "MVLabel";
            MVLabel.Size = new Size(762, 71);
            MVLabel.TabIndex = 5;
            MVLabel.Text = "Music Volume";
            MVLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SFXVLabel
            // 
            SFXVLabel.AutoSize = true;
            SFXVLabel.Dock = DockStyle.Fill;
            SFXVLabel.Location = new Point(99, 256);
            SFXVLabel.Name = "SFXVLabel";
            SFXVLabel.Size = new Size(762, 71);
            SFXVLabel.TabIndex = 6;
            SFXVLabel.Text = "SFX Volume";
            SFXVLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainLayout);
            Name = "Settings";
            Size = new Size(961, 574);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private Label backButton;
        private NAudio.Gui.VolumeSlider volumeSlider1;
        private NAudio.Gui.VolumeSlider volumeSlider2;
        private Label MVLabel;
        private Label SFXVLabel;
    }
}
