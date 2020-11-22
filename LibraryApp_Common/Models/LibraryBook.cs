using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_Common.Models
{
    public class LibraryBook
    {
        [Key]
        public string InventoryNumber { get; set; }

        [ForeignKey("Book")]
        public long LB_BookId { get; set; }
        public Book Book { get; set; }

        public bool CurrentlyLoaned { get; set; }

        public override string ToString()
        {
            return InventoryNumber+" - "+ (CurrentlyLoaned?"Currently Loaned":"Available");
        }

        private string GetAvailability()
        {
            if (CurrentlyLoaned)
            {
                return "Currently loaned";
            }
            else return "Available";
        }

    }
}
