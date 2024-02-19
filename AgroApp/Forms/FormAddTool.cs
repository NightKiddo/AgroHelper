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
    public partial class FormAddTool : Form
    {
        Garage garage;
        DBOperator dboperator = FormBase.dboperator;
        int invokeType;
        Tool editedTool;
        List<string> updatedColumns = new List<string>();
        List<object> updatedValues = new List<object>();
        public FormAddTool(Garage garage, int invokeType)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = "Dodawanie narzędzia";
            this.garage = garage;
            this.invokeType = invokeType;
            loadToolTypes();
            numericUpDown2.Maximum = Int32.MaxValue;
        }

        private void loadToolTypes()
        {
            dataGridView1.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = dboperator.toolTypesCollection;
            dataGridView1.DataSource = source;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = dataGridView1.Width;
        }

        private void setupControlsIfEditing()
        {
            editedTool = garage.ToolsList.Find(x => x.Id == invokeType);

            buttonAdd.Text = "Edytuj";

            textBox1.Text = editedTool.Name;

            if (editedTool.Type != null)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if ((int)r.Cells[0].Value == editedTool.Id)
                    {
                        r.Selected = true;
                    }
                }
            }
            else
            {
                dataGridView1.ClearSelection();
            }

            numericUpDown2.Value = editedTool.Mileage;
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
                    InsertQuery query;

                    string values = "'" + textBox1.Text + "', " + dataGridView1.SelectedRows[0].Cells[0].Value + ", " + numericUpDown2.Value.ToString(CultureInfo.InvariantCulture) + ", " + garage.Id;
                    query = new InsertQuery("Tools", "name,type,mileage,garage", values);


                    if (dboperator.insert(query) != 0)
                    {
                        MessageBox.Show("Dodano pomyślnie");
                        textBox1.Text = string.Empty;
                        dataGridView1.ClearSelection();
                        numericUpDown2.Value = 0m;
                    }
                    else
                    {
                        MessageBox.Show("Błąd");
                    }
                }
                else
                {
                    if (editedTool.Name != textBox1.Text)
                    {
                        updatedColumns.Add("name");
                        updatedValues.Add(textBox1.Text);
                    }

                    if (editedTool.Type == null | editedTool.Type.Id != (int)dataGridView1.SelectedRows[0].Cells[0].Value)
                    {
                        updatedColumns.Add("type");
                        updatedValues.Add((int)dataGridView1.SelectedRows[0].Cells[0].Value);
                    }

                    if (editedTool.Mileage != numericUpDown2.Value)
                    {
                        updatedColumns.Add("mileage");
                        updatedValues.Add(numericUpDown2.Value);
                    }

                    if (updatedColumns.Count != 0)
                    {
                        UpdateQuery updateQuery = new UpdateQuery("Tools", updatedColumns, updatedValues, editedTool.Id);

                        if (dboperator.update(updateQuery) != 0)
                        {
                            MessageBox.Show("Edytowano");
                            this.Close();
                            return;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddTool_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            if (invokeType != 0)
            {
                setupControlsIfEditing();
            }
        }
    }
}
