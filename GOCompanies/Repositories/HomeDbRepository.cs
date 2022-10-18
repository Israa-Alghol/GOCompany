using GOCompanies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GOCompanies.Repositories
{
    public class HomeDbRepository : ICRepo<Home>
    {
        CDBContext dbContext;
        public HomeDbRepository(CDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Home entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Home> GetAll()
        {
            return dbContext.Home.Include(a => a.Company).ToList();
        }

        public Home GetById(int id)
        {
            var home = dbContext.Home.Include(a => a.Company).FirstOrDefault(c => c.Id == id);

            return home;
        }

        public IList<Home> List(Func<Driver, bool> filter)
        {
            return dbContext.Home.ToList();
        }
        public IList<Home> List2(Func<Vehicle, bool> filter)
        {
            return dbContext.Home.ToList();
        }
        //public IList<Home> List3(Func<Home, bool> filter)
        //{
        //    return dbContext.Home.Include(a => a.Company).Where(filter).ToList();
        //}
        public IList<Home> List4(Func<Company, bool> filter)
        {
            return dbContext.Home.ToList();
        }
        public void Update(Home home)
        {
            throw new NotImplementedException();
        }
    }
}
