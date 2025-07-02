using System.ComponentModel.DataAnnotations;

namespace BailamMVC.Models;

public class Employee : Person
{
    public string? EmployeeId { get; set; }
    public int Age { get; set; }
}