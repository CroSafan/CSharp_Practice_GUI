using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notepad___
{
    /// <summary>
    /// Interaction logic for FindAndReplace.xaml
    /// </summary>
    public partial class FindAndReplace : Window
    {
        public string findString = "";
        public string replaceString = "";


        public FindAndReplace()
        {
            InitializeComponent();
        }

        public String getFindString()
        {
            return findString;
        }
        public String getReplaceString()
        {
            return replaceString;
        }

        private void replaceBtn_Click(object sender, RoutedEventArgs e)
        {
            findString = textBox.Text;
            replaceString = textBox1.Text;

        }

        private void replaceAllBtn_Click(object sender, RoutedEventArgs e)
        {
            findString = textBox.Text;
            replaceString = textBox1.Text;
        }
    }
}
