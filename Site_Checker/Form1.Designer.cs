﻿namespace Site_Checker
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
            this.checkWebSiteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkWebSiteButton
            // 
            this.checkWebSiteButton.Location = new System.Drawing.Point(106, 153);
            this.checkWebSiteButton.Name = "checkWebSiteButton";
            this.checkWebSiteButton.Size = new System.Drawing.Size(75, 23);
            this.checkWebSiteButton.TabIndex = 0;
            this.checkWebSiteButton.Text = "Check";
            this.checkWebSiteButton.UseMnemonic = false;
            this.checkWebSiteButton.UseVisualStyleBackColor = true;
            this.checkWebSiteButton.Click += new System.EventHandler(this.checkWebSiteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.checkWebSiteButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Site checker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button checkWebSiteButton;
    }
}

