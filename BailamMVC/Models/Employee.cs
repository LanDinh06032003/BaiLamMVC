using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BailamMVC.Models
{
    [Table("Employee")]
    public class Employee : Person
    {
        public int Age { get; set; }
    }
}

