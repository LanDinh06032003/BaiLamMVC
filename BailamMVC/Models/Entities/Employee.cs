using System.ComponentModel.DataAnnotations;

namespace BailamMVC.Models.Entities
{
    public class Employee
    {
        [Key]
        public required string EmployeeId { get; set; } = default!;
        [Required(ErrorMessage = "Full Name is required.")]
        public int Age { get; set; } = default!;
    }
}