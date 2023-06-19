namespace AgroApp.Forms
{
    partial class FormAddField
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.webView21);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 501);
            this.panel1.TabIndex = 0;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExit.Location = new System.Drawing.Point(589, 456);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(181, 33);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Zakończ";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNext.Location = new System.Drawing.Point(304, 455);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(181, 33);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Dalej";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAdd.Location = new System.Drawing.Point(19, 455);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(181, 34);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Dodaj pole";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(3, 3);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(794, 375);
            this.webView21.TabIndex = 0;
            this.webView21.ZoomFactor = 1D;
            this.webView21.WebMessageReceived += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs>(this.webView21_WebMessageReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(19, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nazwa:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 412);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(300, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Opis:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(361, 381);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(409, 69);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // FormAddField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.panel1);
            this.Name = "FormAddField";
            this.Text = "FormAddField";
            this.Load += new System.EventHandler(this.FormAddField_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}