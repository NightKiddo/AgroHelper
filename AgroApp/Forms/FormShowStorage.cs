using AgroApp.Logic;
using AgroApp.Properties;
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
    public partial class FormShowStorage : Form
    {
        int storageId;
        DBOperator dboperator = new DBOperator();
        List<object[]> resources = new List<object[]>();
        public FormShowStorage(int storageId)
        {
            InitializeComponent();
            this.storageId = storageId;
            loadResources();
        }

        private void loadResources() 
        {
            dataGridView1.Rows.Clear();
            resources = dboperator.getResources(storageId);

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = (int)(dataGridView1.Width / 3);
            }

            for (int j = 0; j < resources.Count; j++)
            {
                dataGridView1.Rows.Add(resources[j]);
            }

            dataGridView1.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddResource formAddResource = new FormAddResource(storageId);
            formAddResource.ShowDialog();
            loadResources();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count != 0) 
            {
                int resourceId;
                int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out resourceId);
                DeleteQuery query = new DeleteQuery("Resources", "id", resourceId);
                if (dboperator.delete(query) != 0)
                {
                    MessageBox.Show("Usunięto pomyślnie");
                }
                else
                {
                    MessageBox.Show("Błąd");
                }
            }
            else 
            {
                MessageBox.Show("Brak zaznaczenia");
            }

            loadResources();
        }

        private void buttonDeleteStorage_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Storages", "id", storageId);
            if(dboperator.delete(query) != 0)
            {
                MessageBox.Show("Usunięto");
                this.Close();
            }
        }
    }
}
