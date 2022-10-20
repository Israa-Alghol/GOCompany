using GOCompanies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOCompanies.ViewModels
{
    public class VehicleViewModel
    {
        public int Company { get; set; }
        
        public List<Company> Companies { get; set; }
        public int Vehicle { get; set; }
        [Required(ErrorMessage = "Please Select Vehicle Name")]
        public string nameVehicle { get; set; }
        public SelectList CompanyList { get; set; }
    }
}
