using AgroApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Forms
{
    public partial class FormShowField : Form
    {
        Field field;
        DBOperator dboperator = FormBase.dboperator;
        public FormShowField(Field field)
        {
            InitializeComponent();
            this.field = field;
            InitBrowser();
        }
        private async Task initiated()
        {
            await webView21.EnsureCoreWebView2Async(null);
        }
        public async void InitBrowser()
        {
            await initiated();
            string x = Environment.CurrentDirectory;
            string y = Directory.GetParent(x).Parent.Parent.FullName;
            webView21.CoreWebView2.Navigate(new Uri(y + "\\main\\showField.html").ToString());
        }
        public async void sendCords()
        {
            await webView21.CoreWebView2.ExecuteScriptAsync($"receiveCords({field.Coordinates});");

        }

        private void prepareJournal()
        {
            Farm farm = null;
            foreach (Farm f in dboperator.getFarms())
            {
                foreach (Field fl in f.FieldsList)
                {
                    if (fl.Id == field.Id)
                    {
                        farm = f;
                    }
                }
            }

            List<object[]> journalEntries = new List<object[]>();

            foreach (Activity a in farm.Journal.ActivitiesList)
            {
                if (a.Field.Id == field.Id)
                {
                    journalEntries.Add(new object[] { a.Name, a.Type.Type, a.Start_date.ToString("dd-MM-yyyy"), a.Finish_date.ToString("dd-MM-yyyy"), a.Value});
                }
            }

            foreach (Note n in farm.Journal.NotesList)
            {
                if (n.Field.Id == field.Id)
                {
                    journalEntries.Add(new object[] { n.Name, n.Type.Type, n.Start_date.ToString("dd-MM-yyyy"), n.Finish_date.ToString("dd-MM-yyyy"), n.Value });
                }
            }

            for (int i = 0; i < journalEntries.Count; i++)
            {
                dataGridViewJournal.Rows.Add(journalEntries[i]);
            }

            dataGridViewJournal.Sort(dataGridViewJournal.Columns[2], ListSortDirection.Descending);
            dataGridViewJournal.ClearSelection();
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            sendCords();
            labelNameAndPlant.Text = field.Name + ", " + field.Plant.Name;
            richTextBoxDesciption.Text = field.Description;
            prepareJournal();
        }
    }
}
