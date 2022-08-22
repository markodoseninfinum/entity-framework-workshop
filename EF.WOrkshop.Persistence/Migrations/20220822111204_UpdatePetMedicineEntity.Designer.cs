﻿// <auto-generated />
using System;
using EF.WOrkshop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EF.Workshop.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220822111204_UpdatePetMedicineEntity")]
    partial class UpdatePetMedicineEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EF.Workshop.Persistence.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("EF.Workshop.Persistence.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("EF.Workshop.Persistence.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<short>("Gender")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsFriendly")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("EF.Workshop.Persistence.Models.PetMedicine", b =>
                {
                    b.Property<int>("MedicineId")
                        .HasColumnType("integer");

                    b.Property<int>("PetId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("MedicineId1")
                        .HasColumnType("integer");

                    b.Property<int?>("PetId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MedicineId", "PetId");

                    b.HasIndex("MedicineId1");

                    b.HasIndex("PetId");

                    b.HasIndex("PetId1");

                    b.ToTable("MedicinePet", (string)null);
                });

            modelBuilder.Entity("EF.Workshop.Persistence.Models.Owner", b =>
                {
                    b.OwnsOne("EF.Workshop.Persistence.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OwnerId")
                                .HasColumnType("integer");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.HasKey("OwnerId");

                            b1.ToTable("Owners");

                            b1.WithOwner()
                                .HasForeignKey("OwnerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("EF.Workshop.Persistence.Models.Pet", b =>
                {
                    b.HasOne("EF.Workshop.Persistence.Models.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("EF.Workshop.Persistence.Models.PetMedicine", b =>
                {
                    b.HasOne("EF.Workshop.Persistence.Models.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF.Workshop.Persistence.Models.Medicine", null)
                        .WithMany("Pets")
                        .HasForeignKey("MedicineId1");

                    b.HasOne("EF.Workshop.Persistence.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF.Workshop.Persistence.Models.Pet", null)
                        .WithMany("Medicines")
                        .HasForeignKey("PetId1");

                    b.Navigation("Medicine");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("EF.Workshop.Persistence.Models.Medicine", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("EF.Workshop.Persistence.Models.Owner", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("EF.Workshop.Persistence.Models.Pet", b =>
                {
                    b.Navigation("Medicines");
                });
#pragma warning restore 612, 618
        }
    }
}