﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Models
{
    public class BookAuthor
    {
        
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }


        
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }


    }
}
