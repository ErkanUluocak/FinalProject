using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Burada hangi veri yöntemi ile çalıştığını söylememiz gerekiyor. Constructor metot ile bunu veriyoruz.
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine($"{product.ProductId} {product.ProductName} {product.CategoryId} {product.UnitPrice} {product.UnitsInStock}");
            }

        }
    }
}
