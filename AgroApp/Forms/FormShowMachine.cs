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
        Garage garage;
        public FormShowMachine(Farm farm, Garage garage, Machine machine)
        {
            InitializeComponent();
            this.machine = machine;
            this.garage = garage;
            this.farm = farm;
            loadMachine();
        }

        private void loadMachine()
        {
            labelName.Text = machine.Name;
            if (machine.Type != null)
            {
                labelType.Text = machine.Type.Type;
            }
            labelMileage.Text = "Przebieg: " + machine.Mileage.ToString();
            if (machine.Inspection_date < DateTimePicker.MinimumDateTime)
            {
                dateTimePickerInspection.Visible = false;
            }
            else
            {
                dateTimePickerInspection.Value = machine.Inspection_date;
            }
            labelFuel.Text = "Stan paliwa: " + machine.Fuel.ToString();
            prepareJournal();
        }

        private void prepareJournal()
        {
            dataGridViewActivities.Rows.Clear();

            List<object[]> journalEntries = new List<object[]>();

            foreach (Activity a in farm.Journal.ActivitiesList)
            {
                if (a.Machine != null && a.Machine.Id == machine.Id)
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("machines", "id", machine.Id);
            dboperator.delete(query);
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormAddMachine formAddMachine = new FormAddMachine(garage, machine.Id);
            formAddMachine.ShowDialog();

            garage.MachinesList = dboperator.getMachines(garage.Id);
            machine = garage.MachinesList.Find(x => x.Id == machine.Id);
            loadMachine();
        }
    }
}
