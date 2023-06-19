using AgroApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            webView21.CoreWebView2.Navigate(new Uri("C:\\projekty\\AgroApp\\main\\showField.html").ToString());
        }
        public async void sendCords() 
        {
            string coordinates = dboperator.select("SELECT coordinates FROM Fields WHERE id = " + fieldId).ToString();
            await webView21.CoreWebView2.ExecuteScriptAsync($"receiveCords({coordinates});");
            
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            sendCords();
        }
    }
}
