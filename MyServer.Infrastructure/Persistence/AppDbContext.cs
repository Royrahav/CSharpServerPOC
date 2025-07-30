using Microsoft.EntityFrameworkCore;
using MyServer.Domain.Entities;

namespace MyServer.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> Todos { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Identifier> Identifiers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Map to specific table name if it differs
            modelBuilder.Entity<TodoItem>().ToTable("...");
        }
    }
}
