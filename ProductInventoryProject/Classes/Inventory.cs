using System.Collections.Generic;

namespace ProductInventoryProject.Classes
{
    class Inventory
    {
        public List<Product> listOfProduct = new List<Product>();

        public void AddItem(Product p)
        {
            listOfProduct.Add(p);
        }

        public List<Product> ReturnInventory()
        {
            return listOfProduct;
        }

        public float SumOfPrice()
        {
            float sum = 0;
            foreach (Product x in listOfProduct)
            {
                sum += x.Price;
            }
            return sum;
        }


    }
}
