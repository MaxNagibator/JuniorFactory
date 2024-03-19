namespace JuniorFactory.Lesson2
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiReadButton = new System.Windows.Forms.Button();
            this.uiWriteButton = new System.Windows.Forms.Button();
            this.uiDataTextBox = new System.Windows.Forms.TextBox();
            this.uiHitPointTextBox = new System.Windows.Forms.TextBox();
            this.uiManaPointTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiBattleButton = new System.Windows.Forms.Button();
            this.uiRelaxButton = new System.Windows.Forms.Button();
            this.uiSaveGameButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiSaveSlot1RadioButton = new System.Windows.Forms.RadioButton();
            this.uiSaveSlot2RadioButton = new System.Windows.Forms.RadioButton();
            this.uiSaveSlot3RadioButton = new System.Windows.Forms.RadioButton();
            this.uiLoadGameButton = new System.Windows.Forms.Button();
            this.uiStaminaPointProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiReadButton
            // 
            this.uiReadButton.Location = new System.Drawing.Point(12, 12);
            this.uiReadButton.Name = "uiReadButton";
            this.uiReadButton.Size = new System.Drawing.Size(207, 23);
            this.uiReadButton.TabIndex = 0;
            this.uiReadButton.Text = "считать фаил";
            this.uiReadButton.UseVisualStyleBackColor = true;
            this.uiReadButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uiReadButton_MouseClick);
            // 
            // uiWriteButton
            // 
            this.uiWriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiWriteButton.Location = new System.Drawing.Point(12, 75);
            this.uiWriteButton.Name = "uiWriteButton";
            this.uiWriteButton.Size = new System.Drawing.Size(207, 23);
            this.uiWriteButton.TabIndex = 1;
            this.uiWriteButton.Text = "записать";
            this.uiWriteButton.UseVisualStyleBackColor = true;
            this.uiWriteButton.Click += new System.EventHandler(this.uiWriteButton_Click);
            // 
            // uiDataTextBox
            // 
            this.uiDataTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDataTextBox.Location = new System.Drawing.Point(234, 43);
            this.uiDataTextBox.Name = "uiDataTextBox";
            this.uiDataTextBox.Size = new System.Drawing.Size(439, 20);
            this.uiDataTextBox.TabIndex = 2;
            // 
            // uiHitPointTextBox
            // 
            this.uiHitPointTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHitPointTextBox.Location = new System.Drawing.Point(204, 218);
            this.uiHitPointTextBox.Name = "uiHitPointTextBox";
            this.uiHitPointTextBox.Size = new System.Drawing.Size(439, 20);
            this.uiHitPointTextBox.TabIndex = 3;
            // 
            // uiManaPointTextBox
            // 
            this.uiManaPointTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiManaPointTextBox.Location = new System.Drawing.Point(204, 244);
            this.uiManaPointTextBox.Name = "uiManaPointTextBox";
            this.uiManaPointTextBox.Size = new System.Drawing.Size(439, 20);
            this.uiManaPointTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "hp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "mana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "stamina";
            // 
            // uiBattleButton
            // 
            this.uiBattleButton.Location = new System.Drawing.Point(12, 218);
            this.uiBattleButton.Name = "uiBattleButton";
            this.uiBattleButton.Size = new System.Drawing.Size(111, 39);
            this.uiBattleButton.TabIndex = 9;
            this.uiBattleButton.Text = "подраться";
            this.uiBattleButton.UseVisualStyleBackColor = true;
            this.uiBattleButton.Click += new System.EventHandler(this.uiBattleButton_Click);
            // 
            // uiRelaxButton
            // 
            this.uiRelaxButton.Location = new System.Drawing.Point(12, 263);
            this.uiRelaxButton.Name = "uiRelaxButton";
            this.uiRelaxButton.Size = new System.Drawing.Size(111, 39);
            this.uiRelaxButton.TabIndex = 10;
            this.uiRelaxButton.Text = "отдохнуть";
            this.uiRelaxButton.UseVisualStyleBackColor = true;
            this.uiRelaxButton.Click += new System.EventHandler(this.uiRelaxButton_Click);
            // 
            // uiSaveGameButton
            // 
            this.uiSaveGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiSaveGameButton.Location = new System.Drawing.Point(12, 326);
            this.uiSaveGameButton.Name = "uiSaveGameButton";
            this.uiSaveGameButton.Size = new System.Drawing.Size(207, 23);
            this.uiSaveGameButton.TabIndex = 11;
            this.uiSaveGameButton.Text = "сохранить игру";
            this.uiSaveGameButton.UseVisualStyleBackColor = true;
            this.uiSaveGameButton.Click += new System.EventHandler(this.uiSaveGameButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiSaveSlot3RadioButton);
            this.groupBox1.Controls.Add(this.uiSaveSlot2RadioButton);
            this.groupBox1.Controls.Add(this.uiSaveSlot1RadioButton);
            this.groupBox1.Location = new System.Drawing.Point(234, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // uiSaveSlot1RadioButton
            // 
            this.uiSaveSlot1RadioButton.AutoSize = true;
            this.uiSaveSlot1RadioButton.Checked = true;
            this.uiSaveSlot1RadioButton.Location = new System.Drawing.Point(6, 17);
            this.uiSaveSlot1RadioButton.Name = "uiSaveSlot1RadioButton";
            this.uiSaveSlot1RadioButton.Size = new System.Drawing.Size(52, 17);
            this.uiSaveSlot1RadioButton.TabIndex = 0;
            this.uiSaveSlot1RadioButton.TabStop = true;
            this.uiSaveSlot1RadioButton.Text = "Slot 1";
            this.uiSaveSlot1RadioButton.UseVisualStyleBackColor = true;
            // 
            // uiSaveSlot2RadioButton
            // 
            this.uiSaveSlot2RadioButton.AutoSize = true;
            this.uiSaveSlot2RadioButton.Location = new System.Drawing.Point(6, 40);
            this.uiSaveSlot2RadioButton.Name = "uiSaveSlot2RadioButton";
            this.uiSaveSlot2RadioButton.Size = new System.Drawing.Size(52, 17);
            this.uiSaveSlot2RadioButton.TabIndex = 1;
            this.uiSaveSlot2RadioButton.Text = "Slot 2";
            this.uiSaveSlot2RadioButton.UseVisualStyleBackColor = true;
            // 
            // uiSaveSlot3RadioButton
            // 
            this.uiSaveSlot3RadioButton.AutoSize = true;
            this.uiSaveSlot3RadioButton.Location = new System.Drawing.Point(6, 63);
            this.uiSaveSlot3RadioButton.Name = "uiSaveSlot3RadioButton";
            this.uiSaveSlot3RadioButton.Size = new System.Drawing.Size(52, 17);
            this.uiSaveSlot3RadioButton.TabIndex = 2;
            this.uiSaveSlot3RadioButton.Text = "Slot 3";
            this.uiSaveSlot3RadioButton.UseVisualStyleBackColor = true;
            // 
            // uiLoadGameButton
            // 
            this.uiLoadGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiLoadGameButton.Location = new System.Drawing.Point(12, 355);
            this.uiLoadGameButton.Name = "uiLoadGameButton";
            this.uiLoadGameButton.Size = new System.Drawing.Size(207, 23);
            this.uiLoadGameButton.TabIndex = 13;
            this.uiLoadGameButton.Text = "загрузить игру";
            this.uiLoadGameButton.UseVisualStyleBackColor = true;
            this.uiLoadGameButton.Click += new System.EventHandler(this.uiLoadGameButton_Click);
            // 
            // uiStaminaPointProgressBar
            // 
            this.uiStaminaPointProgressBar.Location = new System.Drawing.Point(204, 270);
            this.uiStaminaPointProgressBar.Name = "uiStaminaPointProgressBar";
            this.uiStaminaPointProgressBar.Size = new System.Drawing.Size(439, 23);
            this.uiStaminaPointProgressBar.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 421);
            this.Controls.Add(this.uiStaminaPointProgressBar);
            this.Controls.Add(this.uiLoadGameButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uiSaveGameButton);
            this.Controls.Add(this.uiRelaxButton);
            this.Controls.Add(this.uiBattleButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiManaPointTextBox);
            this.Controls.Add(this.uiHitPointTextBox);
            this.Controls.Add(this.uiDataTextBox);
            this.Controls.Add(this.uiWriteButton);
            this.Controls.Add(this.uiReadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uiReadButton;
        private System.Windows.Forms.Button uiWriteButton;
        private System.Windows.Forms.TextBox uiDataTextBox;
        private System.Windows.Forms.TextBox uiHitPointTextBox;
        private System.Windows.Forms.TextBox uiManaPointTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button uiBattleButton;
        private System.Windows.Forms.Button uiRelaxButton;
        private System.Windows.Forms.Button uiSaveGameButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton uiSaveSlot3RadioButton;
        private System.Windows.Forms.RadioButton uiSaveSlot2RadioButton;
        private System.Windows.Forms.RadioButton uiSaveSlot1RadioButton;
        private System.Windows.Forms.Button uiLoadGameButton;
        private System.Windows.Forms.ProgressBar uiStaminaPointProgressBar;
    }
}

