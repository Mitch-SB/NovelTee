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
            var viewModel = new CartViewModel
            {
                Product = _context.Products.ToList(),
                TeeVariant = _context.TeeVariants.ToList(),
                Category = _context.Categories.ToList(),
                Color = _context.Colors.ToList(),
                Gender = _context.Genders.ToList(),
                Size = _context.Sizes.ToList(),
            };

            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult AddToCart(CartItems cartItems)
        {
            /*  TeeVariant.ColorId: 2
                TeeVariant.GenderId: 1
                TeeVariant.SizeId: 2
                Product.Id: 11
                TeeVariant.Id:
             
             */


            //if (!ModelState.IsValid)
            //{
            //    ShoppingCart shoppingCart = new ShoppingCart();
            //    if (User.Identity == null)
            //    {
            //        return RedirectToAction("Index");
            //    }

            //    var newShoppingCart = new ShoppingCart
            //    {
            //        ApplicationUserId = ShoppingCart.Guest,
            //        CreatedDate = DateTime.Today
            //    };
            //    _context.ShoppingCarts.Add(newShoppingCart);
            //    _context.SaveChanges();
            //}

            //if(cartItems.Id == 0)
            //{
            //    var itemsInDb = new CartItems();
            //    var variant = _context.TeeVariants.ToList();

            //    foreach (var tee in variant)
            //    {
            //        if (tee.ColorId == cartItems.TeeVariant.ColorId && tee.SizeId == cartItems.TeeVariant.SizeId && tee.GenderId == cartItems.TeeVariant.GenderId)
            //        {
            //            cartItems.TeeVariantId = tee.Id;
            //        }
            //    }

            //    itemsInDb.ProductId = cartItems.Product.Id;
            //    itemsInDb.TeeVariantId = cartItems.TeeVariantId;

            //    if (!ModelState.IsValid)
            //    {
            //        //itemsInDb.ShoppingCartId = ShoppingCart.Guest;
            //    }


            //    itemsInDb.Quantity = 1;

            //    _context.CartItems.Add(itemsInDb);
            //    _context.SaveChanges();
            //}


            //Check if session with cart is empty
            if (Session["cart"] == null)
            {
                List<CartItems> cart = new List<CartItems>();

                var variant = _context.TeeVariants.ToList();

                foreach (var tee in variant)
                {
                    if (tee.ColorId == cartItems.TeeVariant.ColorId && tee.SizeId == cartItems.TeeVariant.SizeId && tee.GenderId == cartItems.TeeVariant.GenderId)
                    {
                        cartItems.TeeVariantId = tee.Id;
                        cartItems.TeeVariant.Id = tee.Id;
                    }
                }

                cart.Add(new CartItems
                {
                    Product = cartItems.Product,
                    ProductId = cartItems.Product.Id,
                    TeeVariantId = cartItems.TeeVariantId,
                    TeeVariant = cartItems.TeeVariant,
                    ShoppingCart = cartItems.ShoppingCart,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            // if Session["cart"] already has data
            else
            {
                List<CartItems> cart = (List<CartItems>)Session["cart"];
                var variant = _context.TeeVariants.ToList();

                foreach (var tee in variant)
                {
                    if (tee.ColorId == cartItems.TeeVariant.ColorId && tee.SizeId == cartItems.TeeVariant.SizeId && tee.GenderId == cartItems.TeeVariant.GenderId)
                    {
                        cartItems.TeeVariantId = tee.Id;
                        cartItems.TeeVariant.Id = tee.Id;
                    }
                }

                int index = IsExist(cartItems.Product.Id, cartItems.TeeVariant.Id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItems {
                        Product = cartItems.Product,
                        ProductId = cartItems.Product.Id,
                        TeeVariantId = cartItems.TeeVariantId,
                        TeeVariant = cartItems.TeeVariant,
                        ShoppingCart = cartItems.ShoppingCart,
                        Quantity = 1
                    });
                }
                Session["cart"] = cart;
            }

            return RedirectToAction("Index", "Carts");
        }

        public ActionResult Remove(int prodId, int varId)
        {
            List<CartItems> cart = (List<CartItems>)Session["cart"];
            int index = IsExist(prodId, varId);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            if (cart.Count == 0)
                Session["cart"] = null;
            return RedirectToAction("Index");           
        }

        private int IsExist(int prodId, int VarId)
        {
            List<CartItems> cart = (List<CartItems>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(prodId) && cart[i].TeeVariant.Id.Equals(VarId))
                    return i;
            return -1;
        }
        
        public ActionResult Update(int prodId, int varId, int qty)
        {
            List<CartItems> cart = (List<CartItems>)Session["cart"];
            int index = IsExist(prodId, varId);
            cart[index].Quantity = qty;
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
    }
}