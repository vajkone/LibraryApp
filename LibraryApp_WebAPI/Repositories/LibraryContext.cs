using LibraryApp_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Repositories
{
    public class LibraryContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<LibraryBook> LibraryBook { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<LoanBook> LoanBook { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanBook>()
                .HasKey(o => new { o.LB_MemberId, o.LB_InventoryNumber });

            modelBuilder.Entity<BookAuthor>()
                .HasKey(o => new { o.BA_AuthorId, o.BA_BookId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Database=LibraryDb;Integrated Security=True;");
        }
    }
}
