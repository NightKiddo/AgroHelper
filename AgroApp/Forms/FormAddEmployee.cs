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
    public partial class FormAddEmployee : Form
    {
        private DBOperator dboperator = new DBOperator();
        int userId;
        public FormAddEmployee(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            InsertQuery query = new InsertQuery("Employees", "name, user", textBox1.Text + ", " + userId.ToString());
            dboperator.insert(query);
            this.Close();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
