using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleApp.CSharp6
{
    public class CollectionInitializers
    {
        public static void Example1()
        {
            var products = new Products
            {
                new Product{ Name = "Samsung Galaxy S8+", Price = 800 },
                new Product{ Name = "Samsung Galaxy S9", Price = 1000 },
            };

            foreach (Product product in products)
                WriteLine($"Name = {product.Name}, Price = {product.Price}");
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Products : IEnumerable<Product>
    {
        private List<Product> _items = new List<Product>();

        public void AddProduct(string name, decimal price)
        {
            _items.Add(new Product { Name = name, Price = price });
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator<Product> IEnumerable<Product>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }

    public static class ProductsExtensions
    {
        public static void Add(this Products products, Product product)
        {
            products.AddProduct(product.Name, product.Price);
            WriteLine("ProductsExtensions.AddProduct()");
        }
    }
}
