using Microsoft.EntityFrameworkCore;
using MyServer.Domain.Entities;

namespace MyServer.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> Todos { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientIdentifier> PatientIdentifier { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureKeylessEntities(modelBuilder);
            ConfigurePatientEntities(modelBuilder);
            ConfigureIndexes(modelBuilder);
        }

        private static void ConfigureKeylessEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasNoKey();
            modelBuilder.Entity<Country>().HasNoKey();
            modelBuilder.Entity<DefaultIdType>().HasNoKey();
            modelBuilder.Entity<State>().HasNoKey();
            modelBuilder.Entity<Identifier>().HasNoKey();
        }

        private static void ConfigurePatientEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("i");
            modelBuilder.Entity<PatientIdentifier>().ToTable("ii");

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.IiRecords)
                .WithOne(i => i.Patient)
                .HasForeignKey(i => i.Iicode)
                .HasPrincipalKey(p => p.Code);

            modelBuilder.Entity<PatientIdentifier>()
                .HasOne(ii => ii.Patient)
                .WithMany(p => p.IiRecords)
                .HasForeignKey(ii => ii.Iicode);
        }

        private static void ConfigureIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientIdentifier>()
    .HasIndex(pi => pi.Iipid)
    .HasDatabaseName("IX_PatientIdentifier_Iipid");
        }
    }
}
