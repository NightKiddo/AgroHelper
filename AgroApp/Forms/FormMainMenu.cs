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
        User user = FormBase.dboperator.user;
        public FormMainMenu()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = "Menu główne";
            loadFarms();
            loadEmployees();
        }

        private void loadFarms()
        {
            dataGridViewFarms.Rows.Clear();
            dataGridViewFarms.AutoGenerateColumns = true;

            user.FarmsList = FormBase.dboperator.getFarms();

            var source = new BindingSource();
            source.DataSource = FormBase.dboperator.user.FarmsList; //TAK RÓB DATAGRIDY
            dataGridViewFarms.DataSource = source;                  //USUŃ KOLUMNY Z DATAGRIDÓW W DESGINERZE 

            dataGridViewFarms.Columns[0].Visible = false;
            dataGridViewFarms.Columns[2].Visible = false;

            dataGridViewFarms.Columns[1].Width = (int)(dataGridViewFarms.Width * 0.4);
            dataGridViewFarms.Columns[3].Width = (int)(dataGridViewFarms.Width * 0.2);
            dataGridViewFarms.Columns[4].Width = (int)(dataGridViewFarms.Width * 0.2);
            dataGridViewFarms.Columns[5].Width = (int)(dataGridViewFarms.Width * 0.2);


            dataGridViewFarms.ClearSelection();
        }

        private void loadEmployees()
        {
            dataGridViewEmployees.Rows.Clear();

            user.EmployeesList = FormBase.dboperator.getEmployees();

            var source = new BindingSource();
            source.DataSource = FormBase.dboperator.getEmployees();
            dataGridViewEmployees.DataSource = source;

            dataGridViewEmployees.Columns[0].Visible = false;
            dataGridViewEmployees.Columns[1].Width = dataGridViewEmployees.Width;
            dataGridViewEmployees.ClearSelection();
        }

        private void buttonAddFarm_Click(object sender, EventArgs e)
        {
            FormAddFarm formAddFarm = new FormAddFarm();
            this.Visible = false;
            formAddFarm.ShowDialog();
            this.Visible = true;
            loadFarms();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewFarms.SelectedRows[0];
            int farmId;
            int.TryParse(row.Cells[0].Value.ToString(), out farmId);

            Farm farm = FormBase.dboperator.user.FarmsList.Find(x => x.Id == farmId);

            FormShowFarm formShowFarm = new FormShowFarm(farm);
            this.Visible = false;
            formShowFarm.ShowDialog();
            this.Visible = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewFarms.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridViewFarms.SelectedRows[0];
                int farmId;
                int.TryParse(row.Cells[0].Value.ToString(), out farmId);


                DeleteQuery query = new DeleteQuery("Farms", "id", farmId);
                if (FormBase.dboperator.delete(query) != 0)
                {
                    MessageBox.Show("Usunięto");
                }
                else
                {
                    MessageBox.Show("Błąd");
                }

                loadFarms();
            }
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            FormAddEmployee formAddEmployee = new FormAddEmployee(user.Id);
            this.Visible = false;
            formAddEmployee.ShowDialog();
            this.Visible = true;
            loadEmployees();
        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridViewEmployees.SelectedRows[0];
                int employeeId;
                int.TryParse(row.Cells[0].Value.ToString(), out employeeId);


                DeleteQuery query = new DeleteQuery("Employees", "id", employeeId);
                if (FormBase.dboperator.delete(query) != 0)
                {
                    MessageBox.Show("Usunięto");
                }
                else
                {
                    MessageBox.Show("Błąd");
                }

                loadEmployees();
            }

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

        private void wylogujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
