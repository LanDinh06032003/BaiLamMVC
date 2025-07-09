using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BailamMVC.Models
{
    [Table("Persons")]

    public class Person
    {
        [Key]
        public string? PersonId { get; set; } = Guid.NewGuid().ToString();
        public string? FullName { get; set; }
        public string? AddRess { get; set; }
    }
}