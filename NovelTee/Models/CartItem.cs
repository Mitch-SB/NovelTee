using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NovelTee.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public string ShoppingCartId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        public TeeVariant TeeVariant { get; set; }
        public int TeeVariantId { get; set; }
        //public ShoppingCart ShoppingCart { get; set; }
        //public string ShoppingCartId { get; set; } //???//
        public int Quantity { get; set; }

    }
}