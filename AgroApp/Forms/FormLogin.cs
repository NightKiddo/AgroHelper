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
    public partial class FormLogin : Form
    {        
        public FormLogin()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = "Logowanie";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try 
            {
                int userId = FormBase.dboperator.login(textBoxLogin.Text, textBoxPassword.Text);
                if (userId != 0)
                {
                    FormMainMenu formMainMenu = new FormMainMenu();
                    this.Visible = false;
                    formMainMenu.ShowDialog();
                    this.Visible = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            this.Visible = false;
            formRegister.ShowDialog();
            this.Visible = true;
        }
    }
}
