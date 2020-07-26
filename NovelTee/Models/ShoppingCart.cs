using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NovelTee.Models
{
    public class ShoppingCart
    {
        private ApplicationDbContext _context;

        public ShoppingCart()
        {
            _context = new ApplicationDbContext();
        }

        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "cartId";

        public List<CartItem> CartItems { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
        //public string ApplicationUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        //public static readonly string Guest = "497c74e3-78d8-415b-a590-38006e849e41";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
            
        }

        public string GetCartId(HttpContextBase context)
        {
            if(context.Session[CartSessionKey] == null)
            {
                Guid tempCartId = Guid.NewGuid();
                context.Session[CartSessionKey] = tempCartId.ToString();
            }
            
            return context.Session[CartSessionKey].ToString();
        }
    }
}