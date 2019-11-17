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
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }

        // GET: Tees
        public ViewResult Index()
        {
            //var tees = GetTees();
            //var product = _context.Products.Include(t => t.Image).ToList();
            var product = _context.Products.ToList();

            return View(product);
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.SingleOrDefault(t => t.Id == id);
            if (product == null)
                HttpNotFound();

            var viewModel = new ProductFormViewModel
            {
                Product = product,
                Image = _context.Images.ToList(),
                Color = _context.Colors.ToList(),
                Gender = _context.Genders.ToList(),
                Size = _context.Sizes.ToList()
            };
            
            return View("Details", viewModel);
        }

        public ActionResult Product(int id)
        {
            var product = _context.Products.SingleOrDefault(t => t.Id == id);
            if (product == null)
                HttpNotFound();

            var viewModel = new ProductFormViewModel
            {
                Product = product,
                Image = _context.Images.ToList(),
                Color = _context.Colors.ToList(),
                Gender = _context.Genders.ToList(),
                Size = _context.Sizes.ToList()
            };

            ViewData["Title"] = "Product";

            return View("ProductForm", viewModel);
        }
        
        public ActionResult New()
        {
            //var teeVariants = _context.TeeVariants.SingleOrDefault();
            //var product = _context.Products.SingleOrDefault();

            var viewModel = new NewProductFormViewModel
            {
                //TeeVariant = teeVariants,
                //Product = product,
                //Color = _context.Colors.ToList(),
                //Size = _context.Sizes.ToList(),
                //Gender = _context.Genders.ToList(),
                Category = _context.Categories.ToList()


            };
            
            return View(viewModel);
        }

        public ActionResult AddToCart(ProductFormViewModel viewModel)
        {
            //_context.Tees.

            return View(viewModel);
        }
        
        
    }
}