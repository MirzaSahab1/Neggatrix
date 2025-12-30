namespace Neggatrix.Scenes
{
    partial class Tutorial
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
            storyTextBox = new RichTextBox();
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
            mainLayout.Controls.Add(storyTextBox, 1, 1);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainLayout.Size = new Size(1028, 626);
            mainLayout.TabIndex = 2;
            mainLayout.Resize += mainLayout_Resize;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Location = new Point(105, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(816, 125);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Tutorial";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.Dock = DockStyle.Fill;
            backButton.Location = new Point(3, 0);
            backButton.Name = "backButton";
            backButton.Size = new Size(96, 125);
            backButton.TabIndex = 2;
            backButton.Text = "←";
            backButton.TextAlign = ContentAlignment.MiddleCenter;
            backButton.Click += backButton_Click;
            // 
            // storyTextBox
            // 
            storyTextBox.BackColor = Color.DarkSlateGray;
            storyTextBox.Dock = DockStyle.Fill;
            storyTextBox.Location = new Point(102, 125);
            storyTextBox.Margin = new Padding(0);
            storyTextBox.Name = "storyTextBox";
            storyTextBox.ReadOnly = true;
            storyTextBox.Size = new Size(822, 501);
            storyTextBox.TabIndex = 3;
            storyTextBox.Text = "";
            // 
            // Tutorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainLayout);
            Name = "Tutorial";
            Size = new Size(1028, 626);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private Label backButton;
        private RichTextBox storyTextBox;
    }
}
