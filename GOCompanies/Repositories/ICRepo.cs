using GOCompanies.Models;
using System;
using System.Collections.Generic;

namespace GOCompanies.Repositories
{
    public interface ICRepo<TEntity>
    {
        IList<TEntity> GetAll();
        IList<TEntity> List(Func<Driver, bool> filter);
        IList<TEntity> List2(Func<Vehicle, bool> filter);
        //IList<TEntity> List3(Func<Home, bool> filter);
        IList<TEntity> List4(Func<Company, bool> filter);
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
    
    }
}
