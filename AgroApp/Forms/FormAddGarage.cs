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
    public partial class FormAddGarage : Form
    {
        int farmId, invokeType;
        DBOperator dboperator = FormBase.dboperator;
        public FormAddGarage(int farmId, int invokeType)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = "Dodawanie garażu";
            this.farmId = farmId;
            this.invokeType = invokeType;       // 0 is when this form is called in the process of adding a farm, 1 when called individually from FormShowFarm
        }

        private void addGarage(int option) 
        {
            if(textBox1.Text == String.Empty)
            {
                this.Close();
            }
            else
            {
                if (invokeType == 0)
                {
                    InsertQuery query = new InsertQuery("Garages", "name, farm", "'" + textBox1.Text + "'," + farmId);
                    if (option == 0)
                    {
                        if (dboperator.insert(query) != 0)
                        {
                            MessageBox.Show("Dodano pomyślnie!", "Suckes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Błąd");
                        }
                    }
                    else
                    {
                        if (dboperator.insert(query) != 0)
                        {
                            MessageBox.Show("Dodano pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormAddStorage formAddStorage = new FormAddStorage(farmId,0);
                            this.Visible = false;
                            formAddStorage.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Błąd");
                        }
                    }
                }
                else 
                {
                    InsertQuery query = new InsertQuery("Garages", "name, farm", "'" + textBox1.Text + "'," + farmId);
                    if (dboperator.insert(query) != 0)
                    {
                        MessageBox.Show("Dodano pomyślnie!", "Suckes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Błąd");
                    }
                }
            }
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            addGarage(1);
        }
        private void buttonEnd_Click(object sender, EventArgs e)
        {
            addGarage(0);
        }
    }
}
