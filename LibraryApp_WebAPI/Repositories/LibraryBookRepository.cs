using LibraryApp_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Repositories
{
    public class LibraryBookRepository
    {
        public static IList<LibraryBook> GetLibraryBooks(long bookid)
        {

            using var database = new LibraryContext();
            var libraryBooks = database.LibraryBook.Where(lb=>lb.LB_BookId==bookid).ToList();
            return libraryBooks;


        }

        public static LibraryBook GetLibraryBook(string invNum)
        {

            using var database = new LibraryContext();
            var libraryBook = database.LibraryBook.Where(b => b.InventoryNumber == invNum).FirstOrDefault();
            return libraryBook;


        }

        public static void AddLibraryBook(LibraryBook libraryBook)
        {
            using var database = new LibraryContext();
            database.LibraryBook.Add(libraryBook);
            database.SaveChanges();

        }

        public static void LendLibraryBook(LibraryBook lbook)
        {
            using var database = new LibraryContext();
            lbook.CurrentlyLoaned = true;
            database.LibraryBook.Update(lbook);
            database.SaveChanges();
        }
    }
}
