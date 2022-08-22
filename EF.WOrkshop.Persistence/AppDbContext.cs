using EF.Workshop.Persistence.DataSeed;
using EF.Workshop.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.WOrkshop.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PetMedicine> PetMedicines { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelPetEntity(modelBuilder);
            ModelOwnerEntity(modelBuilder);
            ModelMedicine(modelBuilder);
            ModelPetMedicine(modelBuilder);

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

            modelBuilder.Entity<Pet>()
                .HasQueryFilter(p => p.IsFriendly == false);

            modelBuilder.Entity<Dog>()
                .ToTable("Dog");

            modelBuilder.Entity<Dog>()
                .HasData(MockData.GetDog());

            modelBuilder.Entity<Cat>()
                .ToTable("Cat");

            modelBuilder.Entity<Cat>()
                .HasData(MockData.GetCat());
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
                })
                .HasData(MockData.GetOwner());
        }

        private void ModelMedicine(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>()
                .Property(p => p.Name)
                .HasMaxLength(150);

            modelBuilder.Entity<Medicine>()
                .HasData(MockData.GetMedicine());
        }

        private void ModelPetMedicine(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetMedicine>()
                .HasKey(p => new { p.MedicineId, p.PetId });

            modelBuilder.Entity<PetMedicine>()
                .HasOne(p => p.Pet)
                .WithMany()
                .HasForeignKey(p => p.PetId);

            modelBuilder.Entity<PetMedicine>()
                .HasOne(p => p.Medicine)
                .WithMany()
                .HasForeignKey(p => p.MedicineId);

            modelBuilder.Entity<PetMedicine>()
                .ToTable("MedicinePet");

            modelBuilder.Entity<PetMedicine>()
                .HasData(MockData.GetPetMedicine());
        }
    }
}
