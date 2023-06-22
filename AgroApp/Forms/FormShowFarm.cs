using AgroApp.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Forms
{
    public partial class FormShowFarm : Form
    {
        int farmId;
        DBOperator dboperator = new DBOperator();
        List<object[]> fields, garages, storages;
        public FormShowFarm(int farmId)
        {
            InitializeComponent();
            this.farmId = farmId;
            loadFields();
            loadGarages();
            loadStorages();
        }
        private void loadFields()
        {
            dataGridViewFields.Rows.Clear();

            fields = dboperator.getFields(farmId);
            dataGridViewFields.Columns[1].Width = (int)(dataGridViewFields.Width * 0.2);
            dataGridViewFields.Columns[2].Width = (int)(dataGridViewFields.Width * 0.6);
            dataGridViewFields.Columns[3].Width = (int)(dataGridViewFields.Width * 0.2);
            for (int i = 0; i < fields.Count; i++)
            {

                dataGridViewFields.Rows.Add(fields[i]);
            }

            dataGridViewFields.ClearSelection();
        }

        private void loadGarages() 
        {
            dataGridViewGarages.Rows.Clear();

            garages = dboperator.getGarages(farmId);
            dataGridViewGarages.Columns[1].Width = dataGridViewGarages.Width;

            for(int i=0; i< garages.Count; i++)
            {
                dataGridViewGarages.Rows.Add(garages[i]);
            }

            
        }

        private void loadStorages() 
        {
            dataGridViewStorages.Rows.Clear();

            storages = dboperator.getStorages(farmId);
            dataGridViewStorages.Columns[1].Width = dataGridViewStorages.Width;

            for(int i=0;i < storages.Count; i++)
            {
                dataGridViewStorages.Rows.Add(storages[i]);
            }

            dataGridViewStorages.ClearSelection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewFields.SelectedRows[0];
            int fieldId;
            int.TryParse(row.Cells[0].Value.ToString(), out fieldId);
            FormShowField formShowField = new FormShowField(fieldId);
            formShowField.ShowDialog();
        }

        private void dataGridViewStorages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewStorages.SelectedRows[0];
            int storageId = Convert.ToInt32(row.Cells[0].Value);
            
            FormShowStorage formShowStorage = new FormShowStorage(storageId);
            formShowStorage.ShowDialog();
        }

        private void dataGridViewGarages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewGarages.SelectedRows[0];
            int garageId;
            int.TryParse(row.Cells[0].Value.ToString(), out garageId);
            FormShowGarage formShowGarage = new FormShowGarage(garageId);
            formShowGarage.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddField formAddField = new FormAddField(farmId);
            formAddField.ShowDialog();
            dataGridViewFields.Rows.Clear();
            loadFields();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Fields", "id", (int)dataGridViewFields.SelectedRows[0].Cells[0].Value);

            if (dboperator.delete(query) != 0)
            {
                MessageBox.Show("Usunięto");
            }
            else
            {
                MessageBox.Show("Błąd");
            }

            loadFields();
        }
    }
}
