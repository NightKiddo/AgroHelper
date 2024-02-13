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
        DBOperator dboperator = FormBase.dboperator;

        Farm farm;
        public FormShowFarm(Farm farm)
        {
            InitializeComponent();
            this.farm = farm;
            loadFields();
            loadGarages();
            loadStorages();
            loadJournal();
            setLabel();
        }

        private void setLabel()
        {
            string text = "";
            string farmName = farm.Name;
            text += farmName;
            string date = DateTime.Now.ToShortDateString();
            text += ", " + date;
            label1.Text = text;
        }

        private void loadFields()
        {
            dataGridViewFields.Rows.Clear();
            dataGridViewFields.AutoGenerateColumns = true;
            var source = new BindingSource();
            source.DataSource = farm.FieldsList;
            dataGridViewFields.DataSource = source;

            dataGridViewFields.Columns[0].Visible = false;
            dataGridViewFields.Columns[2].Visible = false;
            dataGridViewFields.Columns[3].Visible = false;
            dataGridViewFields.Columns[4].Visible = false;

            dataGridViewFields.Columns[1].Width = (int)(dataGridViewFields.Width * 0.7);            
            dataGridViewFields.Columns[5].Width = (int)(dataGridViewFields.Width * 0.3);

            dataGridViewFields.ClearSelection();
        }

        private void loadGarages()
        {
            dataGridViewGarages.Rows.Clear();
            dataGridViewGarages.AutoGenerateColumns = true;
            var source = new BindingSource();
            source.DataSource = farm.GaragesList;
            dataGridViewGarages.DataSource = source;
            dataGridViewGarages.Columns[0].Visible = false;
            dataGridViewGarages.Columns[1].Width = dataGridViewGarages.Width;
            dataGridViewGarages.ClearSelection();
        }

        private void loadStorages()
        {
            dataGridViewStorages.Rows.Clear();
            dataGridViewStorages.AutoGenerateColumns = true;
            var source = new BindingSource();
            source.DataSource = farm.StoragesList;
            dataGridViewStorages.DataSource = source;

            dataGridViewStorages.Columns[0].Visible = false;
            dataGridViewStorages.Columns[1].Width = dataGridViewStorages.Width;
            dataGridViewStorages.DataSource = farm.StoragesList;

            dataGridViewStorages.ClearSelection();
        }

        private void loadJournal()
        {
            dataGridViewJournal.Rows.Clear();

            List<object[]> journalEntries = farm.Journal.getJournalEntries(farm);

            for(int i = 0; i < journalEntries.Count; i++)
            {
                dataGridViewJournal.Rows.Add(journalEntries[i]);
            }

            dataGridViewJournal.Sort(dataGridViewJournal.Columns[2], ListSortDirection.Descending);
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
            Field field = farm.FieldsList.Find(X=>X.Id == fieldId);
            FormShowField formShowField = new FormShowField(field);
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
            FormAddActivity formAddActivity = new FormAddActivity(farm,0);
            formAddActivity.ShowDialog();
            loadJournal();
        }

        private void notatkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNote formAddNote = new FormAddNote(farm,0);
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
            if (dataGridViewJournal.SelectedRows[0].Cells[6].Value.ToString() == "0")
            {                
                int noteId;
                Int32.TryParse(dataGridViewJournal.SelectedRows[0].Cells[0].Value.ToString(), out noteId);

                Note note = null;
                note = farm.Journal.NotesList.Find(x => x.Id == noteId);

                FormShowNote formShowNote = new FormShowNote(note);
                formShowNote.ShowDialog();
                loadJournal();
            }
            else
            {
                int activityId;
                Int32.TryParse(dataGridViewJournal.SelectedRows[0].Cells[0].Value.ToString(), out activityId);

                Activity activity = null;
                activity = farm.Journal.ActivitiesList.Find(x => x.Id == activityId);


                FormShowActivity formShowActivity = new FormShowActivity(activity);
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
            FormAddGarage formAddGarage = new FormAddGarage(farm.Id, 1);
            formAddGarage.ShowDialog();
            loadGarages();
        }

        private void dodajToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormAddStorage formAddStorage = new FormAddStorage(farm.Id, 1);
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
                foreach (DataGridViewRow r in dataGridViewJournal.SelectedRows)
                {
                    DeleteQuery query;
                    if (r.Cells[6].Value.ToString() == "0")
                    {
                        query = new DeleteQuery("Notes", "id", (int)r.Cells[0].Value);
                    }
                    else
                    {
                        query = new DeleteQuery("Activities", "id", (int)r.Cells[0].Value);
                    }

                    if (dboperator.delete(query) == 0)
                    {
                        MessageBox.Show("Błąd");
                    }
                }
                MessageBox.Show("Usunięto");
                loadJournal();
            }
        }

        private void dodajToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormAddField formAddField = new FormAddField(farm.Id);
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
