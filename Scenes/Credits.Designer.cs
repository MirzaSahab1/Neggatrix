namespace Neggatrix.Scenes
{
    partial class Credits
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
            tableLayoutPanel1 = new TableLayoutPanel();
            headingOneLabel = new Label();
            nameLabel = new Label();
            headingTwoLabel = new Label();
            sourceLabel = new Label();
            titleLabel = new Label();
            backButton = new Label();
            mainLayout.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 3;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            mainLayout.Controls.Add(tableLayoutPanel1, 1, 1);
            mainLayout.Controls.Add(titleLabel, 1, 0);
            mainLayout.Controls.Add(backButton, 0, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainLayout.Size = new Size(897, 584);
            mainLayout.TabIndex = 0;
            mainLayout.Resize += mainLayout_Resize;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(headingOneLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(nameLabel, 2, 1);
            tableLayoutPanel1.Controls.Add(headingTwoLabel, 1, 2);
            tableLayoutPanel1.Controls.Add(sourceLabel, 2, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(92, 119);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(711, 462);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // headingOneLabel
            // 
            headingOneLabel.AutoSize = true;
            headingOneLabel.Dock = DockStyle.Fill;
            headingOneLabel.Location = new Point(38, 46);
            headingOneLabel.Name = "headingOneLabel";
            headingOneLabel.Size = new Size(313, 184);
            headingOneLabel.TabIndex = 0;
            headingOneLabel.Text = "Programmer / Designer:";
            headingOneLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Dock = DockStyle.Fill;
            nameLabel.Location = new Point(357, 46);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(313, 184);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Mirza Talal Ahmed";
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headingTwoLabel
            // 
            headingTwoLabel.AutoSize = true;
            headingTwoLabel.Dock = DockStyle.Fill;
            headingTwoLabel.Location = new Point(38, 230);
            headingTwoLabel.Name = "headingTwoLabel";
            headingTwoLabel.Size = new Size(313, 184);
            headingTwoLabel.TabIndex = 2;
            headingTwoLabel.Text = "Assets:";
            headingTwoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sourceLabel
            // 
            sourceLabel.AutoSize = true;
            sourceLabel.Dock = DockStyle.Fill;
            sourceLabel.Location = new Point(357, 230);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new Size(313, 184);
            sourceLabel.TabIndex = 3;
            sourceLabel.Text = "Internet";
            sourceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Location = new Point(92, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(711, 116);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Credits";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.Dock = DockStyle.Fill;
            backButton.Location = new Point(3, 0);
            backButton.Name = "backButton";
            backButton.Size = new Size(83, 116);
            backButton.TabIndex = 2;
            backButton.Text = "←";
            backButton.TextAlign = ContentAlignment.MiddleCenter;
            backButton.Click += backButton_Click;
            // 
            // Credits
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(mainLayout);
            Name = "Credits";
            Size = new Size(897, 584);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel tableLayoutPanel1;
        private Label headingOneLabel;
        private Label titleLabel;
        private Label nameLabel;
        private Label headingTwoLabel;
        private Label sourceLabel;
        private Label backButton;
    }
}
