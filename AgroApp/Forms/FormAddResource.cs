using AgroApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Forms
{
    public partial class FormAddResource : Form
    {
        int storageId;
        List<object[]> resources;
        DBOperator dboperator = new DBOperator();
        public FormAddResource(int storageId)
        {
            InitializeComponent();
            this.storageId = storageId;
            loadResourceTypes();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != String.Empty && dataGridView1.SelectedRows.Count != 0)
            {
                string values = "'"+textBox1.Text+"', " + dataGridView1.SelectedRows[0].Cells[0].Value + ", "+numericUpDown1.Value+", "+storageId;
                InsertQuery query = new InsertQuery("Resources","name, type, amount, storage", values);

                if (dboperator.insert(query) != 0)
                {
                    MessageBox.Show("Dodano pomyślnie");
                }
                else 
                {
                    MessageBox.Show("Błąd");
                }
            }
        }

        private void loadResourceTypes() 
        {
            dataGridView1.Columns[1].Width = dataGridView1.Width;
            resources = dboperator.getResourceTypes();
            for(int i=0; i<resources.Count;i++) 
            {
                dataGridView1.Rows.Add(resources[i]);
            }
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
