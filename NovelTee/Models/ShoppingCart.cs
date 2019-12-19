using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovelTee.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public static readonly string Guest = "497c74e3-78d8-415b-a590-38006e849e41";
    }
}