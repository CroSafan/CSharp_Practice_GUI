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
    /// Interaction logic for searchWindow.xaml
    /// </summary>
    public partial class searchWindow : Window
    {
        string findWord = "";
        public searchWindow()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            findWord = "";
            

        }

        private void findNextBtn_Click(object sender, RoutedEventArgs e)
        {
            findWord = findTextTxtBox.Text;
            this.DialogResult = false;
        }

        public String getFindWord()
        {
            return findWord;
        }
    }
}
