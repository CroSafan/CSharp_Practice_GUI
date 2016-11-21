using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad___
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static OpenFileDialog ofg = new OpenFileDialog();
       
           

        public MainWindow()
        {
            InitializeComponent();
        }
        //new File
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }
        //open File
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
        //save File
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ofg.DefaultExt = ".txt";
            var result=ofg.ShowDialog();
            if (result == true)
            {
                using(StreamWriter sr =new StreamWriter(ofg.FileName))
                {
                    TextRange textRange = new TextRange(mainTextBox.Document.ContentStart, mainTextBox.Document.ContentEnd);
                    sr.Write(textRange);

                }
            }
        }
        //exit Program
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
