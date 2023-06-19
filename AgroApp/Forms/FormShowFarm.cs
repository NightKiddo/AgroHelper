using AgroApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Forms
{
    public partial class FormShowFarm : Form
    {
        int farmId;
        DBOperator dboperator = new DBOperator();
        public FormShowFarm(int farmId)
        {
            InitializeComponent();
            this.farmId = farmId;
        }
        private void loadFields()
        {
            string query = "SELECT id, name FROM Fields WHERE farm = " + farmId;
            dboperator.connect();
            dboperator.getConn().Open();

            SqlCommand command = dboperator.getCommand();
            SqlDataReader reader = dboperator.getReader();

            while (reader.Read())
            {
                string[] row = new string[] { reader.GetString(0), reader.GetString(1) };

                dataGridView1.Rows.Add(row);
            }

            reader.Close();
            dboperator.getConn().Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int fieldId;
            int.TryParse(row.Cells[0].Value.ToString(), out fieldId);
            FormShowField formShowField = new FormShowField(fieldId);
        }
    }
}
