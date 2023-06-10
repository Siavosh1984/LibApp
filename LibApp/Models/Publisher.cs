using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Publisher
    {

        [Key]
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }

        public string PublisherWebsite { get; set; }

        // a book has one publisher
        // a publisher can have many books
        
    }
}