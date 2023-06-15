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
        int userId;
        DBOperator dboperator= new DBOperator();
        public FormAddFarm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void addFarm(int option) 
        {
            string values = "'" + textBox1.Text.ToString() + "'," + userId;
            InsertQuery queryFarm = new InsertQuery("Farms", "name,[user]", values);
            if (option == 0)
            {

                if (dboperator.insert(queryFarm) != 0)
                {
                    MessageBox.Show("Dodano pomyślnie");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Błąd");
                };
            }
            else{
                
                if (dboperator.insert(queryFarm) != 0)
                {            
                    FormAddField formAddField = new FormAddField(userId);
                    formAddField.ShowDialog();
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
