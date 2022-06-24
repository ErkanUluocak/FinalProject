using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic constraint : generic kısıt
    //class : Referans tip olduğunu anlamına geliyor. (class olabilir demek değil)
    //IEntity : IEntity olabilir veya IEntity implement eden bir nesne olabilir.
    //new : new'lenebilir olmalı. IEntity interface olduğu için new'lenemez. IEntity' nin yazılabilir olmasını engelliyor.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter); //Tek bir data getirmek için. Bir sistemde bir verinin detayına gitmek için kullanılır 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}