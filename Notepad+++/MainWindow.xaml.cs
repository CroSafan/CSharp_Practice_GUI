﻿using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using WpfColorFontDialog;

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
            NewFile();
        }

        //open File
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFile();
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
            string lineCount = mainTextBox.Document.Blocks.Count.ToString();
            wordsCount.Content = "Number of words:" + Regex.Matches(inputText, @"[A-Za-z0-9]+").Count.ToString() + " Number of lines: " + lineCount;
            if (wordWrapMenuItem.IsChecked)
            {
                mainTextBox.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Visible;
                mainTextBox.Document.PageWidth = 1000;

            }
            else
            {
                mainTextBox.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Hidden;
                mainTextBox.Document.PageWidth = 600;
            }


        }

        private void Time_Date_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Document.Blocks.Add(new Paragraph(new Run(DateTime.Now.ToString())));
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

        public void NewFile()
        {
            MessageBoxButton btn = MessageBoxButton.YesNo;
            MessageBoxResult dr = MessageBox.Show("Do yo want to save the file?", "Notepad+++", btn);
            if (dr == MessageBoxResult.Yes)
            {
                SafeFile();
            }
            mainTextBox.Document.Blocks.Clear();
        }

        public void OpenFile()
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

        private void KeyCombinations(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //performing operations from keyboard shortcuts
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.S))
            {
                SafeFile();
            }
            // Ctrl + N
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.N))
            {
                NewFile();
            }
            // Ctrl + O
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.O))
            {
                OpenFile();
            }
            if ((Keyboard.Modifiers == ModifierKeys.Alt) && (e.Key == Key.F4))
            {
                Environment.Exit(0);
            }
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.F))
            {
                test.Command.Execute((string)"Find");
            }
        }



        private void font_Click(object sender, RoutedEventArgs e)
        {
            //https://github.com/sskodje/WpfColorFont
            bool previewFontInFontList = true;
            ColorFontDialog dialog = new ColorFontDialog(previewFontInFontList);
            dialog.Font = FontInfo.GetControlFont(mainTextBox);

            if (dialog.ShowDialog() == true)
            {
                FontInfo font = dialog.Font;
                if (font != null)
                {
                    FontInfo.ApplyFont(mainTextBox, font);
                }
            }
        }

        private void statusBar_Click(object sender, RoutedEventArgs e)
        {
            if (!statusBarMenuItem.IsChecked)
            {
                wordsCount.Visibility = Visibility.Hidden;
            }
            else wordsCount.Visibility = Visibility.Visible;
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a simple clone of notepad", "About", MessageBoxButton.OK);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            mainTextBox.Undo();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            mainTextBox.Cut();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            mainTextBox.Copy();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            mainTextBox.Paste();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            mainTextBox.Selection.Text = "";
        }

        private void gotoLine_Click(object sender, RoutedEventArgs e)
        {
            goToLine gotoLineDialog = new goToLine();
            gotoLineDialog.ShowDialog();

            int lineCounter = mainTextBox.Document.Blocks.Count;

            if (gotoLineDialog.gotoLineNumber() > lineCounter)
            {
                MessageBox.Show("The line number is beyond the total number of lines");
            }
            else
            {
                int counter = 1;
                //going through all the lines 
                foreach (Paragraph x in mainTextBox.Document.Blocks)
                {
                    if (gotoLineDialog.gotoLineNumber() == counter)
                    {
                        //position the caret in the beginning of the line selected
                        mainTextBox.Selection.Select(x.ElementStart, x.ElementStart);
                    }
                    counter++;
                }
            }
        }
    }
}