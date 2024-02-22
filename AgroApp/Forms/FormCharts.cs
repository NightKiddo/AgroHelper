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

        object[] seriesTypes = { SeriesChartType.Column, SeriesChartType.StackedColumn ,SeriesChartType.Line, SeriesChartType.Point };
        object[] markerStyleTypes = { MarkerStyle.Square, MarkerStyle.Circle, MarkerStyle.Cross, MarkerStyle.Triangle };
        int userId;
        Farm farm;
        Field selectedField;
        Series selectedSeries;
        public FormCharts()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = "Wykresy";
            loadChartTypes();
            loadMarkerStyles();
            makeSeriesControlsInvisible();
            makeMarkerControlsInvisible();
            loadFarms();
            loadValues();
            loadEmployees();

            dataGridViewValues.Columns[2].Width = dataGridViewValues.Width;
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }

        private void loadChartTypes()
        {
            comboBoxGraphType.Items.AddRange(seriesTypes);
        }

        private void loadMarkerStyles()
        {
            comboBoxMarkerStyles.Items.AddRange(markerStyleTypes);
        }

        private void makeMarkerControlsInvisible()
        {
            labelMarkerStyle.Visible = false;
            labelMarkerWidth.Visible = false;
            trackBarMarkerWIdth.Visible = false;
            buttonChangeMarkerColor.Visible = false;
            comboBoxMarkerStyles.Visible = false;
        }

        private void makeMarkerControlsVisible()
        {
            labelMarkerStyle.Visible = true;
            labelMarkerWidth.Visible = true;
            trackBarMarkerWIdth.Visible = true;
            buttonChangeMarkerColor.Visible = true;
            comboBoxMarkerStyles.Visible = true;

            trackBarMarkerWIdth.Value = selectedSeries.MarkerSize;
        }

        private void makeSeriesControlsVisible()
        {
            checkBox3D.Visible = true;
            checkBoxXminorGrid.Visible = true;
            checkBoxYminorGrid.Visible = true;
            comboBoxSeries.Visible = true;
            trackBarWidth.Visible = true;
            labelSeriesWidth.Visible = true;
            buttonDeleteSeries.Visible = true;
            buttonSeriesColorPick.Visible = true;
            checkBoxMarkers.Visible = true;
        }

        private void makeSeriesControlsInvisible()
        {
            checkBox3D.Visible = false;
            checkBoxXminorGrid.Visible = false;
            checkBoxYminorGrid.Visible = false;
            comboBoxSeries.Visible = false;
            trackBarWidth.Visible = false;
            labelSeriesWidth.Visible = false;
            buttonDeleteSeries.Visible = false;
            buttonSeriesColorPick.Visible = false;
            checkBoxMarkers.Visible = false;
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
            else if (dataGridViewValues.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz typ danych do zaprezentowania");
            }
            else
            {
                List<Activity> activities = farm.Journal.ActivitiesList.Where(x => x.Field.Id == selectedField.Id).ToList();

                for (int i = 0; i < activities.Count; i++)
                {
                    if (activities[i].Field.Id != selectedField.Id)
                    {
                        activities.Remove(activities[i]);
                        i--; continue;
                    }

                    if (activities[i].Finish_date.Date < dateTimePicker1.Value.Date)
                    {
                        activities.Remove(activities[i]);
                        i --; continue;
                    }

                    if (activities[i].Finish_date.Date > dateTimePicker2.Value.Date)
                    {
                        activities.Remove(activities[i]);
                        i--; continue;
                    }

                    if (activities[i].Type != null)
                    {
                        if (activities[i].Type.Id != (int)dataGridViewValues.SelectedRows[0].Cells[1].Value)
                        {
                            activities.Remove(activities[i]);
                            i--; continue;
                        }
                    }

                    if (activities[i].Employee != null)
                    {
                        if (activities[i].Employee.Id != (int)dataGridViewEmployees.SelectedRows[0].Cells[0].Value)
                        {
                            activities.Remove(activities[i]);
                            i--; continue;
                        }
                    }
                }

                if (activities.Count != 0)
                {
                    activities = activities.OrderBy(a => a.Finish_date).ToList();
                    List<DateTime> xValues = new List<DateTime>();
                    List<double> yValues = new List<double>();
                    foreach (Activity a in activities)
                    {
                        xValues.Add(a.Finish_date);
                        yValues.Add(a.Value);                        
                    }

                    Series series = new Series(textBox2.Text);
                    chart1.Series.Add(series);
                    series.XValueType = ChartValueType.Date;
                    series.ChartType = (SeriesChartType)comboBoxGraphType.SelectedItem;

                    series.Points.DataBindXY(xValues, yValues);

                    if (series.ChartType == SeriesChartType.Column)
                    {
                        series["PixelPointWidth"] = "86";
                    }

                    comboBoxSeries.Items.Add(series.Name);

                    if(chart1.Series.Count > 0)
                    {
                        makeSeriesControlsVisible();
                    }
                }
                else
                {
                    MessageBox.Show("Brak danych");
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

        private void powrótToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDeleteSeries_Click(object sender, EventArgs e)
        {
            chart1.Series.Remove(chart1.Series.FindByName(comboBoxSeries.Text));
            comboBoxSeries.Items.Remove(comboBoxSeries.SelectedItem);
            if(chart1.Series.Count == 0)
            {
                makeSeriesControlsInvisible();
            }
        }

        private void buttonSeriesColorPick_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            chart1.Series[comboBoxSeries.SelectedItem.ToString()].Color = colorDialog.Color;
        }

        private void comboBoxSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSeries = chart1.Series[comboBoxSeries.SelectedItem.ToString()];
            if(selectedSeries.ChartType == SeriesChartType.Column)
            {
                trackBarWidth.Maximum = 320;
                trackBarWidth.Minimum = 40;
                string width = selectedSeries["PixelPointWidth"].ToString();
                trackBarWidth.Value = Convert.ToInt32(width);
            }
            else
            {
                trackBarWidth.Minimum = 1;
                trackBarWidth.Maximum = 20;
                trackBarWidth.Value = selectedSeries.BorderWidth; 
            }
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxSeries.SelectedItem != null)
            {
                if (selectedSeries.ChartType == SeriesChartType.Column)
                {
                    selectedSeries["PixelPointWidth"] = trackBarWidth.Value.ToString();
                }
                else
                {
                    selectedSeries.BorderWidth = trackBarWidth.Value;
                }
            }
        }

        private void checkBoxMarkers_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxSeries.SelectedItem != null)
            {

                if (checkBoxMarkers.Checked)
                {
                    selectedSeries.MarkerStyle = MarkerStyle.Square;
                    selectedSeries.MarkerSize = 15;
                    selectedSeries.MarkerColor = Color.Black;
                    makeMarkerControlsVisible();
                }
                else
                {
                    selectedSeries.MarkerStyle = MarkerStyle.None;
                    makeMarkerControlsInvisible();
                }
            }
        }

        private void buttonChangeMarkerColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            selectedSeries.MarkerColor = colorDialog.Color;
        }

        private void trackBarMarkerWIdth_Scroll(object sender, EventArgs e)
        {
            selectedSeries.MarkerSize = trackBarMarkerWIdth.Value;
        }

        private void comboBoxMarkerStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSeries.MarkerStyle = (MarkerStyle)comboBoxMarkerStyles.SelectedItem;
        }

        private void checkBoxXminorGrid_CheckedChanged(object sender, EventArgs e)
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
    }
}
