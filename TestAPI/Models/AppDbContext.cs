using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customers> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
