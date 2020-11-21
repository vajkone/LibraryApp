using LibraryApp_Common.Models;
using Microsoft.EntityFrameworkCore;
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

        public static Author GetAuthorByBookId(long bookid)
        {
            using var database = new LibraryContext();
            var author = database.Authors
            .FromSqlRaw("SELECT * FROM dbo.Authors au join dbo.BookAuthor ba on au.AuthorId=ba.BA_AuthorId " +
                "join dbo.Books bo on ba.BA_BookId=bo.BookId where bo.bookId={0}", bookid).FirstOrDefault();

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
