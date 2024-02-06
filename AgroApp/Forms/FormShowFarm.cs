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
        DBOperator dboperator = new DBOperator();
        int farmId;
        Farm farm;
        public FormShowFarm(int farmId)
        {
            InitializeComponent();
            this.farmId = farmId;
            farm = dboperator.user.FarmsList.Find(x => x.Id == farmId);
            loadFields();
            loadGarages();
            loadStorages();
            loadJournal();
            setLabel();
        }

        private void setLabel()
        {
            string text = "";
            string farmName = dboperator.select("SELECT name FROM Farms WHERE id = " + farmId).ToString();
            text += farmName;
            string date = DateTime.Now.ToShortDateString();
            text += ", " + date;
            label1.Text = text;
        }

        private void loadFields()
        {
            dataGridViewFields.Rows.Clear();


            dataGridViewFields.Columns[1].Width = (int)(dataGridViewFields.Width * 0.2);
            dataGridViewFields.Columns[2].Width = (int)(dataGridViewFields.Width * 0.6);
            dataGridViewFields.Columns[3].Width = (int)(dataGridViewFields.Width * 0.2);

            dataGridViewFields.DataSource = farm.FieldsList;

            dataGridViewFields.ClearSelection();
        }

        private void loadGarages()
        {
            dataGridViewGarages.Rows.Clear();


            dataGridViewGarages.Columns[1].Width = dataGridViewGarages.Width;
            dataGridViewGarages.DataSource = farm.GaragesList;
        }

        private void loadStorages()
        {
            dataGridViewStorages.Rows.Clear();


            dataGridViewStorages.Columns[1].Width = dataGridViewStorages.Width;
            dataGridViewStorages.DataSource = farm.StoragesList;

            dataGridViewStorages.ClearSelection();
        }

        private void loadJournal()
        {
            dataGridViewJournal.Rows.Clear();

            for (int i = 0; i < dataGridViewJournal.Columns.Count; i++)
            {
                dataGridViewJournal.Columns[i].Width = dataGridViewJournal.Width / 5;
            }

            for (int i = 0; i < farm.Journal.ActivitiesList.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells[0].Value = farm.Journal.ActivitiesList[i].Name;
                row.Cells[1].Value = farm.Journal.ActivitiesList[i].Start_date;
                row.Cells[2].Value = farm.Journal.ActivitiesList[i].Finish_date;
                row.Cells[3].Value = farm.Journal.ActivitiesList[i].Field.Name;

                dataGridViewJournal.Rows.Add(row);
            }

            for (int i = 0; i < farm.Journal.NotesList.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells[0].Value = farm.Journal.NotesList[i].Name;
                row.Cells[1].Value = farm.Journal.NotesList[i].Start_date;
                row.Cells[2].Value = farm.Journal.NotesList[i].Finish_date;
                row.Cells[3].Value = farm.Journal.NotesList[i].Field.Name;

                dataGridViewJournal.Rows.Add(row);
            }

            dataGridViewJournal.Sort(dataGridViewJournal.Columns[3], ListSortDirection.Descending);
            dataGridViewJournal.ClearSelection();

            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Dodaj");

            dataGridViewJournal.ContextMenu = cm;
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
            Storage storage = (Storage)row.DataBoundItem;

            FormShowStorage formShowStorage = new FormShowStorage(storage);
            formShowStorage.ShowDialog();
            loadStorages();
        }

        private void pracęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int journalId;
            int.TryParse(dboperator.select("SELECT id FROM Journals WHERE farm = " + farmId).ToString(), out journalId);
            FormAddActivity formAddActivity = new FormAddActivity(farm);
            formAddActivity.ShowDialog();
            loadJournal();
        }

        private void notatkęToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            FormAddNote formAddNote = new FormAddNote(farm);
            formAddNote.ShowDialog();
            loadJournal();
        }

        private void dataGridViewJournal_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewJournal.ContextMenuStrip = contextMenuStripJournal;
                dataGridViewJournal.ContextMenuStrip.Show(new Point(e.X, e.Y));
            }
        }

        private void dataGridViewJournal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewJournal.SelectedRows[0].Cells[1].Value.ToString() == "0")
            {
                int noteId;
                Int32.TryParse(dataGridViewJournal.SelectedRows[0].Cells[0].Value.ToString(), out noteId);

                FormShowNote formShowNote = new FormShowNote(noteId);
                formShowNote.ShowDialog();
                loadJournal();
            }
            else
            {
                int activityId;
                Int32.TryParse(dataGridViewJournal.SelectedRows[0].Cells[0].Value.ToString(), out activityId);

                FormShowActivity formShowActivity = new FormShowActivity(activityId);
                formShowActivity.ShowDialog();
                loadJournal();
            }
        }

        private void dataGridViewGarages_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewGarages.ContextMenuStrip = contextMenuStripGarages;
                dataGridViewGarages.ContextMenuStrip.Show(new Point(e.X, e.Y));
            }
        }

        private void dodajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAddGarage formAddGarage = new FormAddGarage(farmId, 1);
            formAddGarage.ShowDialog();
            loadGarages();
        }

        private void dodajToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormAddStorage formAddStorage = new FormAddStorage(farmId, 1);
            formAddStorage.ShowDialog();
            loadStorages();
        }

        private void dataGridViewStorages_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewStorages.ContextMenuStrip = contextMenuStripStorages;
                dataGridViewStorages.ContextMenuStrip.Show(new Point(e.X, e.Y));
            }
        }

        private void dataGridViewFields_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewFields.ContextMenuStrip = contextMenuStripFields;
                dataGridViewFields.ContextMenuStrip.Show(new Point(e.X, e.Y));
            }
        }

        private void pracownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddEmployee formAddEmployee = new FormAddEmployee(dboperator.user.Id);
            formAddEmployee.ShowDialog();
        }

        private void FormShowFarm_Shown(object sender, EventArgs e)
        {
            dataGridViewFields.ClearSelection();
            dataGridViewGarages.ClearSelection();
            dataGridViewStorages.ClearSelection();
            dataGridViewJournal.ClearSelection();
        }

        private void wróćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void analizaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCharts formGraphs = new FormCharts(dboperator.user.Id);
            formGraphs.ShowDialog();
        }

        private void usuńToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridViewJournal.SelectedRows.Count > 0)
            {
                DeleteQuery query;
                if ((int)dataGridViewJournal.SelectedRows[0].Cells[1].Value == 0)
                {
                    query = new DeleteQuery("Notes", "id", (int)dataGridViewJournal.SelectedRows[0].Cells[0].Value);
                }
                else
                {
                    query = new DeleteQuery("Activities", "id", (int)dataGridViewJournal.SelectedRows[0].Cells[0].Value);
                }

                if (dboperator.delete(query) != 0)
                {
                    MessageBox.Show("Usunięto");
                }
                else
                {
                    MessageBox.Show("Błąd");
                }

                loadJournal();
            }
        }

        private void dodajToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormAddField formAddField = new FormAddField(farmId);
            formAddField.ShowDialog();
            dataGridViewFields.Rows.Clear();
            loadFields();
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewFields.SelectedRows.Count > 0)
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

        private void dataGridViewGarages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewGarages.SelectedRows[0];
            Garage garage = (Garage)row.DataBoundItem;
            FormShowGarage formShowGarage = new FormShowGarage(garage);
            formShowGarage.ShowDialog();
            loadGarages();
        }
    }
}
