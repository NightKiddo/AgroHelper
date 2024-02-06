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
        DBOperator dboperator = new DBOperator();
        public FormAddActivity(Farm farm)
        {
            InitializeComponent();
            this.farm = farm;
            loadFields();
            loadTypes();
            loadEmployees();
            loadMachines();
            loadTools();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadFields() 
        {
            dataGridViewField.Columns[1].Width = dataGridViewField.Width;
            List<Field> fields = dboperator.getFields(farm);

            dataGridViewField.DataSource = fields;
        }

        private void loadTypes()
        {
            dataGridViewType.Columns[1].Width = dataGridViewField.Width;
            dataGridViewType.DataSource = dboperator.getActivityTypes();
        }
        private void loadEmployees() 
        {
            dataGridViewEmployee.Columns[1].Width = dataGridViewEmployee.Width;
            dataGridViewEmployee.Rows.Add(new object[] { DBNull.Value, "(brak)" } );

            dataGridViewEmployee.DataSource = dboperator.user.EmployeesList;
        }

        private void loadMachines() 
        {
            dataGridViewMachine.Columns[1].Width = dataGridViewMachine.Width;
            dataGridViewMachine.Rows.Add(new object[] { DBNull.Value, "(brak)" });


            dataGridViewMachine.DataSource = farm.getAllMachines();
        }

        private void loadTools()
        {
            dataGridViewTool.Columns[1].Width = dataGridViewTool.Width;
            dataGridViewTool.Rows.Add(new object[] { DBNull.Value, "(brak)" });

            List<Tool> tools = farm.getAllTools();

            dataGridViewTool.DataSource = tools;
        }

        private void FormAddActivity_Shown(object sender, EventArgs e)
        {
            dataGridViewField.ClearSelection();
            dataGridViewType.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewField.SelectedRows.Count != 0)
            {
                int chosenField = (int)(dataGridViewField.SelectedRows[0].Cells[0].Value);
                int chosenType = (int)(dataGridViewType.SelectedRows[0].Cells[0].Value);
                object chosenEmployee, chosenMachine, chosenTool, value;
                if (dataGridViewEmployee.SelectedRows[0] == dataGridViewEmployee.Rows[0])
                {
                    chosenEmployee = "NULL";
                }
                else 
                {
                    chosenEmployee = (int)(dataGridViewEmployee.SelectedRows[0].Cells[0].Value);
                }

                if (dataGridViewMachine.SelectedRows[0] == dataGridViewMachine.Rows[0])
                {
                    chosenMachine = "NULL";
                }
                else
                {
                    chosenMachine = (int)(dataGridViewMachine.SelectedRows[0].Cells[0].Value);
                }

                if (dataGridViewTool.SelectedRows[0] == dataGridViewTool.Rows[0])
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
        }
    }
}
