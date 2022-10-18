using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOCompanies.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        //[StringLength(15, ErrorMessage = "Name length can't be more than 15.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
    }
}
