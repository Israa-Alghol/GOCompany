using System.ComponentModel.DataAnnotations;

namespace GOCompanies.Models
{
    public class Userdetails
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
