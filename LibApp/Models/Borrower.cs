using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Borrower
    {

        [Key]
        public int BorrowerID { get; set; }
        public string BorrowerFirstName { get; set; }
        public string BorrowerLastName { get; set; }

        public int BorrowerPhoneNumber { get; set; }

        //A borrower can borrow many books
        public ICollection<Book> Books { get; set; }

    }
}