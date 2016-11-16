using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RSS_reader_MEV
{
    public partial class Form1 : Form
    {
        public List<string> opisi = new List<string>();
        public List<string> linkovi = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load("https://www.mev.hr/index.php/category/racunarstvo-rss/racunarstvo/feed/");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");           

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {                
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";
                titlesComboBox.Items.Add(title);

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";
                linkovi.Add(link);
               
                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";
                opisi.Add(description);              
            }
        }

        private void titlesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            descriptionTextBox.Text = opisi[titlesComboBox.SelectedIndex];
            linkLabel.Text = linkovi[titlesComboBox.SelectedIndex];
            
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel.Text);
        }
    }
}
