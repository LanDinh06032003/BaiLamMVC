using Microsoft.EntityFrameworkCore;
using BailamMVC.Models.Entities;
using BailamMVC.Models.Entities.HeThongPhanPhoi;

namespace BailamMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = null!;
        public DbSet<DaiLy> DaiLy { get; set; } = null!;
        public DbSet<HeThongPhanPhoi> HeThongPhanPhoi { get; set; } = null!;
    }
}

