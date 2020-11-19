using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_Common.Models
{
    public class LoanBook
    {
        
        //[ForeignKey("Member")]
        public int LB_MemberId { get; set; }
        public Member Member { get; set; }

        
        //[ForeignKey("LibraryBook")]
        public long LB_InventoryNumber { get; set; }
        public LibraryBook LibraryBook { get; set; }

        public DateTime LoanDate { get; set; }
        
        public DateTime ReturnDate { get; set; }
    }
}
