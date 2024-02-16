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
        DBOperator dboperator = FormBase.dboperator;

        object[] seriesTypes = { SeriesChartType.Column, SeriesChartType.Line, SeriesChartType.Point };
        int userId;
        Farm farm;
        Field selectedField;
        public FormCharts()
        {
            InitializeComponent();


            loadChartTypes();
            loadFarms();
            loadValues();
            loadEmployees();

            dataGridViewValues.Columns[2].Width = dataGridViewValues.Width;
            chart1.Series.Clear();
        }

        private void loadChartTypes()
        {
            comboBoxGraphType.Items.AddRange(seriesTypes);
        }

        private void loadFarms()
        {
            List<Farm> farms = dboperator.user.FarmsList;
            dataGridViewFarms.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = dboperator.user.FarmsList;
            dataGridViewFarms.DataSource = source;

            dataGridViewFarms.Columns[1].Width = dataGridViewFarms.Width;

            dataGridViewFarms.Columns[0].Visible = false;
            dataGridViewFarms.Columns[2].Visible = false;
            dataGridViewFarms.Columns[3].Visible = false;
            dataGridViewFarms.Columns[4].Visible = false;
            dataGridViewFarms.Columns[5].Visible = false;

            dataGridViewFarms.ClearSelection();
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
                    return;
                }
            }

            if (dataGridViewFields.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz choć jedno pole");
            }
            else if (comboBoxGraphType.SelectedIndex <= -1)
            {
                MessageBox.Show("Wybierz rodzaj wykresu");
            }
            else
            {
                Series series = new Series(textBox2.Text);
                chart1.Series.Add(series);
                chart1.Series[textBox2.Text].XValueType = ChartValueType.Date;
                series.ChartType = (SeriesChartType)comboBoxGraphType.SelectedItem;


                List<Activity> activities = farm.Journal.ActivitiesList.Where(x => x.Field.Id == selectedField.Id).ToList();
                if (activities.Count != 0)
                {
                    foreach (Activity a in activities)
                    {
                        chart1.Series[textBox2.Text].Points.AddXY(a.Finish_date, a.Value);
                    }
                }
            }
        }

        private void loadValues()
        {
            List<NoteType> notes = dboperator.noteTypesCollection;
            List<ActivityType> activities = dboperator.activityTypesCollection;

            List<object[]> values = new List<object[]>();

            for (int i = 0; i < notes.Count; i++)
            {
                object[] o = new object[] { 1, notes[i].Id, notes[i].Type };
                values.Add(o);
            }

            for (int i = 0; i < activities.Count; i++)
            {
                object[] o = new object[] { 2, activities[i].Id, activities[i].Type };
                values.Add(o);
            }

            for (int i = 0; i < values.Count; i++)
            {
                dataGridViewValues.Rows.Add(values[i]);
            }
        }

        private void loadEmployees()
        {
            dataGridViewEmployees.Rows.Clear();

            FormBase.dboperator.user.EmployeesList = FormBase.dboperator.getEmployees();

            var source = new BindingSource();
            source.DataSource = FormBase.dboperator.getEmployees();
            dataGridViewEmployees.DataSource = source;

            dataGridViewEmployees.Columns[0].Visible = false;
            dataGridViewEmployees.Columns[1].Width = dataGridViewEmployees.Width;
            dataGridViewEmployees.ClearSelection();
        }

        private void dataGridViewFarms_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFarms.SelectedRows.Count != 0)
            {
                farm = FormBase.dboperator.user.FarmsList.Find(x => x.Id == (int)dataGridViewFarms.SelectedRows[0].Cells[0].Value);

                var source = new BindingSource();
                source.DataSource = farm.FieldsList;
                dataGridViewFields.DataSource = source;

                dataGridViewFields.Columns[0].Visible = false;
                dataGridViewFields.Columns[2].Visible = false;
                dataGridViewFields.Columns[3].Visible = false;
                dataGridViewFields.Columns[4].Visible = false;
                dataGridViewFields.Columns[5].Visible = false;

                dataGridViewFields.Columns[1].Width = dataGridViewFields.Width;                
            }
        }

        private void dataGridViewFields_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFields.SelectedRows.Count > 0)
            {
                Field field = farm.FieldsList.Find(x => x.Id == (int)dataGridViewFields.SelectedRows[0].Cells[0].Value);
                textBox1.Text = "Obecna uprawa:\n" + field.Plant.Name;

                textBox1.Visible = true;

                selectedField = field;
            }
        }

        private void checkBox3D_CheckedChanged(object sender, EventArgs e)
        {
            if (chart1.ChartAreas[0].Area3DStyle.Enable3D == false)
            {
                chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else
            {
                chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chart1.ChartAreas[0].AxisX.MinorGrid.Enabled == false)
            {
                chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            }
            else
            {
                chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            }

        }

        private void checkBoxYminorGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (chart1.ChartAreas[0].AxisY.MinorGrid.Enabled == false)
            {
                chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            }
            else
            {
                chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Series series = new Series("ser");
            chart1.Series.Add(series);
            chart1.Series["ser"].XValueType = ChartValueType.Date;
            series.ChartType = SeriesChartType.Line;


            object[,] seriesValues = dboperator.getChartValues(
                1,
                2,
                3,
                new DateTime(2023, 10, 16),
                DateTime.Today);


            for (int i = 0; i < seriesValues.GetLength(0); i++)
            {
                chart1.Series["ser"].Points.AddXY(seriesValues[i, 0], seriesValues[i, 1]);
            }

        }
    }
}
