using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mecânica
{
    public partial class frmWebBrowser : Form
    {
        public frmWebBrowser(string codHtml)
        {
            InitializeComponent();
            CodHtml = codHtml;
        }
   
        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            webBrowserPrincipal.Navigate(CodHtml);
        }
        private string _codHtml;
        public string CodHtml;

        public string CodHtml1 { get => _codHtml; set => _codHtml = value; }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            webBrowserPrincipal.Print();
        }

        private void tsbVisualizar_ButtonClick(object sender, EventArgs e)
        {
            webBrowserPrincipal.ShowPrintPreviewDialog();
        }
    }
}
