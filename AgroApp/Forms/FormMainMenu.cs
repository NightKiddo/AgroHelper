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
        DBOperator dboperator = new DBOperator();
        int userId;        
        public FormMainMenu()
        {
            InitializeComponent();
            userId = dboperator.user.Id;
            loadFarms();
            loadEmployees();
        }

        private void loadFarms() 
        {
            dataGridViewFarms.Rows.Clear();
            
            dataGridViewFarms.Columns[1].Width = dataGridViewFarms.Width;
            dataGridViewFarms.DataSource = dboperator.user.FarmsList;
        }

        private void loadEmployees()
        {
            dataGridViewEmployees.Rows.Clear();
            
            dataGridViewEmployees.Columns[1].Width = dataGridViewEmployees.Width;
            dataGridViewEmployees.DataSource = dboperator.getEmployees();
            

            dataGridViewEmployees.ClearSelection();
        }

        private void buttonAddFarm_Click(object sender, EventArgs e)
        {
            FormAddFarm formAddFarm = new FormAddFarm();
            formAddFarm.ShowDialog();
            loadFarms();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewFarms.SelectedRows[0];
            int farmId;
            int.TryParse(row.Cells[0].Value.ToString(), out farmId);

                FormShowFarm formShowFarm = new FormShowFarm(farmId);
            formShowFarm.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridViewFarms.SelectedRows[0];
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

            loadFarms();
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            FormAddEmployee formAddEmployee = new FormAddEmployee(userId);
            formAddEmployee.ShowDialog();
            loadEmployees();
        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridViewEmployees.SelectedRows[0];
            int employeeId;
            int.TryParse(row.Cells[0].Value.ToString(), out employeeId);


            DeleteQuery query = new DeleteQuery("Employees", "id", employeeId);
            if (dboperator.delete(query) != 0)
            {
                MessageBox.Show("Usunięto");
            }
            else
            {
                MessageBox.Show("Błąd");
            }
            
            loadEmployees();
        }

        private void FormMainMenu_Shown(object sender, EventArgs e)
        {
            dataGridViewEmployees.ClearSelection();
            dataGridViewFarms.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewFarms.SelectedRows[0];
            int farmId;
            int.TryParse(row.Cells[0].Value.ToString(), out farmId);

        }
    }
}
