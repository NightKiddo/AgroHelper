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

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            InsertQuery queryFarm = new InsertQuery("Farms","name","'"+textBox1.Text.ToString()+"'");
            string values = userId.ToString() + ",(SELECT MAX(id) FROM Farms)"; //ZMIEŃ TO
            InsertQuery queryUser = new InsertQuery("Users_farm",
                "[user],farm", values);
                

            if (dboperator.insert(queryFarm) != 0)
            {
                if (dboperator.insert(queryUser) != 0)
                MessageBox.Show("Dodano pomyślnie");
                this.Close();
            }
            else 
            {
                MessageBox.Show("Błąd");
            };
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            FormAddField formAddField = new FormAddField(userId);
            formAddField.ShowDialog();
        }
    }
}
