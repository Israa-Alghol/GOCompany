using GOCompanies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOCompanies.ViewModels
{
    public class CompanyViewModel
    {
        //public Company _company { get; set; }
        public int Company { get; set; }
        //public string nameCompany { get; set; }
        //public int driverId { get; set; }
        [Required(ErrorMessage = "Please Select")]
        public List<Company> Companies { get; set; }
        //public Driver _driver { get; set; }
        public int driverId { get; set; }
        [Required(ErrorMessage = "Please Select Driver's Name")]
        public string nameDriver { get; set; }
        //public List<Driver> Drivers { get; set; }
        //public Vehicle _vehicle { get; set; }
        public int Vehicle { get; set; }
        public string nameVehicle { get; set; }
        [Required(ErrorMessage ="Please Select")]
        public List<Vehicle> Vehicles { get; set; }
        public SelectList CompanyList { get; set; }
    }
}
