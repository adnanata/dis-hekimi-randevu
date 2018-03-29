using System.ComponentModel.DataAnnotations;

namespace Randevu.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

        public string PhoneRelative { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}