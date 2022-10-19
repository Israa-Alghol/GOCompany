using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOCompanies.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
