using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NovelTee.Models;
using NovelTee.ViewModels;
using System.Data.Entity;
using System.IO;
using System.Configuration;

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
                Color = _context.Colors.ToList(),
                Gender = _context.Genders.ToList(),
                Size = _context.Sizes.ToList()
            };

            ViewData["Title"] = "Product";

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        public ActionResult CreateProduct(NewProductFormViewModel newProduct)
        {
            //Get File Name
            var fileName = Path.GetFileNameWithoutExtension(newProduct.ImageFile.FileName);
            //Get File Extension
            var fileExtension = Path.GetExtension(newProduct.ImageFile.FileName);
            //Add Current Date to Attached File Name
            fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + fileName.Trim() + fileExtension;
            //Get Upload path from Web.Config file AppSettings
            string uploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
            //Create complete path to store in server
            newProduct.Product.ImagePath = uploadPath + fileName;
            //Copy and Save File into server
            newProduct.ImageFile.SaveAs(Server.MapPath(Path.Combine(uploadPath, fileName)));

            _context.Products.Add(newProduct.Product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
        
        public ActionResult New()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new NewProductFormViewModel
            {
                Product = new Product(),
                Category = categories

            };
            
            return View("New", viewModel);
        }

        public ActionResult AddToCart(ProductFormViewModel viewModel)
        {
            //_context.Tees.

            return View(viewModel);
        }
        
        
    }
}