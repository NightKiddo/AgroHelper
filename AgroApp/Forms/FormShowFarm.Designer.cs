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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridViewJournal = new System.Windows.Forms.DataGridView();
            this.contextMenuStripJournal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pracęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notatkęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pracownikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewGarages = new System.Windows.Forms.DataGridView();
            this.dataGridViewStorages = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewFields = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wróćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripGarages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripStorages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFields = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournal)).BeginInit();
            this.contextMenuStripJournal.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGarages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripGarages.SuspendLayout();
            this.contextMenuStripStorages.SuspendLayout();
            this.contextMenuStripFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 607);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(413, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridViewJournal);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(407, 49);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(470, 444);
            this.panel5.TabIndex = 2;
            // 
            // dataGridViewJournal
            // 
            this.dataGridViewJournal.AllowUserToAddRows = false;
            this.dataGridViewJournal.AllowUserToDeleteRows = false;
            this.dataGridViewJournal.AllowUserToResizeColumns = false;
            this.dataGridViewJournal.AllowUserToResizeRows = false;
            this.dataGridViewJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJournal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.type,
            this.deleteColumn});
            this.dataGridViewJournal.ContextMenuStrip = this.contextMenuStripJournal;
            this.dataGridViewJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewJournal.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewJournal.Name = "dataGridViewJournal";
            this.dataGridViewJournal.ReadOnly = true;
            this.dataGridViewJournal.RowHeadersVisible = false;
            this.dataGridViewJournal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewJournal.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewJournal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewJournal.Size = new System.Drawing.Size(470, 444);
            this.dataGridViewJournal.TabIndex = 0;
            this.dataGridViewJournal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewJournal_MouseClick);
            this.dataGridViewJournal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewJournal_MouseDoubleClick);
            // 
            // contextMenuStripJournal
            // 
            this.contextMenuStripJournal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem,
            this.usuńToolStripMenuItem1});
            this.contextMenuStripJournal.Name = "contextMenuStrip1";
            this.contextMenuStripJournal.Size = new System.Drawing.Size(106, 48);
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pracęToolStripMenuItem,
            this.notatkęToolStripMenuItem,
            this.pracownikaToolStripMenuItem});
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            // 
            // pracęToolStripMenuItem
            // 
            this.pracęToolStripMenuItem.Name = "pracęToolStripMenuItem";
            this.pracęToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.pracęToolStripMenuItem.Text = "Pracę";
            this.pracęToolStripMenuItem.Click += new System.EventHandler(this.pracęToolStripMenuItem_Click);
            // 
            // notatkęToolStripMenuItem
            // 
            this.notatkęToolStripMenuItem.Name = "notatkęToolStripMenuItem";
            this.notatkęToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.notatkęToolStripMenuItem.Text = "Notatkę";
            this.notatkęToolStripMenuItem.Click += new System.EventHandler(this.notatkęToolStripMenuItem_Click);
            // 
            // pracownikaToolStripMenuItem
            // 
            this.pracownikaToolStripMenuItem.Name = "pracownikaToolStripMenuItem";
            this.pracownikaToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.pracownikaToolStripMenuItem.Text = "Pracownika";
            this.pracownikaToolStripMenuItem.Click += new System.EventHandler(this.pracownikaToolStripMenuItem_Click);
            // 
            // usuńToolStripMenuItem1
            // 
            this.usuńToolStripMenuItem1.Name = "usuńToolStripMenuItem1";
            this.usuńToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.usuńToolStripMenuItem1.Text = "Usuń";
            this.usuńToolStripMenuItem1.Click += new System.EventHandler(this.usuńToolStripMenuItem1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewGarages);
            this.panel3.Controls.Add(this.dataGridViewStorages);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(407, 493);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(470, 114);
            this.panel3.TabIndex = 1;
            // 
            // dataGridViewGarages
            // 
            this.dataGridViewGarages.AllowUserToAddRows = false;
            this.dataGridViewGarages.AllowUserToDeleteRows = false;
            this.dataGridViewGarages.AllowUserToResizeColumns = false;
            this.dataGridViewGarages.AllowUserToResizeRows = false;
            this.dataGridViewGarages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGarages.ColumnHeadersVisible = false;
            this.dataGridViewGarages.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewGarages.Location = new System.Drawing.Point(236, 0);
            this.dataGridViewGarages.MultiSelect = false;
            this.dataGridViewGarages.Name = "dataGridViewGarages";
            this.dataGridViewGarages.ReadOnly = true;
            this.dataGridViewGarages.RowHeadersVisible = false;
            this.dataGridViewGarages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewGarages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewGarages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGarages.Size = new System.Drawing.Size(234, 114);
            this.dataGridViewGarages.TabIndex = 1;
            this.dataGridViewGarages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGarages_CellDoubleClick);
            this.dataGridViewGarages.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewGarages_MouseClick);
            // 
            // dataGridViewStorages
            // 
            this.dataGridViewStorages.AllowUserToAddRows = false;
            this.dataGridViewStorages.AllowUserToDeleteRows = false;
            this.dataGridViewStorages.AllowUserToResizeColumns = false;
            this.dataGridViewStorages.AllowUserToResizeRows = false;
            this.dataGridViewStorages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStorages.ColumnHeadersVisible = false;
            this.dataGridViewStorages.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewStorages.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStorages.MultiSelect = false;
            this.dataGridViewStorages.Name = "dataGridViewStorages";
            this.dataGridViewStorages.ReadOnly = true;
            this.dataGridViewStorages.RowHeadersVisible = false;
            this.dataGridViewStorages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewStorages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewStorages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStorages.Size = new System.Drawing.Size(232, 114);
            this.dataGridViewStorages.TabIndex = 0;
            this.dataGridViewStorages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStorages_CellDoubleClick);
            this.dataGridViewStorages.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewStorages_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.dataGridViewFields);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 607);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 517);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(407, 90);
            this.panel4.TabIndex = 1;
            // 
            // dataGridViewFields
            // 
            this.dataGridViewFields.AllowUserToAddRows = false;
            this.dataGridViewFields.AllowUserToDeleteRows = false;
            this.dataGridViewFields.AllowUserToResizeColumns = false;
            this.dataGridViewFields.AllowUserToResizeRows = false;
            this.dataGridViewFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFields.ColumnHeadersVisible = false;
            this.dataGridViewFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewFields.Location = new System.Drawing.Point(0, 24);
            this.dataGridViewFields.MultiSelect = false;
            this.dataGridViewFields.Name = "dataGridViewFields";
            this.dataGridViewFields.ReadOnly = true;
            this.dataGridViewFields.RowHeadersVisible = false;
            this.dataGridViewFields.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFields.Size = new System.Drawing.Size(407, 493);
            this.dataGridViewFields.TabIndex = 0;
            this.dataGridViewFields.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridViewFields.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewFields_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wróćToolStripMenuItem,
            this.analizaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(407, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // wróćToolStripMenuItem
            // 
            this.wróćToolStripMenuItem.Name = "wróćToolStripMenuItem";
            this.wróćToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.wróćToolStripMenuItem.Text = "Wróć";
            this.wróćToolStripMenuItem.Click += new System.EventHandler(this.wróćToolStripMenuItem_Click);
            // 
            // analizaToolStripMenuItem
            // 
            this.analizaToolStripMenuItem.Name = "analizaToolStripMenuItem";
            this.analizaToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.analizaToolStripMenuItem.Text = "Analiza";
            this.analizaToolStripMenuItem.Click += new System.EventHandler(this.analizaToolStripMenuItem_Click);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "id";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "name";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "start_date";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "finish_date";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "field";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // contextMenuStripGarages
            // 
            this.contextMenuStripGarages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem1});
            this.contextMenuStripGarages.Name = "contextMenuStripGarages";
            this.contextMenuStripGarages.Size = new System.Drawing.Size(106, 26);
            // 
            // dodajToolStripMenuItem1
            // 
            this.dodajToolStripMenuItem1.Name = "dodajToolStripMenuItem1";
            this.dodajToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.dodajToolStripMenuItem1.Text = "Dodaj";
            this.dodajToolStripMenuItem1.Click += new System.EventHandler(this.dodajToolStripMenuItem1_Click);
            // 
            // contextMenuStripStorages
            // 
            this.contextMenuStripStorages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem2});
            this.contextMenuStripStorages.Name = "contextMenuStripStorages";
            this.contextMenuStripStorages.Size = new System.Drawing.Size(106, 26);
            // 
            // dodajToolStripMenuItem2
            // 
            this.dodajToolStripMenuItem2.Name = "dodajToolStripMenuItem2";
            this.dodajToolStripMenuItem2.Size = new System.Drawing.Size(105, 22);
            this.dodajToolStripMenuItem2.Text = "Dodaj";
            this.dodajToolStripMenuItem2.Click += new System.EventHandler(this.dodajToolStripMenuItem2_Click);
            // 
            // contextMenuStripFields
            // 
            this.contextMenuStripFields.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem3,
            this.usuńToolStripMenuItem});
            this.contextMenuStripFields.Name = "contextMenuStripFields";
            this.contextMenuStripFields.Size = new System.Drawing.Size(106, 48);
            // 
            // dodajToolStripMenuItem3
            // 
            this.dodajToolStripMenuItem3.Name = "dodajToolStripMenuItem3";
            this.dodajToolStripMenuItem3.Size = new System.Drawing.Size(105, 22);
            this.dodajToolStripMenuItem3.Text = "Dodaj";
            this.dodajToolStripMenuItem3.Click += new System.EventHandler(this.dodajToolStripMenuItem3_Click);
            // 
            // usuńToolStripMenuItem
            // 
            this.usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            this.usuńToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.usuńToolStripMenuItem.Text = "Usuń";
            this.usuńToolStripMenuItem.Click += new System.EventHandler(this.usuńToolStripMenuItem_Click);
            // 
            // Column10
            // 
            this.Column10.HeaderText = "id";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "tytul";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "od";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "do";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "pole";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // type
            // 
            this.type.HeaderText = "typ";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // deleteColumn
            // 
            this.deleteColumn.HeaderText = "Column1";
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.ReadOnly = true;
            this.deleteColumn.Visible = false;
            // 
            // FormShowFarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 607);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShowFarm";
            this.Text = "FormShowFarm";
            this.Shown += new System.EventHandler(this.FormShowFarm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournal)).EndInit();
            this.contextMenuStripJournal.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGarages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripGarages.ResumeLayout(false);
            this.contextMenuStripStorages.ResumeLayout(false);
            this.contextMenuStripFields.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewFields;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewGarages;
        private System.Windows.Forms.DataGridView dataGridViewStorages;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridView dataGridViewJournal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripJournal;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pracęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notatkęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pracownikaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGarages;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStorages;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFields;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wróćToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteColumn;
    }
}