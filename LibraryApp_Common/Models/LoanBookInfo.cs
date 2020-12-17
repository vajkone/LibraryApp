using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp_Common.Models
{
    public class LoanBookInfo
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Pages { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public override string ToString()
        {
            return this.Title + " - " + Author.FirstName + " " + Author.LastName;
        }
    }
}
