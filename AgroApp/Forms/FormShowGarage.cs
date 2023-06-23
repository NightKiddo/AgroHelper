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
    public partial class FormShowGarage : Form
    {
        int garageId;
        List<object[]> machines = new List<object[]>();
        DBOperator dboperator = new DBOperator();
        public FormShowGarage(int garageId)
        {
            InitializeComponent();
            this.garageId = garageId;
            loadMachines();
        }

        public void loadMachines() 
        {
            dataGridView1.Rows.Clear();
            machines = dboperator.getMachines(garageId);

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = (int)(dataGridView1.Width * 0.2);
            }

            for (int j=0;j<machines.Count;j++) 
            {
                dataGridView1.Rows.Add(machines[j]);
            }

            dataGridView1.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddMachine formAddMachine = new FormAddMachine(garageId);
            formAddMachine.ShowDialog();
            loadMachines();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int machineId;
                int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out machineId);
                DeleteQuery query = new DeleteQuery("Machines", "id", machineId);
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

            loadMachines();
        }
    }
}
