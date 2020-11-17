using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Models
{
    public class LoanBook
    {
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }

        [ForeignKey("LibraryBook")]
        public string InventoryNumber { get; set; }
        public LibraryBook LibraryBook { get; set; }

        public DateTime LoanDate { get; set; }
        
        public DateTime returnDate { get; set; }
    }
}
