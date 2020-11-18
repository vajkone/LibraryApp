using LibraryApp_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Repositories
{
    public class AuthorRepository
    {
        public static IList<Author> GetAuthors()
        {

            using var database = new LibraryContext();
            var authors = database.Authors.ToList();
            return authors;


        }

        public static Author GetAuthor(long id)
        {

            using var database = new LibraryContext();
            var author = database.Authors.Where(b => b.AuthorId == id).FirstOrDefault();
            return author;


        }

        public static void AddAuthor(Author author)
        {
            using var database = new LibraryContext();
            database.Authors.Add(author);
            database.SaveChanges();

        }



        public static void UpdateAuthor(Author author)
        {
            using var database = new LibraryContext();

            database.Authors.Update(author);
            database.SaveChanges();



        }

        public static bool DeleteAuthor(long id)
        {
            using var database = new LibraryContext();
            var dbAuthor = database.Authors.Where(p => p.AuthorId == id).FirstOrDefault();
            if (dbAuthor != null)
            {
                database.Authors.Remove(dbAuthor);
                database.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
