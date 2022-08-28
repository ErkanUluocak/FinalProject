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
            //ProductTest();
            CategoryTest();


        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //Burada hangi veri yöntemi ile çalıştığını söylememiz gerekiyor. Constructor metot ile bunu veriyoruz.

            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " - " + product.CategoryName);

                    //Console.WriteLine($"{product.ProductId} {product.ProductName} {product.CategoryId} {product.UnitPrice} {product.UnitsInStock}");
                }
                Console.WriteLine(result.Message); 

            }
            else
            {
                Console.WriteLine(result.Message);
            }


            //foreach (var product in productManager.GetByUnitPrice(40, 100))
            //{
            //    Console.WriteLine(product.ProductName + " - " + product.UnitPrice);
            //    //Console.WriteLine($"{product.ProductId} {product.ProductName} {product.CategoryId} {product.UnitPrice} {product.UnitsInStock}");
            //}
        }
    }
}