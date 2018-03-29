using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Randevu.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        
        [Required]
        [Display(Name = "TC")]
        public string Tc { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifresi")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifreyi Onaylayın")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
    }
}
