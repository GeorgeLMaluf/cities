﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.Persistence.Contexts;

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200810205852_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("api.Domain.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("character varying(80)")
                        .HasMaxLength(80);

                    b.Property<int>("Ibge")
                        .HasColumnType("integer");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("character varying(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("character varying(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("Ibge")
                        .IsUnique();

                    b.HasIndex("Uf", "Cidade")
                        .IsUnique();

                    b.ToTable("cities");
                });
#pragma warning restore 612, 618
        }
    }
}
