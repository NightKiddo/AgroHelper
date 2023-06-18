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
        int fieldDrawn = 0;
        string coordinates;
        int farmId;
        DBOperator dboperator = new DBOperator();
        public FormAddField(int userId, int farmId)
        {
            InitializeComponent();
            this.userId = userId;
            this.farmId = farmId;
            
        }

        private void FormAddField_Load(object sender, EventArgs e)
        {
            webView21.Source = new Uri("C:\\projekty\\AgroApp\\main\\index.html");
        }
        private void addField(int option) 
        {
            if (option == 0)
            {
                InsertQuery queryField = new InsertQuery("Fields", "coordinates,farm", "'" + coordinates + "'," + farmId);
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
                InsertQuery queryField = new InsertQuery("Fields", "coordinates,farm", "'" + coordinates + "'," + farmId);
                if (dboperator.insert(queryField) != 0)
                {
                    MessageBox.Show("Dodano pomyślnie", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    webView21.Reload();
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
            addField(0);
            FormAddGarage formAddGarage = new FormAddGarage(farmId);
            formAddGarage.ShowDialog();
            this.Close();
        }
    }
}
