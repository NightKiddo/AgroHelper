using AgroApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Forms
{
    public partial class FormAddField : Form
    {
        int fieldDrawn = 0;
        string coordinates;
        int farmId;
        DBOperator dboperator = FormBase.dboperator;        
        public FormAddField(int farmId)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
            this.Text = "Dodawanie pola";
            this.farmId = farmId;
        }

        private void FormAddField_Load(object sender, EventArgs e)
        {
            loadPlants();
            string x = Environment.CurrentDirectory;
            string y = Directory.GetParent(x).Parent.Parent.FullName;
            webView21.Source = new Uri(y+"\\main\\index.html");
        }
        private void addField(int option) 
        {
            string values;
            int plantId;
            if (dataGridView1.SelectedRows.Count == 0)
            {
                values = "'" + coordinates + "','" + textBox1.Text + "','" + richTextBox1.Text + "'," + farmId + ", " + "NULL";
            }
            else
            {
                Int32.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out plantId);
                values = "'" + coordinates + "','" + textBox1.Text + "','" + richTextBox1.Text + "'," + farmId + ", " + plantId;
            }
            InsertQuery queryField = new InsertQuery("Fields", "coordinates,name,description,farm,plant", values);
            if (option == 0)
            {

                if (dboperator.insert(queryField) != 0)
                {
                    MessageBox.Show("Dodano pomyślnie", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Błąd", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if(option == 1)
            {
                if (dboperator.insert(queryField) != 0)
                {
                    MessageBox.Show("Dodano pomyślnie", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    webView21.Reload();
                    fieldDrawn = 0;
                    dataGridView1.ClearSelection();
                    textBox1.Text = "";
                    richTextBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Błąd", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (fieldDrawn == 0)
            {
                MessageBox.Show("Nie narysowano pola", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                addField(1);
            }
        }

        private void webView21_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            coordinates = e.TryGetWebMessageAsString();
            fieldDrawn = 1;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if(fieldDrawn != 0)
            {
                addField(0);
            }            
            FormAddGarage formAddGarage = new FormAddGarage(farmId, 0);
            formAddGarage.ShowDialog();
            this.Close();
        }

        private void loadPlants() 
        {
            dataGridView1.AutoGenerateColumns = true;
            var source = new BindingSource();
            source.DataSource = dboperator.plantsCollection;
            dataGridView1.DataSource = source;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = dataGridView1.Width;
            dataGridView1.Columns[2].Visible = false;            
        }

        private void FormAddField_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
