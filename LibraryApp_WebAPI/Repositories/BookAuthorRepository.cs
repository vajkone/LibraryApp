using LibraryApp_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Repositories
{
    public class BookAuthorRepository
    {
        public static void AddBookAuthorLink(BookAuthor ba)
        {
            using var database = new LibraryContext();
            database.BookAuthor.Add(ba);
            database.SaveChanges();

        }
    }
}
