using System.ComponentModel.DataAnnotations;

namespace Randevu.Models.EmployeeViewModels
{
    public class EmployeeRegisterModel
    {
         
        [Required]
        [Display(Name = "Adı")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }

    }
}