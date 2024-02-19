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
    public partial class FormAddResource : Form
    {
        Storage storage;
        DBOperator dboperator = FormBase.dboperator;
        int invokeType;
        Resource editedResource;
        List<string> updatedColumns = new List<string>();
        List<object> updatedValues = new List<object>();
        public FormAddResource(Storage storage, int invokeType)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = "Dodawanie zasobu";
            this.storage = storage;
            this.invokeType = invokeType;
            loadResourceTypes();
            numericUpDown1.Maximum = Int32.MaxValue;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty && dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Należy wprowadzić nazwę i wybrać typ");
            }
            else
            {
                if (invokeType == 0)
                {
                    string values = "'" + textBox1.Text + "', " + dataGridView1.SelectedRows[0].Cells[0].Value + ", " + numericUpDown1.Value.ToString(CultureInfo.InvariantCulture) + ", " + storage.Id;
                    InsertQuery query = new InsertQuery("Resources", "name, type, amount, storage", values);

                    if (dboperator.insert(query) != 0)
                    {
                        MessageBox.Show("Dodano pomyślnie");
                        textBox1.Text = string.Empty;
                        dataGridView1.ClearSelection();
                        numericUpDown1.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("Błąd");
                    }
                }
                else
                {
                    if(editedResource.Name != textBox1.Text)
                    {
                        updatedColumns.Add("name");
                        updatedValues.Add(textBox1.Text);
                    }

                    if(editedResource.Type == null | editedResource.Type.Id != (int)dataGridView1.SelectedRows[0].Cells[0].Value)
                    {
                        updatedColumns.Add("type");
                        updatedValues.Add((int)dataGridView1.SelectedRows[0].Cells[0].Value);
                    }
                    
                    if(editedResource.Amount != (double)numericUpDown1.Value)
                    {
                        updatedColumns.Add("amount");
                        updatedValues.Add(numericUpDown1.Value);
                    }

                    if(updatedColumns.Count != 0)
                    {
                        UpdateQuery updateQuery = new UpdateQuery("Resources", updatedColumns, updatedValues, editedResource.Id);

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

        private void loadResourceTypes()
        {
            dataGridView1.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = dboperator.resourceTypesCollection;
            dataGridView1.DataSource = source;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = dataGridView1.Width;
            dataGridView1.ClearSelection();
        }

        private void setupControlsIfEditing()
        {
            editedResource = storage.ResourcesList.Find(x => x.Id == invokeType);

            buttonAdd.Text = "Edytuj";

            textBox1.Text = editedResource.Name;

            if (editedResource.Type != null)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if ((int)r.Cells[0].Value == editedResource.Type.Id)
                    {
                        r.Selected = true;
                    }
                }
            }
            else
            {
                dataGridView1.ClearSelection();
            }

            numericUpDown1.Value = (decimal)editedResource.Amount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddResource_Load(object sender, EventArgs e)
        {
            if(invokeType != 0)
            {
                setupControlsIfEditing();
            }
        }
    }
}
