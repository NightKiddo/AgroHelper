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
    public partial class FormShowStorage : Form
    {
        int storageId;
        DBOperator dboperator = new DBOperator();
        List<object[]> resources = new List<object[]>();
        public FormShowStorage(int storageId)
        {
            InitializeComponent();
            this.storageId = storageId;
            loadResources();
        }

        private void loadResources() 
        {
            dataGridView1.Rows.Clear();
            resources = dboperator.getResources(storageId);

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = (int)(dataGridView1.Width * 0.25);
            }

            for (int j = 0; j < resources.Count; j++)
            {
                dataGridView1.Rows.Add(resources[j]);
            }

            dataGridView1.ClearSelection();
        }
    }
}
