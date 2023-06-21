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
        int fieldId;
        DBOperator dboperator = new DBOperator();
        public FormShowField(int fieldId)
        {
            InitializeComponent();
            this.fieldId = fieldId;
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
            webView21.CoreWebView2.Navigate(new Uri(y+"\\main\\showField.html").ToString());
        }
        public async void sendCords() 
        {
            string coordinates = dboperator.select("SELECT coordinates FROM Fields WHERE id = " + fieldId).ToString();
            await webView21.CoreWebView2.ExecuteScriptAsync($"receiveCords({coordinates});");
            
        }

        public void getName() 
        {
            string name = dboperator.select("SELECT name FROM Fields WHERE id = " + fieldId).ToString();
            textBox1.Text = name;
        }

        public void getDescription() 
        {
            string description = dboperator.select("SELECT description FROM Fields WHERE id = "+fieldId).ToString();
            richTextBox1.Text = description;
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            sendCords();
            getName();
            getDescription();
        }
    }
}
