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
        int jounralId;
        int farmId;
        DBOperator dboperator = new DBOperator();
        public FormAddNote(int journalId, int farmId)
        {
            InitializeComponent();
            this.jounralId= journalId;
            this.farmId= farmId;
            loadFields();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadFields()
        {
            dataGridView1.Columns[1].Width = dataGridView1.Width;
            List<object[]> fields = dboperator.getFields(farmId);

            for (int i = 0; i < fields.Count; i++)
            {
                dataGridView1.Rows.Add(fields[i]);
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int chosenField = (int)(dataGridView1.SelectedRows[0].Cells[0].Value);

                string dateFormat = "yyyy-MM-dd";
                string date = dateTimePicker1.Value.ToString();
                DateTime dateParse = DateTime.ParseExact(date, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string dateString = dateParse.ToString(dateFormat);

                string date2 = dateTimePicker1.Value.ToString();
                string dateString2 = dateParse.ToString(dateFormat);

                string values = "'" + textBox1.Text + "', '" + richTextBox1.Text + "', " + chosenField + ", '" + dateString + "', '" + dateString2 + "', " + jounralId;
                InsertQuery query = new InsertQuery("Activities", "name, description, field, start_date, finish_date, journal", values);

                if (dboperator.insert(query) != 0)
                {
                    MessageBox.Show("Dodano");
                }
            }
        }
    }
}
