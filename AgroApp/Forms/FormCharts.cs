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
    public partial class FormCharts : Form
    {
        DBOperator dboperator = new DBOperator();

        object[] types = { SeriesChartType.Column, SeriesChartType.Line, SeriesChartType.Point };
        int userId;
        public FormCharts(int userId)
        {
            this.userId = userId;
            InitializeComponent();


            loadChartTypes();
            loadFarms();
            loadValues();
            loadEmployees();

            dataGridViewFarms.Columns[1].Width = dataGridViewFarms.Width;
            dataGridViewFields.Columns[1].Width = dataGridViewFields.Width;
            dataGridViewValues.Columns[2].Width = dataGridViewValues.Width;
            dataGridViewEmployees.Columns[1].Width = dataGridViewEmployees.Width;
            chart1.Series.Clear();

        }

        private void loadChartTypes()
        {
            comboBoxGraphType.Items.AddRange(types);            
        }

        private void loadFarms()
        {
            List<object[]> farms = dboperator.getFarms(userId);
            for (int i = 0; i < farms.Count; i++)
            {
                dataGridViewFarms.Rows.Add(farms[i]);
            }
        }

        private void buttonAddSeries_Click(object sender, EventArgs e)
        {
            /*
             * error
             * Osie obszaru wykresu — Obszar wykresu zawiera niezgodne typy wykresów. 
             * Na przykład w jednym obszarze wykresu nie mogą znajdować się wykresy słupkowe i kolumnowe.
             */
            foreach (Series s in chart1.Series)
            {
                if (s.Name == textBox2.Text)
                {
                    MessageBox.Show("Jest już seria o takiej nazwie");
                }
            }

            if (dataGridViewFields.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz choć jedno pole");
            }
            else if (comboBoxGraphType.SelectedIndex == null)
            {
                MessageBox.Show("Wybierz rodzaj wykresu");
            }
            else
            {
                Series series = new Series(textBox2.Text);
                chart1.Series.Add(series);
                chart1.Series[textBox2.Text].XValueType = ChartValueType.Date;
                series.ChartType = (SeriesChartType)comboBoxGraphType.SelectedItem;

                object[,] seriesValues = dboperator.getChartValues(
                    (int)dataGridViewFields.SelectedRows[0].Cells[0].Value,
                    (int)dataGridViewValues.SelectedRows[0].Cells[0].Value,
                    (int)dataGridViewValues.SelectedRows[0].Cells[1].Value,
                    dateTimePicker1.Value,
                    dateTimePicker2.Value);

                for (int i = 0; i < seriesValues.GetLength(0); i++)
                {
                    chart1.Series[textBox2.Text].Points.AddXY(seriesValues[i, 0], seriesValues[i, 1]);
                }
            }
        }

        private void loadValues()
        {
            List<object[]> notes = dboperator.getNoteTypes();
            List<object[]> activities = dboperator.getActivityTypes();

            List<object[]> values = new List<object[]>();

            for (int i = 0; i < notes.Count; i++)
            {
                object[] o = new object[] { 1, notes[i].GetValue(0), notes[i].GetValue(1) };
                values.Add(o);
            }

            for (int i = 0; i < activities.Count; i++)
            {
                object[] o = new object[] { 2, activities[i].GetValue(0), activities[i].GetValue(1) };
                values.Add(o);
            }

            for (int i = 0; i < values.Count; i++)
            {
                dataGridViewValues.Rows.Add(values[i]);
            }
        }

        private void loadEmployees()
        {
            List<object[]> employees = dboperator.getEmployees(userId);

            for (int i = 0; i < employees.Count; i++)
            {
                dataGridViewEmployees.Rows.Add(employees[i]);
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
        }

        private void comboBoxGraphType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormGraphs_Shown(object sender, EventArgs e)
        {
            dataGridViewEmployees.ClearSelection();
            dataGridViewFields.ClearSelection();
            dataGridViewValues.ClearSelection();
            dataGridViewFarms.ClearSelection();
            textBox1.Visible = false;
        }

        private void dataGridViewFields_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFields.SelectedRows.Count > 0)
            {
                int selectedFieldId = (int)dataGridViewFields.SelectedRows[0].Cells[0].Value;

                string query = "SELECT p.name FROM Plants as p JOIN Fields as f ON p.id = f.plant WHERE f.id = " + selectedFieldId;

                string plant = dboperator.select(query).ToString();

                textBox1.Text = "Obecna uprawa:\n" + plant;

                textBox1.Visible = true;
            }
        }
    }
}
