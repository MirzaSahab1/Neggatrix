namespace Neggatrix.Scenes
{
    partial class MessageBox
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
            actionButton = new Button();
            exitButton = new Button();
            messageLabel = new Label();
            mainLayout.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(tableLayoutPanel1, 0, 1);
            mainLayout.Controls.Add(messageLabel, 0, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainLayout.Size = new Size(498, 351);
            mainLayout.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(actionButton, 0, 0);
            tableLayoutPanel1.Controls.Add(exitButton, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 280);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(498, 71);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // actionButton
            // 
            actionButton.BackColor = SystemColors.ActiveCaptionText;
            actionButton.Dock = DockStyle.Fill;
            actionButton.Location = new Point(3, 3);
            actionButton.Name = "actionButton";
            actionButton.Size = new Size(243, 65);
            actionButton.TabIndex = 0;
            actionButton.Text = "Exit";
            actionButton.UseVisualStyleBackColor = false;
            actionButton.Click += actionButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = SystemColors.ActiveCaptionText;
            exitButton.Dock = DockStyle.Fill;
            exitButton.Location = new Point(252, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(243, 65);
            exitButton.TabIndex = 1;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Dock = DockStyle.Fill;
            messageLabel.Location = new Point(0, 0);
            messageLabel.Margin = new Padding(0);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(498, 280);
            messageLabel.TabIndex = 1;
            messageLabel.Text = "Message";
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainLayout);
            Name = "MessageBox";
            Size = new Size(498, 351);
            Load += MessageBox_Load;
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel tableLayoutPanel1;
        private Button actionButton;
        public Button exitButton;
        private Label messageLabel;
    }
}
