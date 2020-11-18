﻿// <auto-generated />
using System;
using LibraryApp_WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryApp_WebAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20201118111449_fixFields")]
    partial class fixFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LibraryApp_WebAPI.Models.Author", b =>
                {
                    b.Property<long>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryApp_WebAPI.Models.Book", b =>
                {
                    b.Property<long>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryApp_WebAPI.Models.BookAuthor", b =>
                {
                    b.Property<long>("BA_AuthorId")
                        .HasColumnType("bigint");

                    b.Property<long>("BA_BookId")
                        .HasColumnType("bigint");

                    b.HasKey("BA_AuthorId", "BA_BookId");

                    b.HasIndex("BA_BookId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("LibraryApp_WebAPI.Models.LibraryBook", b =>
                {
                    b.Property<long>("InventoryNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("CurrentlyLoaned")
                        .HasColumnType("bit");

                    b.Property<long>("LB_BookId")
                        .HasColumnType("bigint");

                    b.HasKey("InventoryNumber");

                    b.HasIndex("LB_BookId");

                    b.ToTable("LibraryBook");
                });

            modelBuilder.Entity("LibraryApp_WebAPI.Models.LoanBook", b =>
                {
                    b.Property<int>("LB_MemberId")
                        .HasColumnType("int");

                    b.Property<long>("LB_InventoryNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LB_MemberId", "LB_InventoryNumber");

                    b.HasIndex("LB_InventoryNumber");

                    b.ToTable("LoanBook");
                });

            modelBuilder.Entity("LibraryApp_WebAPI.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistratioNDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LibraryApp_WebAPI.Models.BookAuthor", b =>
                {
                    b.HasOne("LibraryApp_WebAPI.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("BA_AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp_WebAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BA_BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryApp_WebAPI.Models.LibraryBook", b =>
                {
                    b.HasOne("LibraryApp_WebAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("LB_BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryApp_WebAPI.Models.LoanBook", b =>
                {
                    b.HasOne("LibraryApp_WebAPI.Models.LibraryBook", "LibraryBook")
                        .WithMany()
                        .HasForeignKey("LB_InventoryNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp_WebAPI.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("LB_MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LibraryBook");

                    b.Navigation("Member");
                });
#pragma warning restore 612, 618
        }
    }
}
