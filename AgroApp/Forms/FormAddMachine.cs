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
    public partial class FormAddMachine : Form
    {
        Garage garage;
        DBOperator dboperator = FormBase.dboperator;
        int invokeType;
        Machine editedMachine;
        List<string> updatedColumns = new List<string>();
        List<object> updatedValues = new List<object>();
        public FormAddMachine(Garage garage, int invokeType)
        {
            InitializeComponent();
            this.garage = garage;
            this.invokeType = invokeType;
        }

        private void loadMachineTypes()
        {
            dataGridView1.AutoGenerateColumns = true;
            var source = new BindingSource();
            source.DataSource = dboperator.machineTypesCollection;
            dataGridView1.DataSource = source;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = dataGridView1.Width;
            dataGridView1.ClearSelection();
        }

        private void setupControls()
        {
            numericUpDown1.Maximum = Int32.MaxValue;
            numericUpDown2.Maximum = Int32.MaxValue;
            loadMachineTypes();
        }

        private void setupControlsIfEditing()
        {
            numericUpDown1.Maximum = Int32.MaxValue;
            numericUpDown2.Maximum = Int32.MaxValue;
            loadMachineTypes();
            buttonAdd.Text = "Edytuj";

            editedMachine = garage.MachinesList.Find(x => x.Id == invokeType);

            textBox1.Text = editedMachine.Name;

            if (editedMachine.Type != null)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if ((int)(r.Cells[0].Value) == editedMachine.Type.Id)
                    {
                        r.Selected = true;
                    }
                }
            }
            else
            {
                dataGridView1.ClearSelection();
            }

            numericUpDown1.Value = (decimal)editedMachine.Mileage;

            if (editedMachine.Inspection_date > DateTimePicker.MinimumDateTime)
            {
                dateTimePicker1.Value = editedMachine.Inspection_date;
            }

            numericUpDown2.Value = (decimal)editedMachine.Fuel;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty || dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Należy wprowadzić nazwę i wybrać typ");
            }
            else
            {
                if (invokeType == 0)
                {
                    object chosenType, dateString;

                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        chosenType = "NULL";
                    }
                    else
                    {
                        chosenType = (int)(dataGridView1.SelectedRows[0].Cells[0].Value);
                    }


                    if (dateTimePicker1.Value.Date == DateTime.Today.Date)
                    {
                        dateString = "NULL";
                    }
                    else
                    {
                        string dateFormat = "yyyy-MM-dd";
                        string date = dateTimePicker1.Value.ToString();
                        DateTime dateParse = DateTime.ParseExact(date, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        dateString = "'" + dateParse.ToString(dateFormat) + "'";
                    }

                    string values =
                        "'" + textBox1.Text + "', " + chosenType + ", " +
                        numericUpDown2.Value + ", " + dateString + ", " + numericUpDown1.Value.ToString(CultureInfo.InvariantCulture) + ", " + garage.Id;
                    InsertQuery query = new InsertQuery("Machines", "name,type,mileage,inspection_date,fuel,garage", values);


                    if (dboperator.insert(query) != 0)
                    {
                        MessageBox.Show("Dodano");
                        textBox1.Text = string.Empty;
                        dataGridView1.ClearSelection();
                        numericUpDown1.Value = 0m;
                        numericUpDown2.Value = 0m;
                        dateTimePicker1.Value = DateTime.Today;
                    }
                }
                else
                {
                    if (editedMachine.Name != textBox1.Text)
                    {
                        updatedColumns.Add("name");
                        updatedValues.Add(textBox1.Text);
                    }

                    if (editedMachine.Type == null | editedMachine.Type.Id != (int)dataGridView1.SelectedRows[0].Cells[0].Value)
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            updatedColumns.Add("type");
                            updatedValues.Add((int)dataGridView1.SelectedRows[0].Cells[0].Value);
                        }
                    }

                    if (editedMachine.Mileage != numericUpDown1.Value)
                    {
                        updatedColumns.Add("mileage");
                        updatedValues.Add(numericUpDown1.Value);
                    }

                    if (editedMachine.Inspection_date == null | editedMachine.Inspection_date.Date != dateTimePicker1.Value.Date)
                    {
                        if (dateTimePicker1.Value.Date != DateTime.Today)
                        {
                            updatedColumns.Add("inspection_date");
                            updatedValues.Add(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        }
                    }

                    if (!editedMachine.Fuel.Equals(numericUpDown2.Value))
                    {
                        updatedColumns.Add("fuel");
                        updatedValues.Add(numericUpDown2.Value);
                    }

                    if (updatedColumns.Count != 0)
                    {
                        UpdateQuery updateQuery = new UpdateQuery("Machines", updatedColumns, updatedValues, editedMachine.Id);
                        if (dboperator.update(updateQuery) != 0)
                        {
                            MessageBox.Show("Edytowano");
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        DialogResult messageBoxResult = MessageBox.Show("Nie wprowadzono żadnych zmian, czy chcesz powrócić?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (messageBoxResult == DialogResult.No)
                        {
                            this.Close();
                            return;
                        }
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddMachine_Load(object sender, EventArgs e)
        {
            if (invokeType == 0)
            {
                setupControls();
            }
            else
            {
                setupControlsIfEditing();
            }
        }
    }
}
