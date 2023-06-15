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
    public partial class FormAddField : Form
    {
        int userId;
        DBOperator dboperator = new DBOperator();
        public FormAddField(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FormAddField_Load(object sender, EventArgs e)
        {
            webView21.Source = new Uri("C:\\projekty\\AgroApp\\main\\index.html");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //InsertQuery insert = new InsertQuery("Fields","coordinates")
        }
    }
}
