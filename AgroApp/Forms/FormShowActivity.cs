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
            if (activity.Type == null)
            {
                label5.Text = "Rodzaj pracy: brak";
            }
            else
            {
                label5.Text = "Rodzaj pracy: " + activity.Type.Type;
            }
            if (activity.Employee == null)
            {
                label6.Text = "Pracownik: brak";
            }
            else
            {
                label6.Text = "Pracownik: " + activity.Employee.Name;
            }

            if (activity.Machine == null)
            {
                label7.Text = "Maszyna: brak";
            }
            else
            {
                label7.Text = "Maszyna: " + activity.Machine.Name;
            }

            if (activity.Tool == null)
            {
                label8.Text = "Narzędzie: brak";
            }
            else
            {
                label8.Text = "Narzędzie: " + activity.Tool.Name;
            }

            if (activity.Resource == null)
            {
                label9.Text = "Użyte zasoby: brak";
            }
            else
            {
                label9.Text = "Użyte zasoby: " + activity.Resource.Name;
            }

            label10.Text = "Ilość: " + activity.Value;

            switch(activity.Type.Type) 
            {
                case "Orka":
                    label10.Text += " cm głębokości";
                    break;
                case "Siew":
                    label10.Text += " kg/ha";
                    break;
                case "Podlewanie":
                    label10.Text += " l/ha";
                    break;
                case "Nawożenie":
                    label10.Text += " kg/ha";
                    break;
                case "Oprysk":
                    label10.Text += " l/ha";
                    break;
                case "Zbiory":
                    label10.Text += " t/ha";
                    break;
            }
        }

        private void buttonShowField_Click(object sender, EventArgs e)
        {
            FormShowField formShowField = new FormShowField(activity.Field);
            formShowField.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Activities", "id", activity.Id);
            dboperator.delete(query);
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Farm farm = null;
            foreach (Farm f in dboperator.getFarms())
            {
                foreach (Activity a in f.Journal.ActivitiesList)
                {
                    if (a.Id == activity.Id)
                    {
                        farm = f; break;
                    }
                }
            }
            FormAddActivity formAddActivity = new FormAddActivity(farm, activity.Id);
            formAddActivity.ShowDialog();

            foreach (Farm f in dboperator.getFarms())
            {
                if (farm.Id == f.Id)
                {
                    farm = f; break;
                }
            }

            foreach (Activity a in farm.Journal.ActivitiesList)
            {
                if (activity.Id == a.Id)
                {
                    activity = a;
                }
            }
            loadActivity();
        }
    }
}
