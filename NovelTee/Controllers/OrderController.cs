using Microsoft.AspNetCore.Mvc;
using NovelTee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovelTee.Controllers
{
    public class OrderController : Controller
    {
        
        //private readonly ShoppingCart _shoppingCart;
        private static ApplicationDbContext _context;
        private static ShoppingCart shoppingCart;
        
        public OrderController()
        {
            _context = new ApplicationDbContext();
        }
        
        //private OrderRepository _orderRepository = new OrderRepository(_context, shoppingCart);
        
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var cart = ShoppingCart.GetCart(HttpContext);
            shoppingCart = cart;
            shoppingCart.CartItems = cart.GetCartItems();
            //cart.CartItems = cart.GetCartItems();

            //shoppingCart = ShoppingCart.GetCart(HttpContext);
            //shoppingCart.CartItems = shoppingCart.GetCartItems();

            //_shoppingCart.CartItems = cart.CartItems;

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