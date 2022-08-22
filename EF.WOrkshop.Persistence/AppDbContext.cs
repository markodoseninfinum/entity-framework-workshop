using EF.Workshop.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.WOrkshop.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelPetEntity(modelBuilder);
            ModelOwnerEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ModelPetEntity(ModelBuilder modelBuilder)
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
        }

        private void ModelOwnerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .Property(p => p.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Owner>()
                .OwnsOne(p => p.Address,
                config =>
                {
                    config.Property(p => p.Street).HasMaxLength(50);
                    config.Property(p => p.City).HasMaxLength(50);
                });
        }
    }
}
