using GOCompanies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GOCompanies.Repositories
{
    public class HomeDbRepository : ICRepo<Home1>
    {
        CDBContext dbContext;
        public HomeDbRepository(CDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Home1 entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Home1> GetAll()
        {
            return dbContext.Home.Include(a => a.Company).ToList();
        }

        public Home1 GetById(int id)
        {
            var home = dbContext.Home.Include(a => a.Company).FirstOrDefault(c => c.Id == id);

            return home;
        }

        public IList<Home1> List(Func<Driver, bool> filter)
        {
            return dbContext.Home.ToList();
        }
        public IList<Home1> List2(Func<Vehicle, bool> filter)
        {
            return dbContext.Home.ToList();
        }
        public IList<Home1> List3(Func<Home1, bool> filter)
        {
            return dbContext.Home.Include(a => a.Company).Where(filter).ToList();
        }
        public IList<Home1> List4(Func<Company, bool> filter)
        {
            return dbContext.Home.ToList();
        }
        public void Update(Home1 home)
        {
            throw new NotImplementedException();
        }
    }
}
