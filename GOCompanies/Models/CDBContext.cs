using Microsoft.EntityFrameworkCore;

namespace GOCompanies.Models
{
    public class CDBContext : DbContext
    {
        public CDBContext(DbContextOptions<CDBContext> options):base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }

    }
}
