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
    public partial class FormAddMachine : Form
    {
        int garageId;
        List<object[]> machines;
        DBOperator dboperator = new DBOperator();
        public FormAddMachine(int garageId)
        {
            InitializeComponent();
            this.garageId= garageId;
            loadMachineTypes();
        }

        private void loadMachineTypes() 
        {
            dataGridView1.Columns[1].Width = dataGridView1.Width;
            machines = dboperator.getMachineTypes();
            for(int i=0; i<machines.Count; i++)
            {
                dataGridView1.Rows.Add(machines[i]);
            }

            dataGridView1.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && dataGridView1.SelectedRows.Count != 0)
            {
                InsertQuery query;
                if (dateTimePicker1.Value == DateTime.Today)
                {
                    string values = "'" + textBox1.Text + "', " + dataGridView1.SelectedRows[0].Cells[0].Value + ", " + numericUpDown2.Value + ", " + DBNull.Value + ", " + numericUpDown1.Value+", "+garageId;
                    query = new InsertQuery("Machines", "name,type,mileage,inspection_date,fuel,garage", values);
                }
                else 
                {
                    string dateFormat = "yyyy-MM-dd";
                    string date = dateTimePicker1.Value.ToString();
                    DateTime dateParse = DateTime.ParseExact(date, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    string dateString = dateParse.ToString(dateFormat);
                    string values = "'" + textBox1.Text + "', " + dataGridView1.SelectedRows[0].Cells[0].Value + ", " + numericUpDown2.Value + ", '" + dateString + "', " + numericUpDown1.Value+", "+garageId;
                    query = new InsertQuery("Machines", "name,type,mileage,inspection_date,fuel,garage", values);
                }
                
                
                if (dboperator.insert(query) != 0)
                {
                    MessageBox.Show("Dodano pomyślnie");
                }
                else
                {
                    MessageBox.Show("Błąd");
                }
            }
            else 
            {
                MessageBox.Show("Błąd");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
