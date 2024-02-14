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
    public partial class FormShowMachine : Form
    {
        DBOperator dboperator = FormBase.dboperator;
        Machine machine;
        Farm farm;
        public FormShowMachine(Machine machine, Farm farm)
        {
            InitializeComponent();
            this.machine = machine;
            this.farm = farm;
            loadData();            
        }

        private void loadData()
        {
            labelName.Text = machine.Name;
            if (machine.Type != null)
            {
                labelType.Text = machine.Type.Type;
            }
            labelMileage.Text = "Przebieg: " + machine.Mileage.ToString();
            dateTimePickerInspection.Value = machine.Inspection_date;
            labelFuel.Text = "Stan paliwa: " + machine.Fuel.ToString();
        }

        private void prepareJournal()
        {
            List<object[]> journalEntries = new List<object[]>();

            foreach (Activity a in farm.Journal.ActivitiesList)
            {
                if (a.Machine.Id == machine.Id)
                {
                    journalEntries.Add(new object[] { a.Name, a.Type.Type, a.Start_date.ToString("dd-MM-yyyy"), a.Finish_date.ToString("dd-MM-yyyy"), a.Value });
                }
            }
            for (int i = 0; i < journalEntries.Count; i++)
            {
                dataGridViewActivities.Rows.Add(journalEntries[i]);
            }

            dataGridViewActivities.Sort(dataGridViewActivities.Columns[2], ListSortDirection.Descending);
            dataGridViewActivities.ClearSelection();
        }
    }
}
