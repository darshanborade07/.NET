using Microsoft.EntityFrameworkCore;
using Student.Models.Entities;

namespace Student.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Student1> students { get; set; }
    }
}
