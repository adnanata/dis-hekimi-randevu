using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Randevu.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime StartOfWork { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}