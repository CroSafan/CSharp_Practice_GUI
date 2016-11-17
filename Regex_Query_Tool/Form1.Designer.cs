namespace Regex_Query_Tool
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
            this.checkRegexButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stringToCheckTextBox = new System.Windows.Forms.TextBox();
            this.regExToCheckTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkRegexButton
            // 
            this.checkRegexButton.Location = new System.Drawing.Point(65, 149);
            this.checkRegexButton.Name = "checkRegexButton";
            this.checkRegexButton.Size = new System.Drawing.Size(126, 23);
            this.checkRegexButton.TabIndex = 0;
            this.checkRegexButton.Text = "Check";
            this.checkRegexButton.UseVisualStyleBackColor = true;
            this.checkRegexButton.Click += new System.EventHandler(this.checkRegexButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "String to check";
            // 
            // stringToCheckTextBox
            // 
            this.stringToCheckTextBox.Location = new System.Drawing.Point(65, 61);
            this.stringToCheckTextBox.Name = "stringToCheckTextBox";
            this.stringToCheckTextBox.Size = new System.Drawing.Size(126, 20);
            this.stringToCheckTextBox.TabIndex = 2;
            // 
            // regExToCheckTextBox
            // 
            this.regExToCheckTextBox.Location = new System.Drawing.Point(65, 110);
            this.regExToCheckTextBox.Name = "regExToCheckTextBox";
            this.regExToCheckTextBox.Size = new System.Drawing.Size(126, 20);
            this.regExToCheckTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Regular expression";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(79, 206);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(100, 20);
            this.resultTextBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 262);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regExToCheckTextBox);
            this.Controls.Add(this.stringToCheckTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkRegexButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Regex Query Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkRegexButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stringToCheckTextBox;
        private System.Windows.Forms.TextBox regExToCheckTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox resultTextBox;
    }
}

