using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_Common.Models
{
    public class Member
    {
        [Key]
        public long MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegistratioNDate { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
