using Bank_Account_Manager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Account_Manager
{

    public partial class Form1 : Form
    {

        private static BusinessAccount ba = new BusinessAccount();
        private static CheckingAccount ca = new CheckingAccount();
        private static SavingsAccount sa = new SavingsAccount();


        public Form1()
        {
            InitializeComponent();
        }

        private void accTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            CheckTypeAcc();
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            switch (accTypeComboBox.SelectedIndex)
            {
                case 0:
                    ba.Balance += int.Parse(textBox1.Text);
                    CheckTypeAcc();
                    break;
                case 1:
                    ca.Balance += int.Parse(textBox1.Text);
                    CheckTypeAcc();
                    break;
                case 2:
                    sa.Balance += int.Parse(textBox1.Text);
                    CheckTypeAcc();
                    break;

            }
        }
        private void CheckTypeAcc()
        {
            switch (accTypeComboBox.SelectedIndex)
            {
                case 0:
                    balanceLabel.Text = "Balance:" + ba.Balance;
                    break;
                case 1:
                    balanceLabel.Text = "Balance:" + ca.Balance;
                    break;
                case 2:
                    balanceLabel.Text = "Balance:" + sa.Balance;
                    break;

            }
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (accTypeComboBox.SelectedIndex)
                {
                    case 0:
                        ba.Balance -= int.Parse(textBox2.Text);
                        CheckTypeAcc();
                        break;
                    case 1:
                        ca.Balance -= int.Parse(textBox2.Text);
                        CheckTypeAcc();
                        break;
                    case 2:
                        sa.Balance -= int.Parse(textBox2.Text);
                        CheckTypeAcc();
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
