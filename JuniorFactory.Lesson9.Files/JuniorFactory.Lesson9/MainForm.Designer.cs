namespace JuniorFactory.Lesson9
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hardDiskComboBox = new ComboBox();
            startButton = new Button();
            stopButton = new Button();
            treeView1 = new TreeView();
            uiLogsTextBox = new TextBox();
            SuspendLayout();
            // 
            // hardDiskComboBox
            // 
            hardDiskComboBox.FormattingEnabled = true;
            hardDiskComboBox.Location = new Point(12, 12);
            hardDiskComboBox.Name = "hardDiskComboBox";
            hardDiskComboBox.Size = new Size(203, 23);
            hardDiskComboBox.TabIndex = 0;
            // 
            // startButton
            // 
            startButton.Location = new Point(12, 41);
            startButton.Name = "startButton";
            startButton.Size = new Size(203, 23);
            startButton.TabIndex = 1;
            startButton.Text = "start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(12, 70);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(203, 23);
            stopButton.TabIndex = 2;
            stopButton.Text = "stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.Location = new Point(221, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(596, 533);
            treeView1.TabIndex = 3;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            // 
            // uiLogsTextBox
            // 
            uiLogsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiLogsTextBox.Location = new Point(12, 99);
            uiLogsTextBox.Multiline = true;
            uiLogsTextBox.Name = "uiLogsTextBox";
            uiLogsTextBox.ScrollBars = ScrollBars.Vertical;
            uiLogsTextBox.Size = new Size(203, 446);
            uiLogsTextBox.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 557);
            Controls.Add(uiLogsTextBox);
            Controls.Add(treeView1);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Controls.Add(hardDiskComboBox);
            Name = "MainForm";
            Text = "SpaceSnoop";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox hardDiskComboBox;
        private Button startButton;
        private Button stopButton;
        private TreeView treeView1;
        private TextBox uiLogsTextBox;
    }
}
