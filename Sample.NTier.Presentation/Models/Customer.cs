using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleNTier.Models
{

    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
    }
}