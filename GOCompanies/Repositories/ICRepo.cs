using GOCompanies.Models;
using System;
using System.Collections.Generic;

namespace GOCompanies.Repositories
{
    public interface ICRepo<TEntity>
    {
        IList<TEntity> GetAll();
        IList<TEntity> List(Func<Driver, bool> filter);
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
    
    }
}
