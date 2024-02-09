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
        DBOperator dboperator = FormBase.dboperator;
        public FormAddMachine(int garageId)
        {
            InitializeComponent();
            this.garageId= garageId;
            loadMachineTypes();
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && dataGridView1.SelectedRows.Count != 0)
            {
                InsertQuery query;
                if (dateTimePicker1.Value.Date == DateTime.Today.Date)
                {
                    string values = "'" + textBox1.Text + "', " + dataGridView1.SelectedRows[0].Cells[0].Value + ", " + numericUpDown2.Value + ", NULL , " + numericUpDown1.Value+", "+garageId;
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
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Błąd");
                    this.DialogResult = DialogResult.None;
                }
            }
            else 
            {
                MessageBox.Show("Błąd");
                this.DialogResult = DialogResult.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddMachine_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
