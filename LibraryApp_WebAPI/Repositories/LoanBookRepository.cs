using LibraryApp_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Repositories
{
    public class LoanBookRepository
    {

        public static void AddLoanBook(LoanBook loanbook)
        {
            using var database = new LibraryContext();
            database.LoanBook.Add(loanbook);
            database.SaveChanges();

        }
    }
}
