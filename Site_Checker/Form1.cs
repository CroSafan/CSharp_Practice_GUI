using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
