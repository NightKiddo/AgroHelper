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
        Garage garage;
        Farm farm;
        int garageId;
        DBOperator dboperator = new DBOperator();
        public FormShowGarage(Garage garage, Farm farm)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = garage.Name;
            this.garage = garage;
            this.farm = farm;
            garageId = garage.Id;
            this.Text = garage.Name;
            loadMachines();
            loadTools();

            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView2.ContextMenuStrip = contextMenuStrip2;

        }

        public void loadMachines()
        {
            garage.MachinesList = dboperator.getMachines(garage.Id);
            dataGridView1.AutoGenerateColumns = true;
            var source = new BindingSource();
            source.DataSource = garage.MachinesList;
            dataGridView1.DataSource = source;

            int width = dataGridView1.Width;

            dataGridView1.Columns[0].Width = (int)(width * 0.05);
            dataGridView1.Columns[1].Width = (int)(width * 0.25);
            dataGridView1.Columns[2].Width = (int)(width * 0.15);
            dataGridView1.Columns[3].Width = (int)(width * 0.25);
            dataGridView1.Columns[4].Width = (int)(width * 0.25);
            dataGridView1.Columns[5].Width = (int)(width * 0.05);

            dataGridView1.ClearSelection();
        }

        public void loadTools()
        {
            garage.ToolsList = dboperator.getTools(garageId);
            dataGridView2.AutoGenerateColumns = true;
            var source = new BindingSource();
            source.DataSource = garage.ToolsList;
            dataGridView2.DataSource = source;

            int width = dataGridView2.Width;

            dataGridView2.Columns[0].Width = (int)(width * 0.05);
            dataGridView2.Columns[1].Width = (int)(width * 0.35);
            dataGridView2.Columns[2].Width = (int)(width * 0.25);
            dataGridView2.Columns[3].Width = (int)(width * 0.35);

            dataGridView2.ClearSelection();
        }

        private void buttonDeleteGarage_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Garages", "id", garageId);
            if (dboperator.delete(query) != 0)
            {
                MessageBox.Show("Usunięto");
                this.Close();
            }
        }
        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddMachine formAddMachine = new FormAddMachine(garage, 0);
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
                foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                {
                    int machineId;
                    Int32.TryParse(r.Cells[0].Value.ToString(), out machineId);
                    DeleteQuery deleteQuery = new DeleteQuery("Machines", "id", machineId);
                    dboperator.delete(deleteQuery);
                }
                loadMachines();
            }
        }

        private void dodajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAddTool formAddTool = new FormAddTool(garage, 0);
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
                foreach (DataGridViewRow r in dataGridView2.SelectedRows)
                {
                    int machineId;
                    Int32.TryParse(r.Cells[0].Value.ToString(), out machineId);
                    DeleteQuery deleteQuery = new DeleteQuery("Tools", "id", machineId);
                    dboperator.delete(deleteQuery);
                }
                loadTools();
            }
        }

        private void FormShowGarage_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                Machine machine = null;
                foreach (Machine m in garage.MachinesList)
                {
                    if (m.Id == (int)dataGridView1.SelectedRows[0].Cells[0].Value)
                    {
                        machine = m;
                    }
                }
                FormShowMachine formShowMachine = new FormShowMachine(farm, garage, machine);
                formShowMachine.ShowDialog();

                garage.MachinesList = dboperator.getMachines(garageId);
                loadMachines();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                Tool tool = garage.ToolsList.Find(x => x.Id == (int)dataGridView2.SelectedRows[0].Cells[0].Value);
                FormShowTool formShowTool = new FormShowTool(farm, garage, tool);
                formShowTool.ShowDialog();

                garage.ToolsList = dboperator.getTools(garage.Id);
                loadTools();
            }
        }

        private void powrótToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
