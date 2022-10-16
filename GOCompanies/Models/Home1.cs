using System.ComponentModel.DataAnnotations;

namespace GOCompanies.Models
{
    public class Home1
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
