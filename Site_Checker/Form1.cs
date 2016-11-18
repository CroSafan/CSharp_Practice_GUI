using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Site_Checker
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Site Checker with Time Scheduling - 
        /// An application that attempts to connect
        /// to a website or server every so many minutes
        /// or a given time and check if it is up. 
        /// If it is down, it will notify you by email
        /// or by posting a notice on screen.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void checkWebSiteButton_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"https://http://zmaj1.com/");
            request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
            request.Method = "HEAD";
            try
            {
                WebResponse response = request.GetResponse();
                if(response.Headers.Count != 0)
                {
                    MessageBox.Show("Page active");
                }else
                {
                    MessageBox.Show("Page not active");
                }
                
                // do something with response.Headers to find out information about the request
            }
            catch (WebException wex)
            {
                MessageBox.Show("Page not active");
                //set flag if there was a timeout or some other issues
            }
        }
    }
}
