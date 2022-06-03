using System;

namespace _22222
{
    class ProductItem
    {
        public string Name;
        public string Category;
        public double Price;

        public ProductItem(string name, string category, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }
    }

    class Customer
    {
        public string Name;
        public int CustomerNumber;
        public ProductItem[] ShoppingBag;
        public int Count;


        public Customer(string name, int customerNum, int init)
        {
            Name = name;
            CustomerNumber = customerNum;
            Count = init;
        }

        public Customer()
        {
            Name = "No Name";
            // Count = init ;
            CustomerNumber = 0;
        }

        public Customer(string name, int customerNum, ProductItem[] shoppingBag)
        {
            Name = name;
            CustomerNumber = customerNum;
            ShoppingBag = shoppingBag;
            Count = ShoppingBag.Length != 0 ? ShoppingBag.Length : -1;
        }

        public static void AddToShoppingBag(ProductItem p1)
        {
            if (p1 != null && p1.Count > -1 && Count < ShoppingBag.Length)
               ShoppingBag[Count] = p1;
            Count++;
        }

        public static void AddToShoppingBag(string name, string category, double price)
        {
            ProductItem P = new ProductItem ( name, category,  price);
            if (Count > -1 && Count < ShoppingBag.Length)
                P.ShoppingBag[Count] = P;
            Count++;
        }

    }

    class Program
    {
        public static void Main()
        {
            var item = new ProductItem("Bread", "Bakery", 3.5);
            var customer = new Customer();
            customer = new Customer("Name", 223, 3);
            customer.AddToShoppingBag(item);
            customer.AddToShoppingBag("Apple", "Fruit", 0.25);
            ProductItem[] shoppingBag = ?;
            customer = new Customer("Name", 223, shoppingBag);
            customer.AddToShoppingBag("Banana", "Fruit", 0.22);
        }
    }
}
