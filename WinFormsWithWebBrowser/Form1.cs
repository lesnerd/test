using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsWithWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(new Uri("http://rpc3328.corp.ncr.com:8005/OA_HTML/RF.jsp?function_id=28716&resp_id=-1&resp_appl_id=-1&security_group_id=0&lang_code=US&params=O7Ffu1b0Wrt2JJuIBxHgUmoBUSja3gr8hVR80HTkiiA&oas=sa4r9hc3sFfqt4cWNJzKmw.."));
            AddDollar();
        }

        private static void AddDollar()
        {
            string str1 = "$1,234.56";
            string str2 = "$9,876.54";
            
            if (str1[0] != str2[0])
                return;
            char sign = str1[0];
            str1 = str1.Remove(0,1);
            str2 = str2.Remove(0,1);

            double result = double.Parse(str1) + double.Parse(str2);
            string res = result.ToString("C2");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
