using System.ComponentModel.DataAnnotations;

namespace BailamMVC.Models;

public class Person
{
    public string? PersonId { get; set; }
    public string? FullName { get; set; }
    public string? AddRess { get; set; }
}