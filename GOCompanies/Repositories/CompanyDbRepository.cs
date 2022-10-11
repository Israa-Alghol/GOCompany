using GOCompanies.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GOCompanies.Repositories
{
    public class CompanyDbRepository : ICRepo<Company>
    {
        CDBContext dbContext;
        public CompanyDbRepository(CDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Company entity)
        {
            dbContext.Companies.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var company = GetById(id);
            dbContext.Companies.Remove(company);
            dbContext.SaveChanges();
        }

        public IList<Company> GetAll()
        {
            return dbContext.Companies.ToList();
        }

        public Company GetById(int id)
        {
            var company = dbContext.Companies.SingleOrDefault(c => c.Id == id);
            return company;
        }

        public IList<Company> List(Func<Driver, bool> filter)
        {
            return dbContext.Companies.ToList();
        }
        public IList<Company> List2(Func<Vehicle, bool> filter)
        {
            return dbContext.Companies.ToList();
        }
        public void Update(Company newcompany)
        {
            dbContext.Update(newcompany);
            dbContext.SaveChanges();
        }
    }
}
