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
        DBOperator dboperator = FormBase.dboperator;
        Storage storage;
        public FormShowStorage(Storage storage)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = storage.Name;
            this.storage = storage;
            this.storageId = storage.Id;
            loadResources();
        }

        private void loadResources()
        {
            storage.ResourcesList = dboperator.getResources(storage);
            dataGridView1.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = storage.ResourcesList;
            dataGridView1.DataSource = source;

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddResource formAddResource = new FormAddResource(storage, 0);
            formAddResource.ShowDialog();
            loadResources();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
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
            if (dboperator.delete(query) != 0)
            {
                MessageBox.Show("Usunięto");
                this.Close();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                FormAddResource formAddResource = new FormAddResource(storage, (int)dataGridView1.SelectedRows[0].Cells[0].Value);
                formAddResource.ShowDialog();
                
                loadResources();
            }
        }

        private void powrótToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
