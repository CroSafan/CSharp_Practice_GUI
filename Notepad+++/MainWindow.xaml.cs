using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace Notepad___
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SaveFileDialog sfd = new SaveFileDialog();
        public static OpenFileDialog ofd = new OpenFileDialog();

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
            ofd.DefaultExt = ".txt";
            ofd.Filter = "txt files (*.txt)|*.txt";
            var result = ofd.ShowDialog();
            if (result == true)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    mainTextBox.Document.Blocks.Clear();
                    while (sr.EndOfStream ==false)
                    {
                        mainTextBox.Document.Blocks.Add(new Paragraph(new Run(sr.ReadLine())));
                    }
                }
            }
           
            
        }

        //save File
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            sfd.DefaultExt = ".txt";
            sfd.Filter = "txt files (*.txt)|*.txt";
            var result = sfd.ShowDialog();
            if (result == true)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    string textRange = new TextRange(mainTextBox.Document.ContentStart, mainTextBox.Document.ContentEnd).Text;
                    sw.WriteLine(textRange);
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