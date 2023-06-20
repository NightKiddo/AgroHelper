using AgroApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Forms
{
    public partial class FormMainMenu : Form
    {
        int userId;
        DBOperator dboperator = new DBOperator();
        List<object[]> farms;
        public FormMainMenu(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            loadFarms();
        }

        private void loadFarms() 
        {
            farms = dboperator.getFarms(userId);
            dataGridView1.Columns[1].Width = dataGridView1.Width;
            for (int i = 0; i < farms.Count; i++) {

                dataGridView1.Rows.Add(farms[i]);
            }
        }

        private void buttonAddFarm_Click(object sender, EventArgs e)
        {
            FormAddFarm formAddFarm = new FormAddFarm(userId);
            formAddFarm.ShowDialog();
            dataGridView1.Rows.Clear();
            loadFarms();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int farmId;
            int.TryParse(row.Cells[0].Value.ToString(), out farmId);

            FormShowFarm formShowFarm = new FormShowFarm(farmId);
            formShowFarm.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int farmId;
            int.TryParse(row.Cells[0].Value.ToString(), out farmId);


            DeleteQuery query = new DeleteQuery("Farms", "id", farmId);
            if (dboperator.delete(query) != 0)
            {
                MessageBox.Show("Usunięto");
            }
            else 
            {
                MessageBox.Show("Błąd");
            }

            dataGridView1.Rows.Clear();
            loadFarms();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int farmId;
            int.TryParse(row.Cells[0].Value.ToString(), out farmId);

        }
    }
}
