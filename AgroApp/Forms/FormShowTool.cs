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
    public partial class FormShowTool : Form
    {
        DBOperator dboperator = FormBase.dboperator;
        Tool tool;
        Farm farm;
        Garage garage;
        public FormShowTool(Farm farm, Garage garage, Tool tool)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = tool.Name;
            this.farm = farm;
            this.tool = tool;
            this.garage = garage;
            loadTool();
        }

        private void loadTool()
        {
            labelName.Text = tool.Name;
            if (tool.Type != null)
            {
                labelType.Text = tool.Type.Type;
            }
            labelMileage.Text = "Przebieg: " + tool.Mileage.ToString();
            
            prepareJournal();
        }

        private void prepareJournal()
        {
            dataGridViewActivities.Rows.Clear();

            List<object[]> journalEntries = new List<object[]>();

            foreach (Activity a in farm.Journal.ActivitiesList)
            {
                if (a.Tool != null && a.Tool.Id == tool.Id)
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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormAddTool formAddTool = new FormAddTool(garage, tool.Id);
            formAddTool.ShowDialog();

            garage.ToolsList = dboperator.getTools(garage.Id);
            tool = garage.ToolsList.Find(x => x.Id == tool.Id);
            loadTool();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("tools", "id", tool.Id);
            dboperator.delete(query);
            this.Close();
        }

        private void powrótToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
