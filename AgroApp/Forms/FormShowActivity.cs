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
        DBOperator dboperator = FormBase.dboperator;
        Activity activity;
        public FormShowActivity(Activity activity)
        {
            InitializeComponent();
            this.activity = activity;
            loadActivity();
        }

        private void loadActivity()
        {
            label1.Text = activity.Name;
            richTextBox1.Text = activity.Description;
            dateTimePicker1.Value = activity.Start_date;
            dateTimePicker2.Value = activity.Finish_date;
            label4.Text = "Pole: " + activity.Field.Name;
            label5.Text = "Rodzaj pracy: " + activity.Type.Type;
            if (activity.Employee == null)
            {
                label6.Text = "Pracownik: brak";
            }
            else
            {
                label6.Text = "Pracownik: " + activity.Employee.Name;
            }
            
            if(activity.Machine == null)
            {
                label7.Text = "Maszyna: brak";
            }
            else
            {
                label7.Text = "Maszyna: " + activity.Machine.Name;
            }
            
            if(activity.Tool == null)
            {
                label8.Text = "Narzędzie: brak";
            }
            else
            {
                label8.Text = "Narzędzie: " + activity.Tool.Name;
            }

            if(activity.Resource == null)
            {
                label9.Text = "Użyte zasoby: brak";
            }
            else
            {
                label9.Text = "Użyte zasoby: " + activity.Resource.Name;
            }
            
            label10.Text = "Ilość: " + activity.Value;
        }

        private void buttonShowField_Click(object sender, EventArgs e)
        {            
            FormShowField formShowField = new FormShowField(activity.Field.Id);
            formShowField.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Activities", "id", activityId);
            dboperator.delete(query);
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
