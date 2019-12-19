using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovelTee.Models
{
    public class CartItems
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public TeeVariant TeeVariant { get; set; }
        public int TeeVariantId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string ShoppingCartId { get; set; }
        public int Quantity { get; set; }

    }
}