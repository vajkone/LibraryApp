using LibraryApp_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Repositories
{
    public class LibraryBookRepository
    {
        public static IList<LibraryBook> GetLibraryBooks()
        {

            using var database = new LibraryContext();
            var libraryBooks = database.LibraryBook.ToList();
            return libraryBooks;


        }

        public static LibraryBook GetLibraryBook(long id)
        {

            using var database = new LibraryContext();
            var libraryBook = database.LibraryBook.Where(b => b.LB_BookId == id).FirstOrDefault();
            return libraryBook;


        }

        public static void AddLibraryBook(LibraryBook libraryBook)
        {
            using var database = new LibraryContext();
            database.LibraryBook.Add(libraryBook);
            database.SaveChanges();

        }
    }
}
