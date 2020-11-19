
using LibraryApp_Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Repositories
{
    public class BookRepository
    {
        public static IList<Book> GetBooks()
        {

            using var database = new LibraryContext();
            var books = database.Books.ToList();
            return books;


        }

        public static Book GetBook(long id)
        {

            using var database = new LibraryContext();
            var book = database.Books.Where(b => b.BookId == id).FirstOrDefault();
            return book;


        }

        public static void AddBook(Book book)
        {
            using var database = new LibraryContext();
            database.Books.Add(book);
            database.SaveChanges();

        }



        public static void UpdateBook(Book book)
        {
            using var database = new LibraryContext();

            database.Books.Update(book);
            database.SaveChanges();



        }

        public static bool DeleteBook(long id)
        {
            using var database = new LibraryContext();
            var dbBook = database.Books.Where(p => p.BookId == id).FirstOrDefault();
            if (dbBook != null)
            {
                database.Books.Remove(dbBook);
                database.SaveChanges();
                return true;
            }
            return false;

        }

        public static long GetBookIdByISBN(string isbn)
        {
            using var database = new LibraryContext();

            var book = database.Books.Where(b => b.ISBN == isbn).FirstOrDefault();

            if (book!=null)
            {
                return book.BookId;
            }
            return -1;
                
                

           
        }

        public static IList<Book> GetBooksByAuthor(string author)
        {
            using var database = new LibraryContext();
            
            var books = database.Books
                .FromSqlRaw("SELECT * FROM dbo.Books bo join dbo.BookAuthor ba on bo.BookId=ba.BA_BookId " +
                "join dbo.Authors au on ba.BA_AuthorId=au.AuthorId where au.FirstName={0}",author)
                .ToList();

            return books;


        }
    }
}
