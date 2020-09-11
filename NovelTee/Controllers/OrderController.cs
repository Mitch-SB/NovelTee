using Microsoft.AspNetCore.Mvc;
using NovelTee.Models;
using NovelTee.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovelTee.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private static ApplicationDbContext _context;
        private static ShoppingCart shoppingCart;
        
        public OrderController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Checkout()
        {
            var cart = ShoppingCart.GetCart(HttpContext);
            int qty = 0;

            var viewModel = new OrderViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            foreach (var item in viewModel.CartItems)
            {
                qty += item.Quantity;
            }

            ViewData["CartQty"] = qty;

            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult ProductCard()
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
            return PartialView("_ProductCard", viewModel);
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var cart = ShoppingCart.GetCart(HttpContext);
            shoppingCart = cart;
            shoppingCart.CartItems = cart.GetCartItems();

            if(shoppingCart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                OrderRepository _orderRepository = new OrderRepository(_context, shoppingCart);
                _orderRepository.CreateOrder(order);
                
                
                shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public ActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for your order!";
            return View();
        }
        
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
    }
}