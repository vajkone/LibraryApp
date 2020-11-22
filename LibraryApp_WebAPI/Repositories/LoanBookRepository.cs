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

        public static long GetMemberIdByLoanBook(string invnum)
        {
            using var database = new LibraryContext();
            var member = database.LoanBook.Where(lb => lb.LB_InventoryNumber == invnum).FirstOrDefault();
            return member.LB_MemberId;

        }

        public static LoanBook GetLoanBookByInvNum(string invnum)
        {
            using var database = new LibraryContext();
            var lb = database.LoanBook.Where(lb => lb.LB_InventoryNumber == invnum).FirstOrDefault();
            return lb;
        }
    }
}
