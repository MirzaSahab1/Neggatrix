namespace Neggatrix.Scenes
{
    partial class GamePlay
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
            hudLayout = new TableLayoutPanel();
            score = new Label();
            level = new Label();
            info = new Label();
            hudLayout.SuspendLayout();
            SuspendLayout();
            // 
            // hudLayout
            // 
            hudLayout.BackColor = Color.Transparent;
            hudLayout.ColumnCount = 3;
            hudLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            hudLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            hudLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            hudLayout.Controls.Add(score, 0, 0);
            hudLayout.Controls.Add(level, 1, 0);
            hudLayout.Controls.Add(info, 2, 0);
            hudLayout.Dock = DockStyle.Top;
            hudLayout.Location = new Point(0, 0);
            hudLayout.Name = "hudLayout";
            hudLayout.RowCount = 1;
            hudLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            hudLayout.Size = new Size(1056, 41);
            hudLayout.TabIndex = 0;
            // 
            // score
            // 
            score.AutoSize = true;
            score.Dock = DockStyle.Fill;
            score.ForeColor = Color.White;
            score.Location = new Point(0, 0);
            score.Margin = new Padding(0);
            score.Name = "score";
            score.Size = new Size(264, 50);
            score.TabIndex = 0;
            score.Text = "label1";
            score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // level
            // 
            level.AutoSize = true;
            level.Dock = DockStyle.Fill;
            level.ForeColor = Color.White;
            level.Location = new Point(264, 0);
            level.Margin = new Padding(0);
            level.Name = "level";
            level.Size = new Size(528, 50);
            level.TabIndex = 1;
            level.Text = "label2";
            level.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Dock = DockStyle.Fill;
            info.ForeColor = Color.White;
            info.Location = new Point(792, 0);
            info.Margin = new Padding(0);
            info.Name = "info";
            info.Size = new Size(264, 50);
            info.TabIndex = 2;
            info.Text = "label3";
            info.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GamePlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Gemini_Generated_Image_ngstlgngstlgngst;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(hudLayout);
            DoubleBuffered = true;
            Name = "GamePlay";
            Size = new Size(1056, 660);
            hudLayout.ResumeLayout(false);
            hudLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel hudLayout;
        public Label score;
        public Label level;
        public Label info;
    }
}
