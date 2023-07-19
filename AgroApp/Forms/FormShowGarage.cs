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
        List<object[]> tools = new List<object[]>();
        DBOperator dboperator = new DBOperator();
        public FormShowGarage(int garageId)
        {
            InitializeComponent();
            this.garageId = garageId;
            loadMachines();
            loadTools();

            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView2.ContextMenuStrip = contextMenuStrip2;
        }

        public void loadMachines() 
        {
            dataGridView1.Rows.Clear();
            machines = dboperator.getMachines(garageId);

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = (int)(dataGridView1.Width / 5);
            }

            for (int j=0;j<machines.Count;j++) 
            {
                dataGridView1.Rows.Add(machines[j]);
            }

            dataGridView1.ClearSelection();
        }

        public void loadTools() 
        {
            dataGridView2.Rows.Clear();
            tools = dboperator.getTools(garageId);

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].Width = (int)(dataGridView2.Width / 3);
            }

            for (int j = 0; j < tools.Count; j++)
            {
                dataGridView2.Rows.Add(tools[j]);
            }

            dataGridView2.ClearSelection();
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

        private void buttonDeleteGarage_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Garages", "id", garageId);
            if(dboperator.delete(query) != 0) 
            {
                MessageBox.Show("Usunięto");
                this.Close();
            }
        }
        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddMachine formAddMachine = new FormAddMachine(garageId);
            formAddMachine.ShowDialog();
            loadMachines();
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Brak zaznaczenia");
            }
            else 
            {
                int machineId;
                Int32.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out machineId);
                DeleteQuery deleteQuery = new DeleteQuery("Machines", "id", machineId);
                dboperator.delete(deleteQuery);
                loadMachines();
            }
        }

        private void dodajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAddTool formAddTool = new FormAddTool(garageId);
            formAddTool.ShowDialog();
            loadTools();
        }

        private void usuńToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Brak zaznaczenia");
            }
            else
            {
                int machineId;
                Int32.TryParse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString(), out machineId);
                DeleteQuery deleteQuery = new DeleteQuery("Tools", "id", machineId);
                dboperator.delete(deleteQuery);
                loadTools();
            }
        }

        private void FormShowGarage_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }
    }
}
