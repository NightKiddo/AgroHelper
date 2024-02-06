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
    public partial class FormAddNote : Form
    {
        Farm farm;
        DBOperator dboperator = new DBOperator();
        public FormAddNote(Farm farm)
        {
            InitializeComponent();            
            loadFields();
            loadTypes();            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadFields()
        {
            dataGridView1.Columns[1].Width = dataGridView1.Width;
            dataGridView1.DataSource = farm.FieldsList;
        }

        private void loadTypes()
        {
            dataGridView2.Columns[1].Width = dataGridView2.Width;
            dataGridView2.DataSource = dboperator.getNoteTypes();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int chosenField = (int)(dataGridView1.SelectedRows[0].Cells[0].Value);
                int chosenType = (int)(dataGridView2.SelectedRows[0].Cells[0].Value);

                string dateFormat = "yyyy-MM-dd";
                string date = dateTimePicker1.Value.ToString();
                DateTime dateParse = DateTime.ParseExact(date, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string dateString = dateParse.ToString(dateFormat);

                string date2 = dateTimePicker1.Value.ToString();
                string dateString2 = dateParse.ToString(dateFormat);

                object value = 0;

                if (numericUpDown1.Value == 0)
                {
                    value = "NULL";
                }
                else
                {
                    value = numericUpDown1.Value.ToString(CultureInfo.InvariantCulture);
                }

                string values = "'" + textBox1.Text + "', '" + richTextBox1.Text + "', " + chosenField + ", '" + dateString + "', '" + dateString2 + "', " + jounralId + ", " + value + ", " + chosenType;
                InsertQuery query = new InsertQuery("Notes", "name, description, field, start_date, finish_date, journal, value, type", values);

                if (dboperator.insert(query) != 0)
                {
                    MessageBox.Show("Dodano");
                }
            }
        }

        private void FormAddNote_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }
    }
}
