﻿// <auto-generated />
using System;
using LicitacijaServis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LicitacijaServis.Migrations
{
    [DbContext(typeof(LicitacijaContext))]
    [Migration("20230216162550_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LicitacijaServis.Entities.Licitacija", b =>
                {
                    b.Property<Guid>("LicitacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Broj")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<int>("KorakCene")
                        .HasColumnType("int");

                    b.Property<string>("ListaDokumentacijeFizickaLica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListaDokumentacijePravnaLica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ogranicenje")
                        .HasColumnType("int");

                    b.Property<DateTime>("Rok")
                        .HasColumnType("datetime2");

                    b.HasKey("LicitacijaId");

                    b.ToTable("Licitacijas");

                    b.HasData(
                        new
                        {
                            LicitacijaId = new Guid("fead4cee-fa4c-4b6a-8b27-83b70aa43698"),
                            Broj = 1,
                            Datum = new DateTime(2022, 10, 25, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Godina = 2022,
                            KorakCene = 10000,
                            ListaDokumentacijeFizickaLica = "Dokument F1",
                            ListaDokumentacijePravnaLica = "Dokument P1",
                            Ogranicenje = 1000000,
                            Rok = new DateTime(2022, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            LicitacijaId = new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb"),
                            Broj = 2,
                            Datum = new DateTime(2022, 10, 11, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Godina = 2022,
                            KorakCene = 10000,
                            ListaDokumentacijeFizickaLica = "Dokument F2",
                            ListaDokumentacijePravnaLica = "Dokument P2",
                            Ogranicenje = 1000000,
                            Rok = new DateTime(2022, 8, 15, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LicitacijaServis.Entities.LicitacijaJavnoNadmetanje", b =>
                {
                    b.Property<Guid>("LicitacijaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JavnoNadmetanjeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LicitacijaId", "JavnoNadmetanjeId");

                    b.ToTable("LicitacijaJavnoNadmetanjes");

                    b.HasData(
                        new
                        {
                            LicitacijaId = new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb"),
                            JavnoNadmetanjeId = new Guid("e128d9ea-25d6-47b7-8d94-4b73c6cb536c")
                        },
                        new
                        {
                            LicitacijaId = new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb"),
                            JavnoNadmetanjeId = new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448")
                        });
                });

            modelBuilder.Entity("LicitacijaServis.Entities.LicitacijaJavnoNadmetanje", b =>
                {
                    b.HasOne("LicitacijaServis.Entities.Licitacija", "Licitacija")
                        .WithMany()
                        .HasForeignKey("LicitacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Licitacija");
                });
#pragma warning restore 612, 618
        }
    }
}
