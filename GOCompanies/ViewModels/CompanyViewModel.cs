using GOCompanies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOCompanies.ViewModels
{
    public class CompanyViewModel
    {
        public Company _company { get; set; }
        //public int driverId { get; set; }
        public List<Company> Companies { get; set; }
        public Driver _driver { get; set; }
        public List<Driver> Drivers { get; set; }
        public Vehicle _vehicle { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public SelectList CompanyList { get; set; }
    }
}
