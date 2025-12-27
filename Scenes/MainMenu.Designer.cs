namespace Neggatrix.Scenes
{
    partial class MainMenu
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
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonsPanel = new TableLayoutPanel();
            startButton = new Label();
            levelsButton = new Label();
            settingsButton = new Label();
            creditsButton = new Label();
            exitButton = new Label();
            mainLayout.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.BackgroundImageLayout = ImageLayout.Stretch;
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            mainLayout.Controls.Add(titleLabel, 0, 0);
            mainLayout.Controls.Add(tableLayoutPanel1, 0, 1);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            mainLayout.Size = new Size(831, 555);
            mainLayout.TabIndex = 1;
            mainLayout.Resize += mainLayout_Resize;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Curlz MT", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(3, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(492, 111);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "WHISPERS OF THE GLOOMWOOD";
            titleLabel.TextAlign = ContentAlignment.BottomRight;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.52632F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.1578941F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.31579F));
            tableLayoutPanel1.Controls.Add(buttonsPanel, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 111);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new Size(498, 444);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonsPanel
            // 
            buttonsPanel.BackColor = Color.Transparent;
            buttonsPanel.ColumnCount = 1;
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            buttonsPanel.Controls.Add(startButton, 0, 0);
            buttonsPanel.Controls.Add(levelsButton, 0, 1);
            buttonsPanel.Controls.Add(settingsButton, 0, 2);
            buttonsPanel.Controls.Add(creditsButton, 0, 3);
            buttonsPanel.Controls.Add(exitButton, 0, 4);
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.Location = new Point(52, 22);
            buttonsPanel.Margin = new Padding(0);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.RowCount = 5;
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            buttonsPanel.Size = new Size(314, 399);
            buttonsPanel.TabIndex = 7;
            // 
            // startButton
            // 
            startButton.AutoSize = true;
            startButton.Dock = DockStyle.Fill;
            startButton.Font = new Font("Curlz MT", 36F);
            startButton.ForeColor = Color.White;
            startButton.Location = new Point(0, 0);
            startButton.Margin = new Padding(0);
            startButton.Name = "startButton";
            startButton.Size = new Size(314, 79);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.TextAlign = ContentAlignment.MiddleCenter;
            startButton.Click += startButton_Click;
            // 
            // levelsButton
            // 
            levelsButton.AutoSize = true;
            levelsButton.Dock = DockStyle.Fill;
            levelsButton.Font = new Font("Curlz MT", 36F);
            levelsButton.ForeColor = Color.White;
            levelsButton.Location = new Point(0, 79);
            levelsButton.Margin = new Padding(0);
            levelsButton.Name = "levelsButton";
            levelsButton.Size = new Size(314, 79);
            levelsButton.TabIndex = 1;
            levelsButton.Text = "Levels";
            levelsButton.TextAlign = ContentAlignment.MiddleCenter;
            levelsButton.Click += levelsButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.AutoSize = true;
            settingsButton.Dock = DockStyle.Fill;
            settingsButton.Font = new Font("Curlz MT", 36F);
            settingsButton.ForeColor = Color.White;
            settingsButton.Location = new Point(0, 158);
            settingsButton.Margin = new Padding(0);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(314, 79);
            settingsButton.TabIndex = 2;
            settingsButton.Text = "Settings";
            settingsButton.TextAlign = ContentAlignment.MiddleCenter;
            settingsButton.Click += settingsButton_Click;
            // 
            // creditsButton
            // 
            creditsButton.AutoSize = true;
            creditsButton.Dock = DockStyle.Fill;
            creditsButton.Font = new Font("Curlz MT", 36F);
            creditsButton.ForeColor = Color.White;
            creditsButton.Location = new Point(0, 237);
            creditsButton.Margin = new Padding(0);
            creditsButton.Name = "creditsButton";
            creditsButton.Size = new Size(314, 79);
            creditsButton.TabIndex = 3;
            creditsButton.Text = "Credits";
            creditsButton.TextAlign = ContentAlignment.MiddleCenter;
            creditsButton.Click += creditsButton_Click;
            // 
            // exitButton
            // 
            exitButton.AutoSize = true;
            exitButton.Dock = DockStyle.Fill;
            exitButton.Font = new Font("Curlz MT", 36F);
            exitButton.ForeColor = Color.White;
            exitButton.Location = new Point(0, 316);
            exitButton.Margin = new Padding(0);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(314, 83);
            exitButton.TabIndex = 4;
            exitButton.Text = "Exit Game";
            exitButton.TextAlign = ContentAlignment.MiddleCenter;
            exitButton.Click += exitButton_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainLayout);
            Name = "MainMenu";
            Size = new Size(831, 555);
            mainLayout.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            buttonsPanel.ResumeLayout(false);
            buttonsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel buttonsPanel;
        private Label startButton;
        private Label levelsButton;
        private Label settingsButton;
        private Label creditsButton;
        private Label exitButton;
    }
}
