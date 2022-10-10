using GOCompanies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GOCompanies.Repositories
{
    public class VehicleDbRepository :ICRepo<Vehicle>
    {
        CDBContext dbContext;
        public VehicleDbRepository(CDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Add(Vehicle entity)
        {
            dbContext.Vehicles.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var vehicle = GetById(id);
            dbContext.Vehicles.Remove(vehicle);
            dbContext.SaveChanges();
        }

        public IList<Vehicle> GetAll()
        {
            return dbContext.Vehicles.ToList();
        }

        public Vehicle GetById(int id)
        {
            var vehicle = dbContext.Vehicles.SingleOrDefault(c => c.Id == id);
            return vehicle;
        }

        public IList<Vehicle> List(Func<Driver, bool> filter)
        {
            return dbContext.Vehicles.ToList();
        }

        public IList<Vehicle> List(Func<Vehicle, bool> filter)
        {
            return dbContext.Vehicles.Include(a => a.Company).Where(filter).ToList();
        }
        public void Update(Vehicle newvehicle)
        {
            dbContext.Update(newvehicle);
            dbContext.SaveChanges();
        }
    }
}
