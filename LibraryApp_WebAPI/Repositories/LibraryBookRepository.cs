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

        public static bool DeleteLibraryBook(string invnum)
        {
            using var database = new LibraryContext();
            var dbBook = database.LibraryBook.Where(p => p.InventoryNumber == invnum).FirstOrDefault();
            if (dbBook != null)
            {
                database.LibraryBook.Remove(dbBook);
                database.SaveChanges();
                return true;
            }
            return false;
        }

        public static void LendReturnLibraryBook(LibraryBook libBook)
        {
            using var database = new LibraryContext();
            if (libBook.CurrentlyLoaned)
            {
                libBook.CurrentlyLoaned = false;
            }
            else
            {
                libBook.CurrentlyLoaned = true;
            }
            database.LibraryBook.Update(libBook);
            database.SaveChanges();
        }
    }
}
