﻿// <auto-generated />
using System;
using LibraryApp_WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryApp_WebAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LibraryApp_Common.Models.Author", b =>
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

            modelBuilder.Entity("LibraryApp_Common.Models.Book", b =>
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

            modelBuilder.Entity("LibraryApp_Common.Models.BookAuthor", b =>
                {
                    b.Property<long>("BA_AuthorId")
                        .HasColumnType("bigint");

                    b.Property<long>("BA_BookId")
                        .HasColumnType("bigint");

                    b.HasKey("BA_AuthorId", "BA_BookId");

                    b.HasIndex("BA_BookId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("LibraryApp_Common.Models.LibraryBook", b =>
                {
                    b.Property<string>("InventoryNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("CurrentlyLoaned")
                        .HasColumnType("bit");

                    b.Property<long>("LB_BookId")
                        .HasColumnType("bigint");

                    b.HasKey("InventoryNumber");

                    b.HasIndex("LB_BookId");

                    b.ToTable("LibraryBook");
                });

            modelBuilder.Entity("LibraryApp_Common.Models.LoanBook", b =>
                {
                    b.Property<long>("LB_MemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("LB_InventoryNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LB_MemberId", "LB_InventoryNumber");

                    b.HasIndex("LB_InventoryNumber");

                    b.ToTable("LoanBook");
                });

            modelBuilder.Entity("LibraryApp_Common.Models.Member", b =>
                {
                    b.Property<long>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

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

            modelBuilder.Entity("LibraryApp_Common.Models.BookAuthor", b =>
                {
                    b.HasOne("LibraryApp_Common.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("BA_AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp_Common.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BA_BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryApp_Common.Models.LibraryBook", b =>
                {
                    b.HasOne("LibraryApp_Common.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("LB_BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryApp_Common.Models.LoanBook", b =>
                {
                    b.HasOne("LibraryApp_Common.Models.LibraryBook", "LibraryBook")
                        .WithMany()
                        .HasForeignKey("LB_InventoryNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp_Common.Models.Member", "Member")
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
