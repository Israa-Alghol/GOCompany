using GOCompanies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GOCompanies.Repositories
{
    public class DriverDbRepository : ICRepo<Driver>
    {
        CDBContext dbContext;
        public DriverDbRepository(CDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
    
        public void Add(Driver entity)
        {
            dbContext.Drivers.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var driver = GetById(id);
            dbContext.Drivers.Remove(driver);
            dbContext.SaveChanges();
        }

        public IList<Driver> GetAll()
        {
            return dbContext.Drivers.Include(a => a.Company).Include(v => v.Vehicle).ToList();

        }

        public Driver GetById(int id)
        {
            var driver = dbContext.Drivers.Include(a => a.Company).Include(v => v.Vehicle).FirstOrDefault(c => c.Id == id);
     
            return driver;
        }

        public IList<Driver> List(Func<Driver, bool> filter)
        {
            return dbContext.Drivers.Include(a => a.Company).Include(a => a.Vehicle).Where(filter).ToList();
        }
        public IList<Driver> List2(Func<Vehicle, bool> filter)
        {
            return dbContext.Drivers.ToList();
        }
        public IList<Driver> List3(Func<Home1, bool> filter)
        {
            return dbContext.Drivers.ToList();
        }
        public IList<Driver> List4(Func<Company, bool> filter)
        {
            return dbContext.Drivers.ToList();
        }
        public void Update(Driver newdriver)
        {
            dbContext.Update(newdriver);
            dbContext.SaveChanges();
        }
    }
}
