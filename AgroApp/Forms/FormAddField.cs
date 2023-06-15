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
            MessageBox.Show((string)dboperator.select("SELECT MAX(id) FROM Farms WHERE [user] = "+userId));

            //if (fieldDrawn == 0) 
            //{
            //    MessageBox.Show("Nie narysowano pola","Błąd",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
            //else {
            //    InsertQuery queryField = new InsertQuery("Fields", "coordinates", coordinates);
            //    //InsertQuery queryFarm = new InsertQuery("Fields_farm", "farm,field,", )
            //    if (dboperator.insert(queryField) != 0)
            //    {
            //        MessageBox.Show("Dodano pomyślnie", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.Close();
            //    }
            //    else 
            //    {
            //        MessageBox.Show("Błąd", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void webView21_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            coordinates = e.TryGetWebMessageAsString();
            fieldDrawn = 1;
        }
    }
}
