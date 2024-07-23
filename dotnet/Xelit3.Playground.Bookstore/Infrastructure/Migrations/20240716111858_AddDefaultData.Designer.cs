﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xelit3.Playground.Bookstore.Infrastructure;

#nullable disable

namespace Xelit3.Playground.Bookstore.Infrastructure.Migrations
{
    [DbContext(typeof(BookstoreDbContext))]
    [Migration("20240716111858_AddDefaultData")]
    partial class AddDefaultData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("BookLend", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LendsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BooksId", "LendsId");

                    b.HasIndex("LendsId");

                    b.ToTable("BookLend");
                });

            modelBuilder.Entity("BookPurchase", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PurchasesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BooksId", "PurchasesId");

                    b.HasIndex("PurchasesId");

                    b.ToTable("BookPurchase");
                });

            modelBuilder.Entity("Xelit3.Playground.Bookstore.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("YearPublished")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Xelit3.Playground.Bookstore.Domain.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Xelit3.Playground.Bookstore.Domain.Models.Lend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("Id");

                    b.ToTable("Lends");
                });

            modelBuilder.Entity("Xelit3.Playground.Bookstore.Domain.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModificationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("Id");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("BookLend", b =>
                {
                    b.HasOne("Xelit3.Playground.Bookstore.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Xelit3.Playground.Bookstore.Domain.Models.Lend", null)
                        .WithMany()
                        .HasForeignKey("LendsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookPurchase", b =>
                {
                    b.HasOne("Xelit3.Playground.Bookstore.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Xelit3.Playground.Bookstore.Domain.Models.Purchase", null)
                        .WithMany()
                        .HasForeignKey("PurchasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Xelit3.Playground.Bookstore.Domain.Models.Lend", b =>
                {
                    b.HasOne("Xelit3.Playground.Bookstore.Domain.Models.Client", "Client")
                        .WithMany("Lends")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Xelit3.Playground.Bookstore.Domain.Models.Purchase", b =>
                {
                    b.HasOne("Xelit3.Playground.Bookstore.Domain.Models.Client", "Client")
                        .WithMany("Purchases")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Xelit3.Playground.Bookstore.Domain.Models.Client", b =>
                {
                    b.Navigation("Lends");

                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
