﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xelit3.Benchmarks;

#nullable disable

namespace Xelit3.Benchmarks.Migrations
{
    [DbContext(typeof(EFTestDataContext))]
    [Migration("20230131135407_TestModel_Int_Migration")]
    partial class TestModelIntMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Xelit3.Tests.Model.Address<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Line")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PersonId");

                    b.ToTable("Addresses_Guid", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Address<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CityId1")
                        .HasColumnType("int");

                    b.Property<string>("Line")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PersonId1")
                        .HasColumnType("int");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId1");

                    b.HasIndex("PersonId1");

                    b.ToTable("Addresses_int", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.City<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities_Guid", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.City<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountryId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId1");

                    b.ToTable("Cities_int", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Country<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries_Guid", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Country<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries_int", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Person<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OriginId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OriginId");

                    b.ToTable("Persons_Guid", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Person<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OriginId");

                    b.ToTable("Persons_int", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Post<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Posts_Guid", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Post<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Posts_int", (string)null);
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Address<System.Guid>", b =>
                {
                    b.HasOne("Xelit3.Tests.Model.City<System.Guid>", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Xelit3.Tests.Model.Person<System.Guid>", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Address<int>", b =>
                {
                    b.HasOne("Xelit3.Tests.Model.City<int>", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId1")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Xelit3.Tests.Model.Person<int>", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId1")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.City<System.Guid>", b =>
                {
                    b.HasOne("Xelit3.Tests.Model.Country<System.Guid>", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.City<int>", b =>
                {
                    b.HasOne("Xelit3.Tests.Model.Country<int>", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId1")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Person<System.Guid>", b =>
                {
                    b.HasOne("Xelit3.Tests.Model.Country<System.Guid>", "Origin")
                        .WithMany("Citizens")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Person<int>", b =>
                {
                    b.HasOne("Xelit3.Tests.Model.Country<int>", "Origin")
                        .WithMany("Citizens")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Post<System.Guid>", b =>
                {
                    b.HasOne("Xelit3.Tests.Model.Person<System.Guid>", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Post<int>", b =>
                {
                    b.HasOne("Xelit3.Tests.Model.Person<int>", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.City<System.Guid>", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.City<int>", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Country<System.Guid>", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Citizens");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Country<int>", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Citizens");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Person<System.Guid>", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Xelit3.Tests.Model.Person<int>", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
