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
    public partial class FormAddFarm : Form
    {
        DBOperator dboperator = FormBase.dboperator;
        int userId;
        public FormAddFarm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = "Dodawanie gospodarstwa";
            userId = dboperator.user.Id;
        }

        private void addFarm(int option) 
        {
            string values = "'" + textBox1.Text.ToString() + "'," + userId;
            InsertQuery queryFarm = new InsertQuery("Farms", "name,[user]", values, "id");           

            int farmId = dboperator.insertWithIdOutput(queryFarm);

            InsertQuery queryJournal = new InsertQuery("Journals", "farm", farmId.ToString());

            if (option == 0)
            {

                if (farmId != 0)
                {
                    if (dboperator.insert(queryJournal) != 0) 
                    {
                        MessageBox.Show("Dodano pomyślnie");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Błąd");
                }
            }
            else{
                
                if (farmId != 0)
                {
                    if (dboperator.insert(queryJournal) != 0)
                    {                                               
                        FormAddField formAddField = new FormAddField(farmId);
                        formAddField.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Błąd");
                };
            }
        }
        private void buttonEnd_Click(object sender, EventArgs e)
        {
            addFarm(0);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            addFarm(1);
        }
    }
}
