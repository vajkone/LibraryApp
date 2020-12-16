
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

        public static IList<Book> GetBooksByTitle(string title)
        {
            using var database = new LibraryContext();

            var books = database.Books.Where(b=>b.Title.Contains(title) || b.Title.StartsWith(title) || b.Title.EndsWith(title))
               .ToList();

            return books;
        }

        public static Book GetBookByInvNum(string invnum)
        {
            using var database = new LibraryContext();

            var book = database.Books
                .FromSqlRaw("Select * From dbo.Books bo join dbo.LibraryBook lb on bo.BookId=lb.LB_BookId " +
                "where lb.InventoryNumber={0}", invnum).FirstOrDefault();

            return book;
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

        public static Author GetBookAuthorById(long bookid)
        {
            using var database = new LibraryContext();
            var author = database.Authors
                .FromSqlRaw("SELECT * FROM dbo.Authors au join dbo.BookAuthor ba on au.AuthorId=ba.BA_AuthorId " +
                "where ba.BA_BookId={0}", bookid).FirstOrDefault();

            return author;

        }
        public static IList<LoanBook> GetBooksOfMember(long memberId)
        {
            using var database = new LibraryContext();
            /*
            var books = database.Books
                .FromSqlRaw("SELECT * FROM dbo.Books bo join dbo.LibraryBook lb on bo.BookId=lb.LB_BookId " +
                "join dbo.LoanBook lobo on lb.InventoryNumber=lobo.LB_InventoryNumber where lobo.LB_MemberId={0}", memberId)
                .ToList();

            var librarybooks = database.LibraryBook
                .FromSqlRaw("SELECT * FROM dbo.LibraryBook lb join dbo.LoanBook lobo on lb.InventoryNumber=lobo.LB_InventoryNumber " +
                "where lobo.LB_MemberId={0}", memberId)
                .ToList();

            */

            var loanbooks = database.LoanBook
                .Where(lb => lb.LB_MemberId == memberId).ToList();


           

            return loanbooks;
        }
    }
}
