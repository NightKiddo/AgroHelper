namespace AgroApp.Forms
{
    partial class FormShowFarm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewStorages = new System.Windows.Forms.DataGridView();
            this.idStorage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameStorage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridViewFields = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 607);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewStorages);
            this.panel3.Location = new System.Drawing.Point(409, 499);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 108);
            this.panel3.TabIndex = 1;
            // 
            // dataGridViewStorages
            // 
            this.dataGridViewStorages.AllowUserToAddRows = false;
            this.dataGridViewStorages.AllowUserToDeleteRows = false;
            this.dataGridViewStorages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStorages.ColumnHeadersVisible = false;
            this.dataGridViewStorages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idStorage,
            this.nameStorage});
            this.dataGridViewStorages.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStorages.Name = "dataGridViewStorages";
            this.dataGridViewStorages.ReadOnly = true;
            this.dataGridViewStorages.RowHeadersVisible = false;
            this.dataGridViewStorages.Size = new System.Drawing.Size(391, 108);
            this.dataGridViewStorages.TabIndex = 0;
            // 
            // idStorage
            // 
            this.idStorage.HeaderText = "Column1";
            this.idStorage.Name = "idStorage";
            this.idStorage.ReadOnly = true;
            this.idStorage.Visible = false;
            // 
            // nameStorage
            // 
            this.nameStorage.HeaderText = "Column1";
            this.nameStorage.Name = "nameStorage";
            this.nameStorage.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.dataGridViewFields);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 607);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonEdit);
            this.panel4.Controls.Add(this.buttonDelete);
            this.panel4.Controls.Add(this.buttonAdd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 493);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(407, 114);
            this.panel4.TabIndex = 1;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEdit.Location = new System.Drawing.Point(0, 76);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(407, 38);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "EDYTUJ";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDelete.Location = new System.Drawing.Point(0, 38);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(407, 38);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "USUŃ";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdd.Location = new System.Drawing.Point(0, 0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(407, 38);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "DODAJ";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridViewFields
            // 
            this.dataGridViewFields.AllowUserToAddRows = false;
            this.dataGridViewFields.AllowUserToDeleteRows = false;
            this.dataGridViewFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFields.ColumnHeadersVisible = false;
            this.dataGridViewFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.ColumnDescription,
            this.Plant});
            this.dataGridViewFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewFields.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFields.Name = "dataGridViewFields";
            this.dataGridViewFields.ReadOnly = true;
            this.dataGridViewFields.RowHeadersVisible = false;
            this.dataGridViewFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFields.Size = new System.Drawing.Size(407, 493);
            this.dataGridViewFields.TabIndex = 0;
            this.dataGridViewFields.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "Column1";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.HeaderText = "Column1";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            // 
            // Plant
            // 
            this.Plant.HeaderText = "Plant";
            this.Plant.Name = "Plant";
            this.Plant.ReadOnly = true;
            // 
            // FormShowFarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 607);
            this.Controls.Add(this.panel1);
            this.Name = "FormShowFarm";
            this.Text = "FormShowFarm";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewFields;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewStorages;
        private System.Windows.Forms.DataGridViewTextBoxColumn idStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameStorage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plant;
    }
}