using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        //Bu projeyi başlatınca bellekte bir ürün listesi oluşması için constructor metot tanımlıyoruz.
        //Verileri bir veritabanından (sql,oracle,mongob) gelmiş gibi simüle ediyoruz.
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        //Arayüzden bir tane product nesnesi gönderdiğinde mecburen onun newleyeceksin. Onun referans numarası listedeki productlarlarla eşleşmediği için bulamıyor. Listed 5 tane ürünün referans numarası ramde heap bölümünde farklı referans numarasıyla tutuluyor. Referans tipler referans numarası üzerinden gider. Bilgilerin aynı olması (id,vs) önemli değil. Silme ve güncelleme işlemi için Referans numarasını bulmamız gerekiyor.

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query (Dile Gömülü Sorgulama)
            //Lambda =>
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            //SingleOrDefault : Tek bir eleman bulmaya yarar. Ürünleri tek tek dolaşır. (Yukarıdaki foreach döngüsünün yaptığı işlemi           
            //SingleOrDefault yapar.) (Parantez içindeki ifade ise if bloğunda yaptığımız işlemi yapar.) En son dönen değeri productToDelete değerine eşitler. Remove metodu ile ise ürünü siliyoruz. SingleOrDefault metodunu id bazlı yapılarda kullanılır. Çünkü sorgu sonucunda iki değer gelirse hata verir. Daha güvenli oluyor.
            //p : listeyi dolaşırken her bir elemana verdiği takma isim.

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //Normalde select ifadesi yazmam gerekiyor. Where koşulu içindeki şarta uyan bütün elemanları yeni bir liste haline getirip onu döndürür.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürün idsini(ürünü) bul demek. Ki biz onu güncelleyebilelim.
            //ProductToUpdate artık benim listedeki elemanımın (ürünüm). (Referans adresini tutuyor) Yani listediki ürünüm.

            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
