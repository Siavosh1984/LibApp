using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibApp.Models
{
    public class Book
    {

        [Key]
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string author { get; set; }

        public int ISBN { get; set; }

        public string genre { get; set; }

        [ForeignKey("Publishers")]
        public int PublisherID { get; set; }
        public virtual Publisher Publishers { get; set; }

        // A book can be borrowed by many borrowers
        public ICollection<Borrower> Borrowers { get; set; }
    }


    public class BookDto
    {

        public int BookID { get; set; }
        public string BookName { get; set; }

        public string author { get; set; }

        public int ISBN { get; set; }

        public string genre { get; set; }



    }
}