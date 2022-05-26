using Microsoft.EntityFrameworkCore;
using WebAPI2._0.Model;

namespace WebAPI2._0.DatabaseContext
{
    public class KinderGartenContext : DbContext
    {
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = exam.db");
        }
    }
}