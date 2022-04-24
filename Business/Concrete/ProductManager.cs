using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        //ProductManager new lendiğinde constructor diyor ki bana bir tane IProductDal ver demek. İstersem EntityFramework istersem  ınmemory ya da başka bir şey verebilirim.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş kodları yapılır.
            //Bir iş sınıfı başka bir sınıfları new lemez.
            //Yetkisi var mı gibi bir iş kontrolu olabilir. Eğer geçerse listele.

            return _productDal.GetAll();
        }
    }
}
