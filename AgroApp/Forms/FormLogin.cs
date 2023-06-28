using AgroApp.Forms;
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

namespace AgroApp
{
    public partial class LoginForm : Form
    {
        private DBOperator dboperator = new DBOperator();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try 
            {
                int userId = dboperator.login(textBoxLogin.Text, textBoxPassword.Text);
                if (userId != 0)
                {
                    FormMainMenu formMainMenu = new FormMainMenu(userId);
                    formMainMenu.ShowDialog();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
        }
    }
}
