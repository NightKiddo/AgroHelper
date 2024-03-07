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
    public partial class FormBase : Form
    {
        internal static DBOperator dboperator = new DBOperator();
        public FormBase()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Visible = false;
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            this.Close();
        }
    }
}
