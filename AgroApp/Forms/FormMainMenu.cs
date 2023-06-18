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
    public partial class FormMainMenu : Form
    {
        int userId;
        public FormMainMenu(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void buttonAddFarm_Click(object sender, EventArgs e)
        {
            FormAddFarm formAddFarm = new FormAddFarm(userId);
            formAddFarm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormShowField formShowField = new FormShowField();
            formShowField.ShowDialog();
        }
    }
}
