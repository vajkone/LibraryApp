using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_Common.Models 
{ 
    public class BookAuthor
    {
        
        //[ForeignKey("Author")]
        public long BA_AuthorId { get; set; }
        public Author Author { get; set; }


        
        //[ForeignKey("Book")]
        public long BA_BookId { get; set; }
        public Book Book { get; set; }


    }
}
