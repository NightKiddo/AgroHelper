namespace AgroApp.Forms
{
    partial class FormGraphs
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
            this.labelGraphType = new System.Windows.Forms.Label();
            this.comboBoxGraphType = new System.Windows.Forms.ComboBox();
            this.listBoxField = new System.Windows.Forms.ListBox();
            this.labelField = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.listBoxEmployee = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelEmployee);
            this.panel1.Controls.Add(this.listBoxEmployee);
            this.panel1.Controls.Add(this.labelField);
            this.panel1.Controls.Add(this.listBoxField);
            this.panel1.Controls.Add(this.comboBoxGraphType);
            this.panel1.Controls.Add(this.labelGraphType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 575);
            this.panel1.TabIndex = 0;
            // 
            // labelGraphType
            // 
            this.labelGraphType.AutoSize = true;
            this.labelGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGraphType.Location = new System.Drawing.Point(12, 9);
            this.labelGraphType.Name = "labelGraphType";
            this.labelGraphType.Size = new System.Drawing.Size(121, 24);
            this.labelGraphType.TabIndex = 0;
            this.labelGraphType.Text = "Typ wykresu:";
            // 
            // comboBoxGraphType
            // 
            this.comboBoxGraphType.FormattingEnabled = true;
            this.comboBoxGraphType.Location = new System.Drawing.Point(16, 36);
            this.comboBoxGraphType.Name = "comboBoxGraphType";
            this.comboBoxGraphType.Size = new System.Drawing.Size(117, 21);
            this.comboBoxGraphType.TabIndex = 1;
            // 
            // listBoxField
            // 
            this.listBoxField.FormattingEnabled = true;
            this.listBoxField.Location = new System.Drawing.Point(16, 101);
            this.listBoxField.Name = "listBoxField";
            this.listBoxField.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxField.Size = new System.Drawing.Size(120, 95);
            this.listBoxField.TabIndex = 2;
            // 
            // labelField
            // 
            this.labelField.AutoSize = true;
            this.labelField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelField.Location = new System.Drawing.Point(15, 74);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(53, 24);
            this.labelField.TabIndex = 3;
            this.labelField.Text = "Pole:";
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEmployee.Location = new System.Drawing.Point(15, 220);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(102, 24);
            this.labelEmployee.TabIndex = 5;
            this.labelEmployee.Text = "Pracownik:";
            // 
            // listBoxEmployee
            // 
            this.listBoxEmployee.FormattingEnabled = true;
            this.listBoxEmployee.Location = new System.Drawing.Point(16, 247);
            this.listBoxEmployee.Name = "listBoxEmployee";
            this.listBoxEmployee.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxEmployee.Size = new System.Drawing.Size(120, 95);
            this.listBoxEmployee.TabIndex = 4;
            // 
            // FormGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 575);
            this.Controls.Add(this.panel1);
            this.Name = "FormGraphs";
            this.Text = "FormGraphs";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelGraphType;
        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.ListBox listBoxField;
        private System.Windows.Forms.ComboBox comboBoxGraphType;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.ListBox listBoxEmployee;
    }
}