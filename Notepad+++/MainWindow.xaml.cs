using Microsoft.Win32;
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
            wordsCount.Content = "Number of words:" + Regex.Matches(inputText, @"[A-Za-z0-9]+").Count.ToString();
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
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.C))
            {
                mainTextBox.Copy();
            }
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.V))
            {
                mainTextBox.Paste();
            }
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.X))
            {
                mainTextBox.Cut();
            }
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.A))
            {
                mainTextBox.SelectAll();
            }
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.Z))
            {
                mainTextBox.Undo();
            }
        }

        private void findItem_Click(object sender, RoutedEventArgs e)
        {
            searchWindow sw = new searchWindow();
            sw.ShowDialog();

            TextRange text = new TextRange(mainTextBox.Document.ContentStart, mainTextBox.Document.ContentEnd);
            TextPointer current = text.Start.GetInsertionPosition(LogicalDirection.Forward);
            while (current != null)
            {
                string textInRun = current.GetTextInRun(LogicalDirection.Forward);
                if (!string.IsNullOrWhiteSpace(textInRun))
                {
                    int index = textInRun.IndexOf(sw.getFindWord());
                    if (index != -1)
                    {
                        TextPointer selectionStart = current.GetPositionAtOffset(index, LogicalDirection.Forward);
                        TextPointer selectionEnd = selectionStart.GetPositionAtOffset(sw.getFindWord().Length, LogicalDirection.Forward);
                        TextRange selection = new TextRange(selectionStart, selectionEnd);

                        mainTextBox.Selection.Select(selection.Start, selection.End);
                        mainTextBox.Focus();
                    }
                }
                current = current.GetNextContextPosition(LogicalDirection.Forward);
            }
        }

        private void replace_Click(object sender, RoutedEventArgs e)
        {
            FindAndReplace far = new FindAndReplace();
            far.ShowDialog();

            TextRange text = new TextRange(mainTextBox.Document.ContentStart, mainTextBox.Document.ContentEnd);
            TextPointer current = text.Start.GetInsertionPosition(LogicalDirection.Forward);

            if ((far.getReplaceString() == String.Empty) && (far.getFindString() == String.Empty))
            {
                MessageBox.Show("Enter a find and replace word");
            }
            else
            {
                while (current != null)
                {
                    string textInRun = current.GetTextInRun(LogicalDirection.Forward);
                    if (!string.IsNullOrWhiteSpace(textInRun))
                    {
                        int index = textInRun.IndexOf(far.getFindString());
                        if (index != -1)
                        {
                            TextPointer selectionStart = current.GetPositionAtOffset(index, LogicalDirection.Forward);
                            TextPointer selectionEnd = selectionStart.GetPositionAtOffset(far.getFindString().Length, LogicalDirection.Forward);
                            TextRange selection = new TextRange(selectionStart, selectionEnd);

                            selection.Text = far.getReplaceString();

                            mainTextBox.Selection.Select(selection.Start, selection.End);
                            mainTextBox.Focus();
                        }
                    }
                    current = current.GetNextContextPosition(LogicalDirection.Forward);
                }
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
    }
}