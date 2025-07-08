using Microsoft.EntityFrameworkCore;
using BailamMVC.Models;

namespace BailamMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
    }
}