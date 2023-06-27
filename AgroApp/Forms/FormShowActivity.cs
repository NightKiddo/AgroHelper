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
            string name, description, fieldName;
            DateTime startDate, finishDate;

            activity = dboperator.getActivity(activityId);

            name = activity[0].ToString();
            description = activity[1].ToString();
            DateTime.TryParse(activity[2].ToString(), out startDate);
            DateTime.TryParse(activity[3].ToString(), out finishDate);

            fieldName = dboperator.select("SELECT name FROM Fields WHERE id = " + activity[4]).ToString();

            label1.Text = name;
            richTextBox1.Text = description;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = finishDate;
            label4.Text = "Pole: " + fieldName;
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
