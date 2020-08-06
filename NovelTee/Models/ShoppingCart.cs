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
        
        public void AddToCart(Product product, TeeVariant teeVariant)
        {
            //Get the cart
            var cartItem = _context.CartItems.SingleOrDefault(c => c.ShoppingCartId == ShoppingCartId && c.ProductId == product.Id && c.TeeVariantId == teeVariant.Id);

            //Check if session with cart is empty
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = product.Id,
                    ShoppingCartId = ShoppingCartId,
                    TeeVariantId = teeVariant.Id,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
            }
            // if Session["cart"] already has data
            else
            {
                cartItem.Quantity++;                
            }

            _context.SaveChanges();
        }

        public int RemoveFromCart(int product, int teeVariant)
        {
            var cartItem = _context.CartItems.SingleOrDefault(c => c.ShoppingCartId == ShoppingCartId && c.ProductId == product && c.TeeVariantId == teeVariant);

            var localQuantity = 0;

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
            }

            _context.SaveChanges();
            return localQuantity;
        }
                
        public List<CartItem> GetCartItems()
        {
            return _context.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId).ToList();
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in _context.CartItems where cartItems.ShoppingCartId == ShoppingCartId select (int?)cartItems.Quantity * cartItems.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        public void ClearCart()
        {
            var cartItem = _context.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId);

            _context.CartItems.RemoveRange(cartItem);
            _context.SaveChanges();
        }

        public decimal GetCartTotal()
        {
            var total = _context.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Product.Price * c.Quantity).Sum();

            return total;
        }

        public int Update(int prodId, int varId, int qty)
        {
            var cartItem = _context.CartItems.SingleOrDefault(c => c.ShoppingCartId == ShoppingCartId && c.ProductId == prodId && c.TeeVariantId == varId);
            
            if (cartItem != null)
            {
                cartItem.Quantity = qty;

                if (cartItem.Quantity == 0)
                {
                    RemoveFromCart(prodId, varId);
                }
            }
            _context.SaveChanges();
            return qty;
        }
    }
}