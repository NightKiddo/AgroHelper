namespace AgroApp.Forms
{
    partial class FormShowTool
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
            this.dataGridViewActivities = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelType = new System.Windows.Forms.Label();
            this.labelMileage = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.powrótToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivities)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewActivities);
            this.panel1.Controls.Add(this.labelType);
            this.panel1.Controls.Add(this.labelMileage);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 498);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewActivities
            // 
            this.dataGridViewActivities.AllowUserToAddRows = false;
            this.dataGridViewActivities.AllowUserToDeleteRows = false;
            this.dataGridViewActivities.AllowUserToResizeRows = false;
            this.dataGridViewActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActivities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridViewActivities.Location = new System.Drawing.Point(12, 216);
            this.dataGridViewActivities.Name = "dataGridViewActivities";
            this.dataGridViewActivities.ReadOnly = true;
            this.dataGridViewActivities.RowHeadersVisible = false;
            this.dataGridViewActivities.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActivities.Size = new System.Drawing.Size(776, 268);
            this.dataGridViewActivities.TabIndex = 31;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "tytul";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "typ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "od";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "do";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ilosc";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelType.Location = new System.Drawing.Point(21, 124);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(70, 26);
            this.labelType.TabIndex = 29;
            this.labelType.Text = "label3";
            // 
            // labelMileage
            // 
            this.labelMileage.AutoSize = true;
            this.labelMileage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMileage.Location = new System.Drawing.Point(21, 71);
            this.labelMileage.Name = "labelMileage";
            this.labelMileage.Size = new System.Drawing.Size(70, 26);
            this.labelMileage.TabIndex = 28;
            this.labelMileage.Text = "label2";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.Location = new System.Drawing.Point(21, 18);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(70, 26);
            this.labelName.TabIndex = 27;
            this.labelName.Text = "label1";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEdit.Location = new System.Drawing.Point(25, 165);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 45);
            this.buttonEdit.TabIndex = 26;
            this.buttonEdit.Text = "Edytuj";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.LightCoral;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDelete.Location = new System.Drawing.Point(106, 165);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 45);
            this.buttonDelete.TabIndex = 25;
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.powrótToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            // FormShowTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShowTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormShowTool";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivities)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewActivities;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelMileage;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem powrótToolStripMenuItem;
    }
}