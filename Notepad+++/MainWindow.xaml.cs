using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
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
            MessageBoxButton btn = MessageBoxButton.YesNo;
            MessageBoxResult dr = MessageBox.Show("Do yo want to save the file?", "Notepad+++", btn);
            if (dr == MessageBoxResult.Yes)
            {
                SafeFile();
            }
            mainTextBox.Document.Blocks.Clear();
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
                    while (sr.EndOfStream == false)
                    {
                        mainTextBox.Document.Blocks.Add(new Paragraph(new Run(sr.ReadLine())));
                    }
                }
            }
        }

        //save File
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SafeFile();
        }

        //exit Program
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void mainTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string inputText = new TextRange(mainTextBox.Document.ContentStart, mainTextBox.Document.ContentEnd).Text;
            wordsCount.Content = "Number of words:" + Regex.Matches(inputText, @"[A-Za-z0-9]+").Count.ToString();
        }

        public void SafeFile()
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
    }
}