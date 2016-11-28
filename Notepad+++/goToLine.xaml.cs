using System;
using System.Windows;

namespace Notepad___
{
    /// <summary>
    /// Interaction logic for goToLine.xaml
    /// </summary>
    public partial class goToLine : Window
    {
        private int gotoLine;

        public goToLine()
        {
            InitializeComponent();
        }

        private void gotoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gotoLine = Convert.ToInt32(gotoLineTextBox.Text);
                gotoButton.IsCancel = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int gotoLineNumber()
        {
            return gotoLine;
        }
    }
}