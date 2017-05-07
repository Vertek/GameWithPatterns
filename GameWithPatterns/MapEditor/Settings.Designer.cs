namespace MapEditor
{
    partial class Settings
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
            this.Colors = new System.Windows.Forms.ComboBox();
            this.colorHint = new System.Windows.Forms.Panel();
            this.SaveSettings = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Colors
            // 
            this.Colors.FormattingEnabled = true;
            this.Colors.Location = new System.Drawing.Point(12, 12);
            this.Colors.Name = "Colors";
            this.Colors.Size = new System.Drawing.Size(157, 21);
            this.Colors.TabIndex = 0;
            this.Colors.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // colorHint
            // 
            this.colorHint.Location = new System.Drawing.Point(171, 13);
            this.colorHint.Name = "colorHint";
            this.colorHint.Size = new System.Drawing.Size(27, 19);
            this.colorHint.TabIndex = 1;
            // 
            // SaveSettings
            // 
            this.SaveSettings.Location = new System.Drawing.Point(12, 217);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(75, 23);
            this.SaveSettings.TabIndex = 2;
            this.SaveSettings.Text = "Apply";
            this.SaveSettings.UseVisualStyleBackColor = true;
            this.SaveSettings.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(435, 217);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 252);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.SaveSettings);
            this.Controls.Add(this.colorHint);
            this.Controls.Add(this.Colors);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Colors;
        private System.Windows.Forms.Panel colorHint;
        private System.Windows.Forms.Button SaveSettings;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}