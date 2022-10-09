using System.Collections.Generic;

namespace GOCompanies.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
