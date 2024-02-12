using AgroApp.Logic;
using AgroApp.Logic.DBControl;
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
        int invokeType;
        Activity editedActivity; //only used when editing
        List<string> updatedColumns = new List<string>();
        List<object> updatedValues = new List<object>();
        public FormAddActivity(Farm farm, int invokeType)
        {
            InitializeComponent();
            this.farm = farm;
            this.invokeType = invokeType;
            numericUpDown1.Maximum = Int32.MaxValue;
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

        private void setupControlsIfEditing()
        {
            editedActivity = farm.Journal.ActivitiesList.Find(x => x.Id == invokeType);

            textBox1.Text = editedActivity.Name;
            richTextBox1.Text = editedActivity.Description;


            //datagridviews
            #region

            if (editedActivity.Type != null)
            {
                foreach (DataGridViewRow r in dataGridViewType.Rows)
                {
                    if ((int)(r.Cells[0].Value) == editedActivity.Type.Id)
                    {
                        r.Selected = true;
                    }
                }
            }

            if (editedActivity.Field != null)
            {
                foreach (DataGridViewRow r in dataGridViewField.Rows)
                {
                    if ((int)(r.Cells[0].Value) == editedActivity.Field.Id)
                    {
                        r.Selected = true;
                    }
                }
            }

            if (editedActivity.Employee != null)
            {
                foreach (DataGridViewRow r in dataGridViewEmployee.Rows)
                {
                    if ((int)(r.Cells[0].Value) == editedActivity.Employee.Id)
                    {
                        r.Selected = true;
                    }
                }
            }

            if (editedActivity.Machine != null)
            {
                foreach (DataGridViewRow r in dataGridViewMachine.Rows)
                {
                    if ((int)(r.Cells[0].Value) == editedActivity.Machine.Id)
                    {
                        r.Selected = true;
                    }
                }
            }

            if (editedActivity.Tool != null)
            {
                foreach (DataGridViewRow r in dataGridViewTool.Rows)
                {
                    if ((int)(r.Cells[0].Value) == editedActivity.Tool.Id)
                    {
                        r.Selected = true;
                    }
                }
            }

            if (editedActivity.Resource != null)
            {
                foreach (DataGridViewRow r in dataGridViewResource.Rows)
                {
                    if ((int)(r.Cells[0].Value) == editedActivity.Resource.Id)
                    {
                        r.Selected = true;
                    }
                }
            }

            if (editedActivity.Start_date != null)
            {
                dateTimePicker1.Value = editedActivity.Start_date;
            }

            if (editedActivity.Finish_date != null)
            {
                dateTimePicker2.Value = editedActivity.Finish_date;
            }
            #endregion

            numericUpDown1.Value = (decimal)editedActivity.Value;
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
                    + chosenType + ", " + chosenEmployee + ", " + chosenMachine + ", " + chosenTool + ", " + farm.Journal.Id + ", " + value;
                InsertQuery query = new InsertQuery("Activities", "name, description, field, start_date, finish_date, type, employee, machine, tool, journal, value", values);

                if (invokeType == 0)
                {
                    if (dboperator.insert(query) != 0)
                    {
                        MessageBox.Show("Dodano");
                    }
                }
                else
                {


                    if (editedActivity.Name != textBox1.Text)
                    {
                        updatedColumns.Add("name");
                        updatedValues.Add(textBox1.Text);
                    }                    

                    if (editedActivity.Description != richTextBox1.Text)
                    {
                        updatedColumns.Add("description");
                        updatedValues.Add(richTextBox1.Text);
                    }

                    //datagridviews
                    #region
                    //type
                    if (editedActivity.Type == null)
                    {
                        if (dataGridViewType.SelectedRows.Count > 0)
                        {
                            updatedColumns.Add("type");
                            updatedValues.Add((int)(dataGridViewType.SelectedRows[0].Cells[0].Value));
                        }
                    }
                    else
                    {
                        if (editedActivity.Type.Id != (int)(dataGridViewType.SelectedRows[0].Cells[0].Value))
                        {
                            updatedColumns.Add("type");
                            updatedValues.Add((int)(dataGridViewType.SelectedRows[0].Cells[0].Value));
                        }
                    }

                    //field
                    if(editedActivity.Field == null)
                    {
                        if(dataGridViewField.SelectedRows.Count > 0)
                        {
                            updatedColumns.Add("field");
                            updatedValues.Add((int)(dataGridViewField.SelectedRows[0].Cells[0].Value));
                        }
                    }
                    else
                    {
                        if(editedActivity.Field.Id != (int)(dataGridViewField.SelectedRows[0].Cells[0].Value))
                        {
                            updatedColumns.Add("field");
                            updatedValues.Add((int)(dataGridViewField.SelectedRows[0].Cells[0].Value));
                        }
                    }

                    //employee
                    if (editedActivity.Employee == null)
                    {
                        if (dataGridViewEmployee.SelectedRows.Count > 0)
                        {
                            updatedColumns.Add("employee");
                            updatedValues.Add((int)(dataGridViewEmployee.SelectedRows[0].Cells[0].Value));
                        }
                    }
                    else
                    {
                        if (editedActivity.Employee.Id != (int)(dataGridViewEmployee.SelectedRows[0].Cells[0].Value))
                        {
                            updatedColumns.Add("employee");
                            updatedValues.Add((int)(dataGridViewEmployee.SelectedRows[0].Cells[0].Value));
                        }
                    }


                    //machine
                    if (editedActivity.Machine == null)
                    {
                        if (dataGridViewMachine.SelectedRows.Count > 0)
                        {
                            updatedColumns.Add("machine");
                            updatedValues.Add((int)(dataGridViewMachine.SelectedRows[0].Cells[0].Value));
                        }
                    }
                    else
                    {
                        if (editedActivity.Machine.Id != (int)(dataGridViewMachine.SelectedRows[0].Cells[0].Value))
                        {
                            updatedColumns.Add("machine");
                            updatedValues.Add((int)(dataGridViewMachine.SelectedRows[0].Cells[0].Value));
                        }
                    }

                    //tool
                    if (editedActivity.Tool == null)
                    {
                        if (dataGridViewTool.SelectedRows.Count > 0)
                        {
                            updatedColumns.Add("tool");
                            updatedValues.Add((int)(dataGridViewTool.SelectedRows[0].Cells[0].Value));
                        }
                    }
                    else
                    {
                        if (editedActivity.Tool.Id != (int)(dataGridViewTool.SelectedRows[0].Cells[0].Value))
                        {
                            updatedColumns.Add("tool");
                            updatedValues.Add((int)(dataGridViewTool.SelectedRows[0].Cells[0].Value));
                        }
                    }

                    //resource
                    if (editedActivity.Resource == null)
                    {
                        if (dataGridViewResource.SelectedRows.Count > 0)
                        {
                            updatedColumns.Add("resource");
                            updatedValues.Add((int)(dataGridViewResource.SelectedRows[0].Cells[0].Value));
                        }
                    }
                    else
                    {
                        if (editedActivity.Resource.Id != (int)(dataGridViewResource.SelectedRows[0].Cells[0].Value))
                        {
                            updatedColumns.Add("resource");
                            updatedValues.Add((int)(dataGridViewResource.SelectedRows[0].Cells[0].Value));
                        }
                    }

                    #endregion

                    //datetimepickers
                    #region
                    if ((decimal)(editedActivity.Value) != numericUpDown1.Value)
                    {
                        updatedColumns.Add("value");
                        updatedValues.Add(numericUpDown1.Value);
                    }

                    if(editedActivity.Start_date == null)
                    {
                        if(dateTimePicker1.Value > DateTime.MinValue)
                        {
                            updatedColumns.Add("start_date");
                            updatedValues.Add(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        }
                    }
                    else
                    {
                        if(editedActivity.Start_date.Date != dateTimePicker1.Value.Date)
                        {
                            updatedColumns.Add("start_date");
                            updatedValues.Add(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        }
                    }

                    if (editedActivity.Finish_date == null)
                    {
                        if (dateTimePicker2.Value > DateTime.MinValue)
                        {
                            updatedColumns.Add("finish_date");
                            updatedValues.Add(dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                        }
                    }
                    else
                    {
                        if (editedActivity.Finish_date.Date != dateTimePicker2.Value.Date)
                        {
                            updatedColumns.Add("finish_date");
                            updatedValues.Add(dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                        }
                    }
                    #endregion

                    UpdateQuery updateQuery = new UpdateQuery("Activities", updatedColumns, updatedValues, editedActivity.Id);

                    if(FormBase.dboperator.update(updateQuery) != 0)
                    {
                        MessageBox.Show("Edytowano");
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Błąd");
                    }
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
            if (invokeType == 0)
            {
                clearDataGridViewSelections();
            }
            else
            {
                setupControlsIfEditing();
                buttonAdd.Text = "Edytuj";
            }
        }

        private void dataGridViewResource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
