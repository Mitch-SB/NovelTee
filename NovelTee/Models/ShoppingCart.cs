using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovelTee.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}