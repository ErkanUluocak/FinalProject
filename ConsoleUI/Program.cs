using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Burada hangi veri yöntemi ile çalıştığını söylememiz gerekiyor. Constructor metot ile bunu veriyoruz.

            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName); 
                //Console.WriteLine($"{product.ProductId} {product.ProductName} {product.CategoryId} {product.UnitPrice} {product.UnitsInStock}");
            }
        }
    }
}