namespace Neggatrix.Scenes
{
    partial class LevelsScreen
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
            buttonsPanel = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            mainLayout.SuspendLayout();
            buttonsPanel.SuspendLayout();
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
            mainLayout.Controls.Add(buttonsPanel, 1, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 4;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            mainLayout.Size = new Size(813, 528);
            mainLayout.TabIndex = 1;
            mainLayout.Resize += mainLayout_Resize;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Location = new Point(84, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(644, 105);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Levels";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.Dock = DockStyle.Fill;
            backButton.Location = new Point(3, 0);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 105);
            backButton.TabIndex = 2;
            backButton.Text = "←";
            backButton.TextAlign = ContentAlignment.MiddleCenter;
            backButton.Click += backButton_Click;
            // 
            // buttonsPanel
            // 
            buttonsPanel.ColumnCount = 5;
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            buttonsPanel.Controls.Add(button1, 0, 0);
            buttonsPanel.Controls.Add(button2, 1, 0);
            buttonsPanel.Controls.Add(button3, 2, 0);
            buttonsPanel.Controls.Add(button4, 3, 0);
            buttonsPanel.Controls.Add(button5, 4, 0);
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.Location = new Point(81, 237);
            buttonsPanel.Margin = new Padding(0);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.RowCount = 1;
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            buttonsPanel.Size = new Size(650, 105);
            buttonsPanel.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(5, 5);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(120, 95);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(135, 5);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(120, 95);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(265, 5);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.Size = new Size(120, 95);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Red;
            button4.Dock = DockStyle.Fill;
            button4.Location = new Point(395, 5);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Size = new Size(120, 95);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.Dock = DockStyle.Fill;
            button5.Location = new Point(525, 5);
            button5.Margin = new Padding(5);
            button5.Name = "button5";
            button5.Size = new Size(120, 95);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = false;
            // 
            // LevelsScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainLayout);
            Name = "LevelsScreen";
            Size = new Size(813, 528);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private Label backButton;
        private TableLayoutPanel buttonsPanel;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}
