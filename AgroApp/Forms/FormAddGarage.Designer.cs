namespace AgroApp.Forms
{
    partial class FormAddGarage
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
            this.buttonEnd = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonEnd);
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 171);
            this.panel1.TabIndex = 0;
            // 
            // buttonEnd
            // 
            this.buttonEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEnd.Location = new System.Drawing.Point(152, 111);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(75, 32);
            this.buttonEnd.TabIndex = 4;
            this.buttonEnd.Text = "Zakończ";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNext.Location = new System.Drawing.Point(152, 73);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 32);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "Dalej";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwa garażu:";
            // 
            // FormAddGarage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 171);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddGarage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddGarage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonEnd;
    }
}