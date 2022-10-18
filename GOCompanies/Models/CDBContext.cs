using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GOCompanies.Models
{
    public class CDBContext : IdentityDbContext
    {
        public virtual DbSet<Userdetails> Userdetails { get; set; }
        public CDBContext(DbContextOptions<CDBContext> options):base(options)
        {

        }
        public DbSet<Home> Home { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
