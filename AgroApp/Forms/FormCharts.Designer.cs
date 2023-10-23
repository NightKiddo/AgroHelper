namespace AgroApp.Forms
{
    partial class FormCharts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxXminorGrid = new System.Windows.Forms.CheckBox();
            this.checkBox3D = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewValues = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFields = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFarms = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonAddSeries = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFarm = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.labelField = new System.Windows.Forms.Label();
            this.comboBoxGraphType = new System.Windows.Forms.ComboBox();
            this.labelGraphType = new System.Windows.Forms.Label();
            this.checkBoxYminorGrid = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFarms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.checkBoxYminorGrid);
            this.panel1.Controls.Add(this.checkBoxXminorGrid);
            this.panel1.Controls.Add(this.checkBox3D);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.dataGridViewEmployees);
            this.panel1.Controls.Add(this.dataGridViewValues);
            this.panel1.Controls.Add(this.dataGridViewFields);
            this.panel1.Controls.Add(this.dataGridViewFarms);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.buttonAddSeries);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelFarm);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.labelEmployee);
            this.panel1.Controls.Add(this.labelField);
            this.panel1.Controls.Add(this.comboBoxGraphType);
            this.panel1.Controls.Add(this.labelGraphType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1246, 771);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxXminorGrid
            // 
            this.checkBoxXminorGrid.AutoSize = true;
            this.checkBoxXminorGrid.Location = new System.Drawing.Point(290, 648);
            this.checkBoxXminorGrid.Name = "checkBoxXminorGrid";
            this.checkBoxXminorGrid.Size = new System.Drawing.Size(136, 17);
            this.checkBoxXminorGrid.TabIndex = 26;
            this.checkBoxXminorGrid.Text = "Pomniejsza siatka osi X";
            this.checkBoxXminorGrid.UseVisualStyleBackColor = true;
            this.checkBoxXminorGrid.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // checkBox3D
            // 
            this.checkBox3D.AutoSize = true;
            this.checkBox3D.Location = new System.Drawing.Point(290, 630);
            this.checkBox3D.Name = "checkBox3D";
            this.checkBox3D.Size = new System.Drawing.Size(40, 17);
            this.checkBox3D.TabIndex = 25;
            this.checkBox3D.Text = "3D";
            this.checkBox3D.UseVisualStyleBackColor = true;
            this.checkBox3D.CheckedChanged += new System.EventHandler(this.checkBox3D_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(150, 648);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "Nazwa:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(145, 678);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(117, 20);
            this.textBox2.TabIndex = 23;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(142, 173);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 103);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "Obecna uprawa:";
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
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dataGridViewEmployees.Location = new System.Drawing.Point(16, 437);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.RowHeadersVisible = false;
            this.dataGridViewEmployees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewEmployees.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(120, 103);
            this.dataGridViewEmployees.TabIndex = 21;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "id";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "name";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewValues
            // 
            this.dataGridViewValues.AllowUserToAddRows = false;
            this.dataGridViewValues.AllowUserToDeleteRows = false;
            this.dataGridViewValues.AllowUserToResizeColumns = false;
            this.dataGridViewValues.AllowUserToResizeRows = false;
            this.dataGridViewValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewValues.ColumnHeadersVisible = false;
            this.dataGridViewValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewValues.Location = new System.Drawing.Point(16, 306);
            this.dataGridViewValues.MultiSelect = false;
            this.dataGridViewValues.Name = "dataGridViewValues";
            this.dataGridViewValues.ReadOnly = true;
            this.dataGridViewValues.RowHeadersVisible = false;
            this.dataGridViewValues.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewValues.Size = new System.Drawing.Size(120, 103);
            this.dataGridViewValues.TabIndex = 20;
            // 
            // type
            // 
            this.type.HeaderText = "type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewFields
            // 
            this.dataGridViewFields.AllowUserToAddRows = false;
            this.dataGridViewFields.AllowUserToDeleteRows = false;
            this.dataGridViewFields.AllowUserToResizeColumns = false;
            this.dataGridViewFields.AllowUserToResizeRows = false;
            this.dataGridViewFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFields.ColumnHeadersVisible = false;
            this.dataGridViewFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewFields.Location = new System.Drawing.Point(16, 173);
            this.dataGridViewFields.MultiSelect = false;
            this.dataGridViewFields.Name = "dataGridViewFields";
            this.dataGridViewFields.ReadOnly = true;
            this.dataGridViewFields.RowHeadersVisible = false;
            this.dataGridViewFields.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewFields.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFields.Size = new System.Drawing.Size(120, 103);
            this.dataGridViewFields.TabIndex = 19;
            this.dataGridViewFields.SelectionChanged += new System.EventHandler(this.dataGridViewFields_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewFarms
            // 
            this.dataGridViewFarms.AllowUserToAddRows = false;
            this.dataGridViewFarms.AllowUserToDeleteRows = false;
            this.dataGridViewFarms.AllowUserToResizeColumns = false;
            this.dataGridViewFarms.AllowUserToResizeRows = false;
            this.dataGridViewFarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFarms.ColumnHeadersVisible = false;
            this.dataGridViewFarms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name});
            this.dataGridViewFarms.Location = new System.Drawing.Point(16, 39);
            this.dataGridViewFarms.MultiSelect = false;
            this.dataGridViewFarms.Name = "dataGridViewFarms";
            this.dataGridViewFarms.ReadOnly = true;
            this.dataGridViewFarms.RowHeadersVisible = false;
            this.dataGridViewFarms.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewFarms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewFarms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFarms.Size = new System.Drawing.Size(120, 103);
            this.dataGridViewFarms.TabIndex = 18;
            this.dataGridViewFarms.SelectionChanged += new System.EventHandler(this.dataGridViewFarms_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.HeaderText = "name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 600);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "do:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(55, 604);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(167, 20);
            this.dateTimePicker2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 574);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "od:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(55, 578);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(167, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // buttonAddSeries
            // 
            this.buttonAddSeries.Location = new System.Drawing.Point(16, 726);
            this.buttonAddSeries.Name = "buttonAddSeries";
            this.buttonAddSeries.Size = new System.Drawing.Size(110, 23);
            this.buttonAddSeries.TabIndex = 11;
            this.buttonAddSeries.Text = "Dodaj serię";
            this.buttonAddSeries.UseVisualStyleBackColor = true;
            this.buttonAddSeries.Click += new System.EventHandler(this.buttonAddSeries_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wartości:";
            // 
            // labelFarm
            // 
            this.labelFarm.AutoSize = true;
            this.labelFarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFarm.Location = new System.Drawing.Point(12, 12);
            this.labelFarm.Name = "labelFarm";
            this.labelFarm.Size = new System.Drawing.Size(136, 24);
            this.labelFarm.TabIndex = 8;
            this.labelFarm.Text = "Gospodarstwo:";
            // 
            // chart1
            // 
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(258, 12);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(976, 612);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEmployee.Location = new System.Drawing.Point(12, 410);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(102, 24);
            this.labelEmployee.TabIndex = 5;
            this.labelEmployee.Text = "Pracownik:";
            // 
            // labelField
            // 
            this.labelField.AutoSize = true;
            this.labelField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelField.Location = new System.Drawing.Point(12, 145);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(53, 24);
            this.labelField.TabIndex = 3;
            this.labelField.Text = "Pole:";
            // 
            // comboBoxGraphType
            // 
            this.comboBoxGraphType.FormattingEnabled = true;
            this.comboBoxGraphType.Location = new System.Drawing.Point(17, 679);
            this.comboBoxGraphType.Name = "comboBoxGraphType";
            this.comboBoxGraphType.Size = new System.Drawing.Size(117, 21);
            this.comboBoxGraphType.TabIndex = 1;
            // 
            // labelGraphType
            // 
            this.labelGraphType.AutoSize = true;
            this.labelGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGraphType.Location = new System.Drawing.Point(13, 652);
            this.labelGraphType.Name = "labelGraphType";
            this.labelGraphType.Size = new System.Drawing.Size(86, 24);
            this.labelGraphType.TabIndex = 0;
            this.labelGraphType.Text = "Typ serii:";
            // 
            // checkBoxYminorGrid
            // 
            this.checkBoxYminorGrid.AutoSize = true;
            this.checkBoxYminorGrid.Location = new System.Drawing.Point(290, 671);
            this.checkBoxYminorGrid.Name = "checkBoxYminorGrid";
            this.checkBoxYminorGrid.Size = new System.Drawing.Size(136, 17);
            this.checkBoxYminorGrid.TabIndex = 27;
            this.checkBoxYminorGrid.Text = "Pomniejsza siatka osi X";
            this.checkBoxYminorGrid.UseVisualStyleBackColor = true;
            this.checkBoxYminorGrid.CheckedChanged += new System.EventHandler(this.checkBoxYminorGrid_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 726);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 771);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCharts";
            this.Text = "FormGraphs";
            this.Shown += new System.EventHandler(this.FormGraphs_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFarms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelGraphType;
        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.ComboBox comboBoxGraphType;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonAddSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridViewFarms;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridView dataGridViewFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dataGridViewValues;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox3D;
        private System.Windows.Forms.CheckBox checkBoxXminorGrid;
        private System.Windows.Forms.CheckBox checkBoxYminorGrid;
        private System.Windows.Forms.Button button1;
    }
}