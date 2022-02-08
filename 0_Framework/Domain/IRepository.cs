using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public  interface IRepository<in TKey , T> where T :  class
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> Get();
        bool Exists(Expression<Func<T , bool>> exception);
        void SaveChanges();
    }
}
