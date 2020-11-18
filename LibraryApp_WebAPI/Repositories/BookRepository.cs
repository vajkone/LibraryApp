using LibraryApp_WebAPI.Models;
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
            var dbPerson = database.Books.Where(p => p.BookId == id).FirstOrDefault();
            if (dbPerson != null)
            {
                database.Books.Remove(dbPerson);
                database.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
