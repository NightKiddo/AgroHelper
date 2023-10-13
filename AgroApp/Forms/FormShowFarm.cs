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
        int farmId, userId;
        DBOperator dboperator = new DBOperator();
        List<object[]> fields, garages, storages, notes_activities;
        public FormShowFarm(int farmId, int userId)
        {
            InitializeComponent();
            this.farmId = farmId;
            this.userId = userId;
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

            for (int i = 0; i < garages.Count; i++)
            {
                dataGridViewGarages.Rows.Add(garages[i]);
            }


        }

        private void loadStorages()
        {
            dataGridViewStorages.Rows.Clear();

            storages = dboperator.getStorages(farmId);
            dataGridViewStorages.Columns[1].Width = dataGridViewStorages.Width;

            for (int i = 0; i < storages.Count; i++)
            {
                dataGridViewStorages.Rows.Add(storages[i]);
            }

            dataGridViewStorages.ClearSelection();
        }

        private void loadJournal()
        {
            dataGridViewJournal.Rows.Clear();

            int journalId;
            int.TryParse(dboperator.select("SELECT id FROM Journals WHERE farm = " + farmId).ToString(), out journalId);

            notes_activities = dboperator.getJournalEntries(journalId);
            for (int i = 0; i < dataGridViewJournal.Columns.Count; i++)
            {
                dataGridViewJournal.Columns[i].Width = dataGridViewJournal.Width / 5;
            }

            for (int i = 0; i < notes_activities.Count; i++)
            {
                dataGridViewJournal.Rows.Add(notes_activities[i]);
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
            int storageId = Convert.ToInt32(row.Cells[0].Value);

            FormShowStorage formShowStorage = new FormShowStorage(storageId);
            formShowStorage.ShowDialog();
            loadStorages();
        }

        private void pracęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int journalId;
            int.TryParse(dboperator.select("SELECT id FROM Journals WHERE farm = " + farmId).ToString(), out journalId);
            FormAddActivity formAddActivity = new FormAddActivity(journalId, farmId, userId);
            formAddActivity.ShowDialog();
            loadJournal();
        }

        private void notatkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int journalId;
            int.TryParse(dboperator.select("SELECT id FROM Journals WHERE farm = " + farmId).ToString(), out journalId);
            FormAddNote formAddNote = new FormAddNote(journalId, farmId);
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
            FormAddGarage formAddGarage = new FormAddGarage(farmId,1);
            formAddGarage.ShowDialog();
            loadGarages();
        }

        private void dodajToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormAddStorage formAddStorage = new FormAddStorage(farmId,1);
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
            FormAddEmployee formAddEmployee = new FormAddEmployee(userId);
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
            FormCharts formGraphs = new FormCharts(userId);
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
            int garageId;
            int.TryParse(row.Cells[0].Value.ToString(), out garageId);
            FormShowGarage formShowGarage = new FormShowGarage(garageId);
            formShowGarage.ShowDialog();
            loadGarages();
        }
    }
}
