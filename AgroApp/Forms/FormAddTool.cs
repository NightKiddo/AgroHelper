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
    public partial class FormAddTool : Form
    {
        int garageId;
        List<object[]> tools;
        DBOperator dboperator = new DBOperator();
        public FormAddTool(int garageId)
        {
            InitializeComponent();
            this.garageId = garageId;
            loadToolTypes();
        }

        private void loadToolTypes()
        {
            dataGridView1.Columns[1].Width = dataGridView1.Width;
            tools = dboperator.getToolTypes();
            for (int i = 0; i < tools.Count; i++)
            {
                dataGridView1.Rows.Add(tools[i]);
            }

            dataGridView1.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && dataGridView1.SelectedRows.Count != 0)
            {
                InsertQuery query;

                string values = "'" + textBox1.Text + "', " + dataGridView1.SelectedRows[0].Cells[0].Value + ", " + numericUpDown2.Value + ", " + garageId;
                query = new InsertQuery("Tools", "name,type,mileage,garage", values);


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

        private void FormAddTool_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
