using AgroApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Forms
{
    public partial class FormShowActivity : Form
    {
        int activityId;
        DBOperator dboperator = new DBOperator();
        object[] activity;
        public FormShowActivity(int activityId)
        {
            InitializeComponent();
            this.activityId = activityId;
            loadActivity();
        }

        private void loadActivity() 
        {
            string name, description, type, fieldName, employeeName, machineName, toolName;
            DateTime startDate, finishDate;

            activity = dboperator.getActivity(activityId);

            name = activity[0].ToString();
            description = activity[1].ToString();
            DateTime.TryParse(activity[2].ToString(), out startDate);
            DateTime.TryParse(activity[3].ToString(), out finishDate);


            fieldName = dboperator.select("SELECT name FROM Fields WHERE id = " + activity[4]).ToString();
            type = dboperator.select("SELECT type FROM Activity_types WHERE id = " + activity[5]).ToString();

            if (activity[6] == DBNull.Value)
            {
                employeeName = "";                
            }
            else 
            {
                employeeName = dboperator.select("SELECT name FROM Employees WHERE id = " + activity[6]).ToString();
            }

            if (activity[7] == DBNull.Value)
            {
                machineName = "";
            }
            else 
            {
                machineName = dboperator.select("SELECT name FROM Machines WHERE id = " + activity[7]).ToString();
            }


            if (activity[8] == DBNull.Value)
            {
                toolName = "";
            }
            else 
            {
                toolName = dboperator.select("SELECT name FROM Tools WHERE id = " + activity[8]).ToString();
            }
            

            label1.Text = name;
            richTextBox1.Text = description;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = finishDate;
            label4.Text = "Pole: " + fieldName;
            label5.Text = "Rodzaj pracy: " + type;
            label6.Text = "Pracownik: " + employeeName;
            label7.Text = "Maszyna: " + machineName;
            label8.Text = "Narzędzie: " + toolName;
        }

        private void buttonShowField_Click(object sender, EventArgs e)
        {
            int fieldId;
            Int32.TryParse(activity[4].ToString(), out fieldId);
            FormShowField formShowField = new FormShowField(fieldId);
            formShowField.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Activities", "id", activityId);
            dboperator.delete(query);
            this.Close();
        }
    }
}
