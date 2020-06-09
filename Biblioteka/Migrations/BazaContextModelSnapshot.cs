﻿// <auto-generated />
using System;
using BibliotekaDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotekaDb.Migrations
{
    [DbContext(typeof(BazaContext))]
    partial class BazaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibliotekaDb.Entities.Historia", b =>
                {
                    b.Property<int>("HisoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("DataOd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Osoba")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PozycjaId")
                        .HasColumnType("int");

                    b.HasKey("HisoriaID");

                    b.HasIndex("PozycjaId");

                    b.ToTable("Historia");
                });

            modelBuilder.Entity("BibliotekaDb.Entities.Pozycja", b =>
                {
                    b.Property<int>("PozycjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rodzaj")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Rok")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("PozycjaId");

                    b.ToTable("Pozycje");
                });

            modelBuilder.Entity("BibliotekaDb.Entities.Rodzaj", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.ToTable("Rodzaje");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "Książka"
                        },
                        new
                        {
                            Id = 1,
                            Name = "DVD"
                        },
                        new
                        {
                            Id = 2,
                            Name = "CD"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vinyl"
                        });
                });

            modelBuilder.Entity("BibliotekaDb.Entities.Historia", b =>
                {
                    b.HasOne("BibliotekaDb.Entities.Pozycja", "Pozycja")
                        .WithMany()
                        .HasForeignKey("PozycjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
