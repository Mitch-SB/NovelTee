using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NovelTee.Models;
using NovelTee.ViewModels;
using System.Data.Entity;

namespace NovelTee.Controllers
{
    public class CartsController : Controller
    {
        private ApplicationDbContext _context;
        
        public CartsController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: Cart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            var viewModel = new CartViewModel
            {
                Product = _context.Products.ToList(),
                TeeVariant = _context.TeeVariants.ToList(),
                Category = _context.Categories.ToList(),
                Color = _context.Colors.ToList(),
                Gender = _context.Genders.ToList(),
                Size = _context.Sizes.ToList(),
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(HttpContext);
            ViewData["CartCount"] = _context.CartItems.Where(c => c.ShoppingCartId == cart.ShoppingCartId).Count();
            return PartialView("_CartSummary");
        }

        [HttpPost]
        public ActionResult AddToCart(CartItem cartItems)
        {
            // Retrieve the product and teevariant from the database
            var addedTee = _context.Products.Single(t => t.Id == cartItems.Product.Id);
            
            foreach (TeeVariant variant in _context.TeeVariants)
            {
                if (variant.ColorId == cartItems.TeeVariant.ColorId && variant.SizeId == cartItems.TeeVariant.SizeId && variant.GenderId == cartItems.TeeVariant.GenderId)
                {
                    cartItems.TeeVariantId = variant.Id;
                    cartItems.TeeVariant.Id = variant.Id;
                }
            }

            var addedVariant = _context.TeeVariants.Single(v => v.Id == cartItems.TeeVariant.Id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            if (addedTee != null && addedVariant != null)
            {
                cart.AddToCart(addedTee, addedVariant);
            }

            // Go back to the main store page for more shopping

            return RedirectToAction("Index", "Carts");
        }

        public ActionResult RemoveFromCart(int prodId, int varId)
        {
            // Retrieve the product and teevariant from the database

            //Remove it from the shopping cart
            var cart = ShoppingCart.GetCart(HttpContext);

            if (cart != null)
            {
                cart.RemoveFromCart(prodId, varId);
            }

            return RedirectToAction("Index");        
        }

        public ActionResult ClearCart()
        {
            var cart = ShoppingCart.GetCart(HttpContext);
            cart.ClearCart();
            return RedirectToAction("Index");
        }
        
        public ActionResult Update(int prodId, int varId, int qty)
        {
            var cart = ShoppingCart.GetCart(HttpContext);
            cart.Update(prodId, varId, qty);
            
            return RedirectToAction("Index");
        }
    }
}