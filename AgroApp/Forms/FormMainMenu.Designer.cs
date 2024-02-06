namespace AgroApp.Forms
{
    partial class FormMainMenu
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
            this.buttonDeleteEmployee = new System.Windows.Forms.Button();
            this.buttonAddEmployee = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.employeeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewFarms = new System.Windows.Forms.DataGridView();
            this.buttonAddFarm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFarms)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDeleteEmployee);
            this.panel1.Controls.Add(this.buttonAddEmployee);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.buttonAddFarm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // buttonDeleteEmployee
            // 
            this.buttonDeleteEmployee.Location = new System.Drawing.Point(39, 364);
            this.buttonDeleteEmployee.Name = "buttonDeleteEmployee";
            this.buttonDeleteEmployee.Size = new System.Drawing.Size(123, 42);
            this.buttonDeleteEmployee.TabIndex = 5;
            this.buttonDeleteEmployee.Text = "Usuń pracownika";
            this.buttonDeleteEmployee.UseVisualStyleBackColor = true;
            this.buttonDeleteEmployee.Click += new System.EventHandler(this.buttonDeleteEmployee_Click);
            // 
            // buttonAddEmployee
            // 
            this.buttonAddEmployee.Location = new System.Drawing.Point(39, 316);
            this.buttonAddEmployee.Name = "buttonAddEmployee";
            this.buttonAddEmployee.Size = new System.Drawing.Size(123, 42);
            this.buttonAddEmployee.TabIndex = 4;
            this.buttonAddEmployee.Text = "Dodaj pracownika";
            this.buttonAddEmployee.UseVisualStyleBackColor = true;
            this.buttonAddEmployee.Click += new System.EventHandler(this.buttonAddEmployee_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewEmployees);
            this.panel3.Location = new System.Drawing.Point(206, 298);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 140);
            this.panel3.TabIndex = 3;
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.AllowUserToDeleteRows = false;
            this.dataGridViewEmployees.AllowUserToResizeColumns = false;
            this.dataGridViewEmployees.AllowUserToResizeRows = false;
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.ColumnHeadersVisible = false;
            this.dataGridViewEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeid,
            this.employeeName});
            this.dataGridViewEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.RowHeadersVisible = false;
            this.dataGridViewEmployees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(582, 140);
            this.dataGridViewEmployees.TabIndex = 0;
            // 
            // employeeid
            // 
            this.employeeid.HeaderText = "id";
            this.employeeid.Name = "employeeid";
            this.employeeid.ReadOnly = true;
            this.employeeid.Visible = false;
            // 
            // employeeName
            // 
            this.employeeName.HeaderText = "name";
            this.employeeName.Name = "employeeName";
            this.employeeName.ReadOnly = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(39, 78);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(123, 42);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Usuń gospodarstwo";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridViewFarms);
            this.panel2.Location = new System.Drawing.Point(206, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 280);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewFarms
            // 
            this.dataGridViewFarms.AllowUserToAddRows = false;
            this.dataGridViewFarms.AllowUserToDeleteRows = false;
            this.dataGridViewFarms.AllowUserToResizeColumns = false;
            this.dataGridViewFarms.AllowUserToResizeRows = false;
            this.dataGridViewFarms.ColumnHeadersVisible = false;
            this.dataGridViewFarms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFarms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridViewFarms.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFarms.MultiSelect = false;
            this.dataGridViewFarms.Name = "dataGridViewFarms";
            this.dataGridViewFarms.ReadOnly = true;
            this.dataGridViewFarms.RowHeadersVisible = false;
            this.dataGridViewFarms.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewFarms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFarms.Size = new System.Drawing.Size(582, 280);
            this.dataGridViewFarms.TabIndex = 0;
            this.dataGridViewFarms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridViewFarms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // buttonAddFarm
            // 
            this.buttonAddFarm.Location = new System.Drawing.Point(39, 30);
            this.buttonAddFarm.Name = "buttonAddFarm";
            this.buttonAddFarm.Size = new System.Drawing.Size(123, 42);
            this.buttonAddFarm.TabIndex = 0;
            this.buttonAddFarm.Text = "Dodaj gospodarstwo";
            this.buttonAddFarm.UseVisualStyleBackColor = true;
            this.buttonAddFarm.Click += new System.EventHandler(this.buttonAddFarm_Click);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMainMenu";
            this.Text = "FormMainMenu";
            this.Shown += new System.EventHandler(this.FormMainMenu_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFarms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddFarm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewFarms;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.Button buttonDeleteEmployee;
        private System.Windows.Forms.Button buttonAddEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
    }
}