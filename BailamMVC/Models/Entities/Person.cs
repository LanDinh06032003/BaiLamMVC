using System.ComponentModel.DataAnnotations;

namespace BailamMVC.Models.Entities
{
    public class Person
    {
        [Key]
        public string PersonId { get; set; } = default!;
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = default!;
        public string AddRess { get; set; } = default!;
        public string Height { get; set; } = default!;
    }
}