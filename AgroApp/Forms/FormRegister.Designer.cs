namespace AgroApp.Forms
{
    partial class FormRegister
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.MaskedTextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.powrótToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Controls.Add(this.textBoxLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 426);
            this.panel1.TabIndex = 0;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogin.Location = new System.Drawing.Point(97, 226);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(240, 64);
            this.buttonLogin.TabIndex = 12;
            this.buttonLogin.Text = "Zarejestruj";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(92, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hasło:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(95, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Login:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(180, 160);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(165, 20);
            this.textBoxPassword.TabIndex = 9;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(180, 118);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(165, 20);
            this.textBoxLogin.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.powrótToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // powrótToolStripMenuItem
            // 
            this.powrótToolStripMenuItem.Name = "powrótToolStripMenuItem";
            this.powrótToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.powrótToolStripMenuItem.Text = "Powrót";
            this.powrótToolStripMenuItem.Click += new System.EventHandler(this.powrótToolStripMenuItem_Click);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRegister";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem powrótToolStripMenuItem;
    }
}