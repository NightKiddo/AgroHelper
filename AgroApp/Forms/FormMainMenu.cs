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
        public FormMainMenu(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            loadFarms(userId);
        }

        private void loadFarms(int userId) 
        {
            string query = "SELECT id, name FROM Farms WHERE user = " + userId;
            dboperator.connect();
            dboperator.getConn().Open();

            SqlCommand command = dboperator.getCommand();
            SqlDataReader reader = dboperator.getReader();

            while (reader.Read()) 
            {
                string[] row = new string[] { reader.GetString(0), reader.GetString(1) };
                dataGridView1.Rows.Add(row);
            }

            reader.Close();
            dboperator.getConn().Close();
        }

        private void buttonAddFarm_Click(object sender, EventArgs e)
        {
            FormAddFarm formAddFarm = new FormAddFarm(userId);
            formAddFarm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int farmId;
            int.TryParse(row.Cells[0].Value.ToString(), out farmId);

            FormShowFarm formShowFarm = new FormShowFarm(farmId);
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
            loadFarms(userId);
        }
    }
}
