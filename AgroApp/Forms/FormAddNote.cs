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
    public partial class FormAddNote : Form
    {
        Farm farm;
        DBOperator dboperator = FormBase.dboperator;
        int invokeType;
        Note editedNote;
        List<string> updatedColumns = new List<string>();
        List<object> updatedValues = new List<object>();
        public FormAddNote(Farm farm, int invokeType)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = "Dodawanie notatki";
            this.farm = farm;
            this.invokeType = invokeType;
            numericUpDown1.Maximum = Int32.MaxValue;
            loadFields();
            loadTypes();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setupControlsIfEditing()
        {
            editedNote = farm.Journal.NotesList.Find(x => x.Id == invokeType);

            textBox1.Text = editedNote.Name;
            richTextBox1.Text = editedNote.Description;

            if (editedNote.Type != null)
            {
                foreach (DataGridViewRow r in dataGridViewType.Rows)
                {
                    if ((int)(r.Cells[0].Value) == editedNote.Type.Id)
                    {
                        r.Selected = true;
                    }
                }
            }
            else
            {
                dataGridViewType.ClearSelection();
            }

            if (editedNote.Field != null)
            {
                foreach (DataGridViewRow r in dataGridViewField.Rows)
                {
                    if ((int)(r.Cells[0].Value) == editedNote.Field.Id)
                    {
                        r.Selected = true;
                    }
                }
            }
            else
            {
                dataGridViewField.ClearSelection();
            }

            numericUpDown1.Value = (decimal)editedNote.Value;

            if (editedNote.Start_date != null)
            {
                dateTimePicker1.Value = editedNote.Start_date;
            }

            if (editedNote.Finish_date != null)
            {
                dateTimePicker2.Value = editedNote.Finish_date;
            }
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
            source.DataSource = dboperator.noteTypesCollection;
            dataGridViewType.DataSource = source;

            dataGridViewType.Columns[0].Visible = false;
            dataGridViewType.Columns[1].Width = dataGridViewType.Width;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (invokeType == 0)
            {
                if (dataGridViewField.SelectedRows.Count == 0 || textBox1.Text == string.Empty)
                {
                    MessageBox.Show("Nalezy wprowadzić nazwę i wybrać pole.");
                }
                else
                {
                    if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
                    {
                        MessageBox.Show("Data zakończenia nie może być przed datą rozpoczęcia");
                        return;
                    }

                    int chosenField = (int)(dataGridViewField.SelectedRows[0].Cells[0].Value);

                    string dateFormat = "yyyy-MM-dd";
                    string startDate = dateTimePicker1.Value.ToString();
                    DateTime startDateParse = DateTime.ParseExact(startDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    string startDateString = startDateParse.ToString(dateFormat);

                    string finishDate = dateTimePicker2.Value.ToString();
                    DateTime finishDateParse = DateTime.ParseExact(finishDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    string finishDateString = finishDateParse.ToString(dateFormat);

                    object value, chosenType;

                    if (numericUpDown1.Value == 0)
                    {
                        value = "NULL";
                    }
                    else
                    {
                        value = numericUpDown1.Value.ToString(CultureInfo.InvariantCulture);
                    }

                    if (dataGridViewField.SelectedRows.Count == 0)
                    {
                        chosenType = "NULL";
                    }
                    else
                    {
                        chosenType = (int)(dataGridViewField.SelectedRows[0].Cells[0].Value);
                    }

                    if (numericUpDown1.Value == 0)
                    {
                        value = "NULL";
                    }
                    else
                    {
                        value = numericUpDown1.Value.ToString(CultureInfo.InvariantCulture);
                    }

                    string values = "'" + textBox1.Text + "', '" + richTextBox1.Text + "', " + chosenField + ", '" + startDateString + "', '" + finishDateString + "', " + farm.Journal.Id + ", " + value + ", " + chosenType;
                    InsertQuery query = new InsertQuery("Notes", "name, description, field, start_date, finish_date, journal, value, type", values);

                    if (dboperator.insert(query) != 0)
                    {
                        MessageBox.Show("Dodano");
                    }

                    textBox1.Text = string.Empty;
                    richTextBox1.Text = string.Empty;
                    clearDataGridViewSelections();
                    numericUpDown1.Value = 0m;
                    dateTimePicker1.Value = DateTime.Today;
                    dateTimePicker2.Value = DateTime.Today;
                }
            }
            else
            {
                if (editedNote.Name != textBox1.Text)
                {
                    updatedColumns.Add("name");
                    updatedValues.Add(textBox1.Text);
                }

                if (editedNote.Description != richTextBox1.Text)
                {
                    updatedColumns.Add("description");
                    updatedValues.Add(richTextBox1.Text);
                }

                //type
                if (editedNote.Type == null)
                {
                    if (dataGridViewType.SelectedRows.Count > 0)
                    {
                        updatedColumns.Add("type");
                        updatedValues.Add((int)(dataGridViewType.SelectedRows[0].Cells[0].Value));
                    }
                }
                else
                {
                    if (editedNote.Type.Id != (int)(dataGridViewType.SelectedRows[0].Cells[0].Value))
                    {
                        updatedColumns.Add("type");
                        updatedValues.Add((int)(dataGridViewType.SelectedRows[0].Cells[0].Value));
                    }
                }

                //field
                if (editedNote.Field == null)
                {
                    if (dataGridViewField.SelectedRows.Count > 0)
                    {
                        updatedColumns.Add("field");
                        updatedValues.Add((int)(dataGridViewField.SelectedRows[0].Cells[0].Value));
                    }
                }
                else
                {
                    if (editedNote.Field.Id != (int)(dataGridViewField.SelectedRows[0].Cells[0].Value))
                    {
                        updatedColumns.Add("field");
                        updatedValues.Add((int)(dataGridViewField.SelectedRows[0].Cells[0].Value));
                    }
                }

                //start_date
                if (editedNote.Start_date == null)
                {
                    if (dateTimePicker1.Value > DateTime.MinValue)
                    {
                        updatedColumns.Add("start_date");
                        updatedValues.Add(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    }
                }
                else
                {
                    if (editedNote.Start_date.Date != dateTimePicker1.Value.Date)
                    {
                        updatedColumns.Add("start_date");
                        updatedValues.Add(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    }
                }

                //finish_date
                if (editedNote.Finish_date == null)
                {
                    if(dateTimePicker2.Value > DateTime.MinValue)
                    {
                        updatedColumns.Add("finish_date");
                        updatedValues.Add(dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    }
                }
                else
                {
                    if(editedNote.Finish_date.Date != dateTimePicker2.Value.Date)
                    {
                        updatedColumns.Add("finish_date");
                        updatedValues.Add(dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    }
                }

                if ((decimal)(editedNote.Value) != numericUpDown1.Value)
                {
                    updatedColumns.Add("value");
                    updatedValues.Add(numericUpDown1.Value);
                }

                if (updatedColumns.Count != 0)
                {
                    UpdateQuery updateQuery = new UpdateQuery("Notes", updatedColumns, updatedValues, editedNote.Id);

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

        private void clearDataGridViewSelections()
        {
            dataGridViewField.ClearSelection();
            dataGridViewType.ClearSelection();
        }


        private void FormAddNote_Load(object sender, EventArgs e)
        {
            if(invokeType == 0)
            {
                clearDataGridViewSelections();
            }
            else
            {
                setupControlsIfEditing();
                buttonAdd.Text = "Edytuj";
            }
        }
    }
}
