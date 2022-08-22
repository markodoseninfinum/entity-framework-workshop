using EF.WOrkshop.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.WOrkshop.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .Property(p => p.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Pet>()
                .Property(p => p.BirthDate)
                .HasColumnType("date");

            modelBuilder.Entity<Pet>()
                .Property(p => p.Gender)
                .HasColumnType("smallint");

            modelBuilder.Entity<Pet>()
                .Property(p => p.IsFriendly)
                .HasDefaultValue(true);

            modelBuilder.Entity<Pet>()
                .HasIndex(p => p.Name);

            modelBuilder.Entity<Pet>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
