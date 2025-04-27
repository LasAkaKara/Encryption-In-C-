namespace COMP1551
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
            this.Instruction = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numberInput = new System.Windows.Forms.TextBox();
            this.stringInput = new System.Windows.Forms.TextBox();
            this.EncodeButton = new System.Windows.Forms.Button();
            this.print1Button = new System.Windows.Forms.Button();
            this.print2Button = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.notification = new System.Windows.Forms.Label();
            this.AdvancedEncryptButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ShowKeyButton = new System.Windows.Forms.Button();
            this.DecryptWithKeyButton = new System.Windows.Forms.Button();
            this.aesKeyTextBox = new System.Windows.Forms.TextBox();
            this.EncodeResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.encryptedMessageTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Instruction
            // 
            this.Instruction.AutoSize = true;
            this.Instruction.Location = new System.Drawing.Point(41, 38);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(113, 16);
            this.Instruction.TabIndex = 0;
            this.Instruction.Text = "Original Message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Encryption Key for Ceasar Cypher (number only)";
            // 
            // numberInput
            // 
            this.numberInput.Location = new System.Drawing.Point(362, 76);
            this.numberInput.Name = "numberInput";
            this.numberInput.Size = new System.Drawing.Size(327, 22);
            this.numberInput.TabIndex = 4;
            // 
            // stringInput
            // 
            this.stringInput.Location = new System.Drawing.Point(362, 32);
            this.stringInput.Name = "stringInput";
            this.stringInput.Size = new System.Drawing.Size(327, 22);
            this.stringInput.TabIndex = 5;
            // 
            // EncodeButton
            // 
            this.EncodeButton.Location = new System.Drawing.Point(712, 72);
            this.EncodeButton.Name = "EncodeButton";
            this.EncodeButton.Size = new System.Drawing.Size(139, 23);
            this.EncodeButton.TabIndex = 7;
            this.EncodeButton.Text = "Basic Encrypt";
            this.EncodeButton.UseVisualStyleBackColor = true;
            this.EncodeButton.Click += new System.EventHandler(this.EncodeButton_Click);
            // 
            // print1Button
            // 
            this.print1Button.Location = new System.Drawing.Point(44, 207);
            this.print1Button.Name = "print1Button";
            this.print1Button.Size = new System.Drawing.Size(119, 23);
            this.print1Button.TabIndex = 8;
            this.print1Button.Text = "Orginal ASCII";
            this.print1Button.UseVisualStyleBackColor = true;
            this.print1Button.Click += new System.EventHandler(this.print1Button_Click);
            // 
            // print2Button
            // 
            this.print2Button.Location = new System.Drawing.Point(178, 207);
            this.print2Button.Name = "print2Button";
            this.print2Button.Size = new System.Drawing.Size(127, 23);
            this.print2Button.TabIndex = 9;
            this.print2Button.Text = "Encrypted ASCII";
            this.print2Button.UseVisualStyleBackColor = true;
            this.print2Button.Click += new System.EventHandler(this.print2Button_Click);
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(556, 207);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(70, 23);
            this.SortButton.TabIndex = 10;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // notification
            // 
            this.notification.AutoSize = true;
            this.notification.ForeColor = System.Drawing.Color.Red;
            this.notification.Location = new System.Drawing.Point(41, 243);
            this.notification.Name = "notification";
            this.notification.Size = new System.Drawing.Size(0, 16);
            this.notification.TabIndex = 11;
            // 
            // AdvancedEncryptButton
            // 
            this.AdvancedEncryptButton.Location = new System.Drawing.Point(712, 113);
            this.AdvancedEncryptButton.Name = "AdvancedEncryptButton";
            this.AdvancedEncryptButton.Size = new System.Drawing.Size(139, 23);
            this.AdvancedEncryptButton.TabIndex = 12;
            this.AdvancedEncryptButton.Text = "Advanced Encrypt";
            this.AdvancedEncryptButton.UseVisualStyleBackColor = true;
            this.AdvancedEncryptButton.Click += new System.EventHandler(this.AdvancedEncryptButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(463, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // ShowKeyButton
            // 
            this.ShowKeyButton.Location = new System.Drawing.Point(320, 207);
            this.ShowKeyButton.Name = "ShowKeyButton";
            this.ShowKeyButton.Size = new System.Drawing.Size(128, 23);
            this.ShowKeyButton.TabIndex = 14;
            this.ShowKeyButton.Text = "Show AES Key";
            this.ShowKeyButton.UseVisualStyleBackColor = true;
            this.ShowKeyButton.Click += new System.EventHandler(this.ShowKeyButton_Click);
            // 
            // DecryptWithKeyButton
            // 
            this.DecryptWithKeyButton.Location = new System.Drawing.Point(712, 156);
            this.DecryptWithKeyButton.Name = "DecryptWithKeyButton";
            this.DecryptWithKeyButton.Size = new System.Drawing.Size(139, 23);
            this.DecryptWithKeyButton.TabIndex = 15;
            this.DecryptWithKeyButton.Text = "Decrypt from Key";
            this.DecryptWithKeyButton.UseVisualStyleBackColor = true;
            this.DecryptWithKeyButton.Click += new System.EventHandler(this.DecryptWithKeyButton_Click);
            // 
            // aesKeyTextBox
            // 
            this.aesKeyTextBox.Location = new System.Drawing.Point(362, 114);
            this.aesKeyTextBox.Name = "aesKeyTextBox";
            this.aesKeyTextBox.Size = new System.Drawing.Size(327, 22);
            this.aesKeyTextBox.TabIndex = 16;
            // 
            // EncodeResult
            // 
            this.EncodeResult.Location = new System.Drawing.Point(44, 272);
            this.EncodeResult.Multiline = true;
            this.EncodeResult.Name = "EncodeResult";
            this.EncodeResult.ReadOnly = true;
            this.EncodeResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EncodeResult.Size = new System.Drawing.Size(804, 135);
            this.EncodeResult.TabIndex = 17;
            this.EncodeResult.Text = "Result";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Encryption Key for Advanced Encryption";
            // 
            // encryptedMessageTextBox
            // 
            this.encryptedMessageTextBox.Location = new System.Drawing.Point(362, 156);
            this.encryptedMessageTextBox.Name = "encryptedMessageTextBox";
            this.encryptedMessageTextBox.Size = new System.Drawing.Size(327, 22);
            this.encryptedMessageTextBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "AES Encrypted Message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 422);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.encryptedMessageTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EncodeResult);
            this.Controls.Add(this.aesKeyTextBox);
            this.Controls.Add(this.DecryptWithKeyButton);
            this.Controls.Add(this.ShowKeyButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AdvancedEncryptButton);
            this.Controls.Add(this.notification);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.print2Button);
            this.Controls.Add(this.print1Button);
            this.Controls.Add(this.EncodeButton);
            this.Controls.Add(this.stringInput);
            this.Controls.Add(this.numberInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Instruction);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Instruction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numberInput;
        private System.Windows.Forms.TextBox stringInput;
        private System.Windows.Forms.Button EncodeButton;
        private System.Windows.Forms.Button print1Button;
        private System.Windows.Forms.Button print2Button;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Label notification;
        private System.Windows.Forms.Button AdvancedEncryptButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ShowKeyButton;
        private System.Windows.Forms.Button DecryptWithKeyButton;
        private System.Windows.Forms.TextBox aesKeyTextBox;
        private System.Windows.Forms.TextBox EncodeResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox encryptedMessageTextBox;
        private System.Windows.Forms.Label label3;
    }
}

