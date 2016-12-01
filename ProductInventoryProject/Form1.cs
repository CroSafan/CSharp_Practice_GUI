using ProductInventoryProject.Classes;
using System;
using System.Windows.Forms;

namespace ProductInventoryProject
{
    public partial class Form1 : Form
    {
        private static Inventory inv = new Inventory();
        public static int idCount = 1;
        public Form1()
        {
            InitializeComponent();
        }



        private void addToInventoryBtn_Click(object sender, EventArgs e)
        {
            try
            {

                Product product = new Product();
                product.ID = idCount;
                product.Name = nameTextBox.Text;
                product.Price = float.Parse(PriceTextbox.Text.Replace('.', ','));
                product.Quantity = int.Parse(quantityTextBox.Text);
                inv.AddItem(product);
                dataGridView1.Rows.Add(product.ID, product.Name, product.Price, product.Quantity);
                sumOfInventoryPriceing.Text = "Inventory value:" + inv.SumOfPrice().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            idCount++;
        }
    }
}