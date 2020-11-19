using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_Common.Models
{
    public class Book
    {
        //[Key]
        public long BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Pages { get; set; }

    }
}
