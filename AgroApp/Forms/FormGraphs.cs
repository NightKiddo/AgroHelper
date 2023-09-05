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
using System.Windows.Forms.DataVisualization.Charting;

namespace AgroApp.Forms
{
    public partial class FormGraphs : Form
    {
        DBOperator dboperator = new DBOperator();
        int userId;
        public FormGraphs(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            comboBoxGraphType.Items.AddRange(Enum.GetNames(typeof(System.Windows.Forms.DataVisualization.Charting.SeriesChartType)));
            loadFarms();
            loadValues();
            dataGridViewFarms.Columns[1].Width = dataGridViewFarms.Width;
            dataGridViewFields.Columns[1].Width = dataGridViewFields.Width;
            dataGridViewValues.Columns[2].Width = dataGridViewValues.Width;
            listBoxEmployee.ClearSelected();
        }

        private void loadFarms()
        {
            List<object[]> farms = dboperator.getFarms(userId);
            for (int i = 0; i < farms.Count; i++)
            {
                dataGridViewFarms.Rows.Add(farms[i]);
            }
            dataGridViewFields.ClearSelection();
        }

        private void buttonAddSeries_Click(object sender, EventArgs e)
        {
            if (dataGridViewFields.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz choć jedno pole");
            }
            else
            {

            }
        }

        private void loadValues()
        {
            List<object[]> notes = dboperator.getNoteTypes();
            List<object[]> activities = dboperator.getActivityTypes();

            for(int i=0;i<notes.Count;i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell cell = new DataGridViewCell();
                cell.Value= 1;

                row.Cells.Add(1);
                row.Cells.Add(notes[i].GetValue(0));
                row.Cells.Add(notes[i].GetValue(1));                
                dataGridViewValues.Rows.Add(row);
            }

            for (int i = 0; i < activities.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells[0].Value = 2;
                row.Cells[1].Value = activities[i].GetValue(0);
                row.Cells[2].Value = activities[i].GetValue(1);
                dataGridViewValues.Rows.Add(row);
            } 
        }

        private void dataGridViewFarms_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewFields.Rows.Clear();

            ; if (dataGridViewFarms.SelectedRows.Count != 0)
            {
                List<object[]> fields = dboperator.getFields((int)dataGridViewFarms.SelectedRows[0].Cells[0].Value);

                for (int i = 0; i < fields.Count; i++)
                {
                    dataGridViewFields.Rows.Add(fields[i]);
                }
            }
            dataGridViewFields.ClearSelection();
        }
    }
}
