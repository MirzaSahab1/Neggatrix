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
            tableLayoutPanel1 = new TableLayoutPanel();
            score = new Label();
            level = new Label();
            info = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Controls.Add(score, 0, 0);
            tableLayoutPanel1.Controls.Add(level, 1, 0);
            tableLayoutPanel1.Controls.Add(info, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(1056, 41);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // score
            // 
            score.AutoSize = true;
            score.Dock = DockStyle.Fill;
            score.ForeColor = Color.White;
            score.Location = new Point(0, 0);
            score.Margin = new Padding(0);
            score.Name = "score";
            score.Size = new Size(158, 50);
            score.TabIndex = 0;
            score.Text = "label1";
            score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // level
            // 
            level.AutoSize = true;
            level.Dock = DockStyle.Fill;
            level.ForeColor = Color.White;
            level.Location = new Point(158, 0);
            level.Margin = new Padding(0);
            level.Name = "level";
            level.Size = new Size(739, 50);
            level.TabIndex = 1;
            level.Text = "label2";
            level.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Dock = DockStyle.Fill;
            info.ForeColor = Color.White;
            info.Location = new Point(897, 0);
            info.Margin = new Padding(0);
            info.Name = "info";
            info.Size = new Size(159, 50);
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
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            Name = "GamePlay";
            Size = new Size(1056, 660);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        public Label score;
        public Label level;
        public Label info;
    }
}
