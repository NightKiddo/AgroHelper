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
    public partial class FormRegister : Form
    {
        private DBOperator dboperator = new DBOperator();
        public FormRegister()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == String.Empty || textBoxPassword.Text == String.Empty) 
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
                return;
            }
            if (dboperator.register(textBoxLogin.Text, textBoxPassword.Text) == 0)
            {
                MessageBox.Show("Użytkownik o takim loginie już istnieje");
            }
            else {
                MessageBox.Show("Zarejestrowano pomyślnie");
            };

        }
    }
}
