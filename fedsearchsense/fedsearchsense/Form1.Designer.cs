
namespace fedsearchsense
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.skeetGroupBox1 = new SkeetUI.skeetGroupBox();
            this.skeetGroupBox2 = new SkeetUI.skeetGroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.skeetGroupBox4 = new SkeetUI.skeetGroupBox();
            this.shadowLabel1 = new SkeetUI.shadowLabel();
            this.skeetButton1 = new SkeetUI.skeetButton();
            this.skeetTextBox1 = new SkeetFramework.SkeetTextBox();
            this.skeetGroupBox3 = new SkeetUI.skeetGroupBox();
            this.skeetButton2 = new SkeetUI.skeetButton();
            this.skeetTextBox2 = new SkeetFramework.SkeetTextBox();
            this.shadowLabel2 = new SkeetUI.shadowLabel();
            this.skeetGroupBox1.SuspendLayout();
            this.skeetGroupBox2.SuspendLayout();
            this.skeetGroupBox4.SuspendLayout();
            this.skeetGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // skeetGroupBox1
            // 
            this.skeetGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.skeetGroupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skeetGroupBox1.BackgroundImage")));
            this.skeetGroupBox1.ButtonText = "FedSense";
            this.skeetGroupBox1.Controls.Add(this.skeetGroupBox2);
            this.skeetGroupBox1.Controls.Add(this.skeetGroupBox4);
            this.skeetGroupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.skeetGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.skeetGroupBox1.Name = "skeetGroupBox1";
            this.skeetGroupBox1.Size = new System.Drawing.Size(480, 332);
            this.skeetGroupBox1.TabIndex = 0;
            // 
            // skeetGroupBox2
            // 
            this.skeetGroupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skeetGroupBox2.BackgroundImage")));
            this.skeetGroupBox2.ButtonText = "Result";
            this.skeetGroupBox2.Controls.Add(this.richTextBox1);
            this.skeetGroupBox2.Location = new System.Drawing.Point(8, 163);
            this.skeetGroupBox2.Name = "skeetGroupBox2";
            this.skeetGroupBox2.Size = new System.Drawing.Size(467, 156);
            this.skeetGroupBox2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.richTextBox1.Location = new System.Drawing.Point(8, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(452, 146);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = " ";
            // 
            // skeetGroupBox4
            // 
            this.skeetGroupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skeetGroupBox4.BackgroundImage")));
            this.skeetGroupBox4.ButtonText = "Options";
            this.skeetGroupBox4.Controls.Add(this.shadowLabel2);
            this.skeetGroupBox4.Controls.Add(this.skeetTextBox2);
            this.skeetGroupBox4.Controls.Add(this.shadowLabel1);
            this.skeetGroupBox4.Controls.Add(this.skeetButton1);
            this.skeetGroupBox4.Controls.Add(this.skeetTextBox1);
            this.skeetGroupBox4.Location = new System.Drawing.Point(8, 17);
            this.skeetGroupBox4.Name = "skeetGroupBox4";
            this.skeetGroupBox4.Size = new System.Drawing.Size(467, 140);
            this.skeetGroupBox4.TabIndex = 4;
            // 
            // shadowLabel1
            // 
            this.shadowLabel1.AutoSize = true;
            this.shadowLabel1.EnableShadow = false;
            this.shadowLabel1.Location = new System.Drawing.Point(9, 58);
            this.shadowLabel1.Name = "shadowLabel1";
            this.shadowLabel1.ShadowColor = System.Drawing.Color.LightGray;
            this.shadowLabel1.ShadowOffset = 1;
            this.shadowLabel1.Size = new System.Drawing.Size(41, 13);
            this.shadowLabel1.TabIndex = 2;
            this.shadowLabel1.Text = "Search";
            // 
            // skeetButton1
            // 
            this.skeetButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skeetButton1.BackgroundImage")));
            this.skeetButton1.ButtonEnabled = true;
            this.skeetButton1.ButtonText = "Search";
            this.skeetButton1.Location = new System.Drawing.Point(9, 103);
            this.skeetButton1.Name = "skeetButton1";
            this.skeetButton1.Size = new System.Drawing.Size(450, 25);
            this.skeetButton1.TabIndex = 1;
            this.skeetButton1.Load += new System.EventHandler(this.skeetButton1_Load);
            this.skeetButton1.Click += new System.EventHandler(this.skeetButton1_Click_1);
            // 
            // skeetTextBox1
            // 
            this.skeetTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.skeetTextBox1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.skeetTextBox1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.skeetTextBox1.FocusOnHover = false;
            this.skeetTextBox1.Location = new System.Drawing.Point(9, 74);
            this.skeetTextBox1.MaxLength = 32767;
            this.skeetTextBox1.Multiline = false;
            this.skeetTextBox1.Name = "skeetTextBox1";
            this.skeetTextBox1.ReadOnly = false;
            this.skeetTextBox1.Size = new System.Drawing.Size(450, 23);
            this.skeetTextBox1.TabIndex = 0;
            this.skeetTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.skeetTextBox1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.skeetTextBox1.UseSystemPasswordChar = false;
            // 
            // skeetGroupBox3
            // 
            this.skeetGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.skeetGroupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skeetGroupBox3.BackgroundImage")));
            this.skeetGroupBox3.ButtonText = "Extras";
            this.skeetGroupBox3.Controls.Add(this.skeetButton2);
            this.skeetGroupBox3.Location = new System.Drawing.Point(12, 350);
            this.skeetGroupBox3.Name = "skeetGroupBox3";
            this.skeetGroupBox3.Size = new System.Drawing.Size(480, 65);
            this.skeetGroupBox3.TabIndex = 1;
            // 
            // skeetButton2
            // 
            this.skeetButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skeetButton2.BackgroundImage")));
            this.skeetButton2.ButtonEnabled = true;
            this.skeetButton2.ButtonText = "Generate Bobux";
            this.skeetButton2.Location = new System.Drawing.Point(19, 19);
            this.skeetButton2.Name = "skeetButton2";
            this.skeetButton2.Size = new System.Drawing.Size(438, 31);
            this.skeetButton2.TabIndex = 1;
            this.skeetButton2.Click += new System.EventHandler(this.skeetButton2_Click);
            // 
            // skeetTextBox2
            // 
            this.skeetTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.skeetTextBox2.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.skeetTextBox2.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.skeetTextBox2.FocusOnHover = false;
            this.skeetTextBox2.Location = new System.Drawing.Point(8, 32);
            this.skeetTextBox2.MaxLength = 32767;
            this.skeetTextBox2.Multiline = false;
            this.skeetTextBox2.Name = "skeetTextBox2";
            this.skeetTextBox2.ReadOnly = false;
            this.skeetTextBox2.Size = new System.Drawing.Size(450, 23);
            this.skeetTextBox2.TabIndex = 3;
            this.skeetTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.skeetTextBox2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.skeetTextBox2.UseSystemPasswordChar = false;
            // 
            // shadowLabel2
            // 
            this.shadowLabel2.AutoSize = true;
            this.shadowLabel2.EnableShadow = false;
            this.shadowLabel2.Location = new System.Drawing.Point(6, 16);
            this.shadowLabel2.Name = "shadowLabel2";
            this.shadowLabel2.ShadowColor = System.Drawing.Color.LightGray;
            this.shadowLabel2.ShadowOffset = 1;
            this.shadowLabel2.Size = new System.Drawing.Size(45, 13);
            this.shadowLabel2.TabIndex = 4;
            this.shadowLabel2.Text = "API Key";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(504, 426);
            this.Controls.Add(this.skeetGroupBox3);
            this.Controls.Add(this.skeetGroupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.skeetGroupBox1.ResumeLayout(false);
            this.skeetGroupBox2.ResumeLayout(false);
            this.skeetGroupBox4.ResumeLayout(false);
            this.skeetGroupBox4.PerformLayout();
            this.skeetGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SkeetUI.skeetGroupBox skeetGroupBox1;
        private SkeetUI.skeetGroupBox skeetGroupBox2;
        private SkeetUI.skeetGroupBox skeetGroupBox3;
        private SkeetUI.skeetButton skeetButton2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private SkeetUI.skeetGroupBox skeetGroupBox4;
        private SkeetFramework.SkeetTextBox skeetTextBox1;
        private SkeetUI.skeetButton skeetButton1;
        private SkeetUI.shadowLabel shadowLabel1;
        private SkeetUI.shadowLabel shadowLabel2;
        private SkeetFramework.SkeetTextBox skeetTextBox2;
    }
}

