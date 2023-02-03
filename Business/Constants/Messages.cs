using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //public değişkenlerin ilk harfi büyük olur (pascall case)
    public static class Messages
    {
        public static string CategorYLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla ürün olabilir";
        public static string ProductNameAlreadyExits = "Bu isimde zaten başka bir ürün var";
    }
}
