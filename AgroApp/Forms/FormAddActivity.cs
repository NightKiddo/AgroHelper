using AgroApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Forms
{
    public partial class FormAddActivity : Form
    {
        Farm farm;
        DBOperator dboperator = FormBase.dboperator;
        public FormAddActivity(Farm farm)
        {
            InitializeComponent();
            this.farm = farm;
            loadFields();
            loadTypes();
            loadEmployees();
            loadMachines();
            loadTools();
            loadResources();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearDataGridViewSelections()
        {
            dataGridViewType.ClearSelection();
            dataGridViewField.ClearSelection();
            dataGridViewEmployee.ClearSelection();
            dataGridViewMachine.ClearSelection();
            dataGridViewTool.ClearSelection();
            dataGridViewResource.ClearSelection();
        }

        private void loadFields() 
        {
            dataGridViewField.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = farm.FieldsList;
            dataGridViewField.DataSource = source;


            dataGridViewField.Columns[0].Visible = false;
            dataGridViewField.Columns[2].Visible = false;
            dataGridViewField.Columns[3].Visible = false;
            dataGridViewField.Columns[1].Width = (int)(dataGridViewField.Width * 0.33);
            dataGridViewField.Columns[4].Width = (int)(dataGridViewField.Width * 0.33);
            dataGridViewField.Columns[5].Width = (int)(dataGridViewField.Width * 0.33);
            
        }

        private void loadTypes()
        {
            dataGridViewType.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = dboperator.activityTypesCollection;
            dataGridViewType.DataSource = source;

            dataGridViewType.Columns[0].Visible = false;
            dataGridViewType.Columns[1].Width = dataGridViewField.Width;

            
        }
        private void loadEmployees() 
        {
            dataGridViewEmployee.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = dboperator.user.EmployeesList;
            dataGridViewEmployee.DataSource = source;

            dataGridViewEmployee.Columns[0].Visible = false;
            dataGridViewEmployee.Columns[1].Width = dataGridViewField.Width;

            
        }

        private void loadMachines() 
        {
            dataGridViewMachine.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = farm.getAllMachines();
            dataGridViewMachine.DataSource = source;

            dataGridViewMachine.Columns[0].Visible = false;
            dataGridViewMachine.Columns[2].Visible = false;
            dataGridViewMachine.Columns[4].Visible = false;
            dataGridViewMachine.Columns[5].Visible = false;
            dataGridViewMachine.Columns[1].Width = (int)(dataGridViewField.Width * 0.6);
            dataGridViewMachine.Columns[3].Width = (int)(dataGridViewField.Width * 0.4);

            
        }

        private void loadTools()
        {
            dataGridViewTool.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = farm.getAllTools();
            dataGridViewTool.DataSource = source;
            dataGridViewTool.Columns[0].Visible = false;
            dataGridViewTool.Columns[1].Width = dataGridViewField.Width;

            
        }

        private void loadResources()
        {
            dataGridViewResource.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = farm.getAllResources();
            dataGridViewResource.DataSource = source;

            dataGridViewResource.Columns[0].Visible = false;            
            dataGridViewResource.Columns[1].Width = (int)(dataGridViewResource.Width * 0.34);
            dataGridViewResource.Columns[2].Width = (int)(dataGridViewResource.Width * 0.33);
            dataGridViewResource.Columns[3].Width = (int)(dataGridViewResource.Width * 0.33);

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewField.SelectedRows.Count != 0)
            {
                int chosenField = (int)(dataGridViewField.SelectedRows[0].Cells[0].Value);
                int chosenType = (int)(dataGridViewType.SelectedRows[0].Cells[0].Value);
                object chosenEmployee, chosenMachine, chosenTool, value;
                if (dataGridViewEmployee.SelectedRows.Count == 0)
                {
                    chosenEmployee = "NULL";
                }
                else 
                {
                    chosenEmployee = (int)(dataGridViewEmployee.SelectedRows[0].Cells[0].Value);
                }

                if (dataGridViewMachine.SelectedRows.Count == 0)
                {
                    chosenMachine = "NULL";
                }
                else
                {
                    chosenMachine = (int)(dataGridViewMachine.SelectedRows[0].Cells[0].Value);
                }

                if (dataGridViewTool.SelectedRows.Count == 0)
                {
                    chosenTool = "NULL";
                }
                else
                {
                    chosenTool = (int)(dataGridViewMachine.SelectedRows[0].Cells[0].Value);
                }

                if (numericUpDown1.Value == 0)
                {
                    value = "NULL";
                }
                else 
                {
                    value = numericUpDown1.Value.ToString(CultureInfo.InvariantCulture);
                }


                string dateFormat = "yyyy-MM-dd";
                string date = dateTimePicker1.Value.ToString();
                DateTime dateParse = DateTime.ParseExact(date, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string dateString = dateParse.ToString(dateFormat);

                string date2 = dateTimePicker2.Value.ToString();
                DateTime dateParse2 = DateTime.ParseExact(date2, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string dateString2 = dateParse2.ToString(dateFormat);

                string values = "'" + textBox1.Text + "', '" + richTextBox1.Text + "', " + chosenField + ", '" + dateString + "', '" + dateString2 + "', "
                    + chosenType +", "+chosenEmployee+", "+chosenMachine+", "+chosenTool+", "+farm.Journal.Id+", "+value;
                InsertQuery query = new InsertQuery("Activities", "name, description, field, start_date, finish_date, type, employee, machine, tool, journal, value", values);

                if (dboperator.insert(query) != 0)
                {
                    MessageBox.Show("Dodano");
                }
            }

            textBox1.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            clearDataGridViewSelections();
            numericUpDown1.Value = 0m;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;                        
        }

        private void FormAddActivity_Load(object sender, EventArgs e)
        {
            clearDataGridViewSelections();
        }

        private void dataGridViewResource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
