using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Regex_Query_Tool
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Regex Query Tool -
        /// A tool that allows the user to enter 
        /// a text string and then in a separate 
        /// control enter a regex pattern. 
        /// It will run the regular expression against the 
        /// source text and return any matches or flag errors 
        /// in the regular expression.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void checkRegexButton_Click(object sender, EventArgs e)
        {
            bool match = Regex.IsMatch(stringToCheckTextBox.Text, regExToCheckTextBox.Text);
            try
            {
                if (match && (stringToCheckTextBox.Text != String.Empty) && (regExToCheckTextBox.Text != String.Empty))
                {
                    resultTextBox.Text = "Checks out!";
                    resultTextBox.BackColor = Color.Green;
                    resultTextBox.ForeColor = Color.White;
                }
                else
                {
                    resultTextBox.Text = "Doesn't check out!";
                    resultTextBox.BackColor = Color.Red;
                    resultTextBox.ForeColor = Color.White;
                }

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            
        }
    }
}
