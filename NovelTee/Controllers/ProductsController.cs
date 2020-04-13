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
using PagedList;

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
        public ViewResult Index(string search, int? i)
        {
            if (User.IsInRole("CanManageProducts"))
            {
                return View("ManageProduct");
            }

            var product = _context.Products.ToList();
            ViewData["Title"] = "Index";

            return View(product.ToPagedList(i ?? 1, 6));
        }

        public ViewResult ManageProduct()
        {
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

        public ActionResult Tees(string search, int? i)
        {
            var product = _context.Products.Include(p => p.Category).ToList().Where(p => p.CategoryID == Category.Tees);
            ViewData["Title"] = "Tees";
            return View("Index", product.ToPagedList(i ?? 1, 6));
        }

        public ActionResult Tanks(string search, int? i)
        {
            var product = _context.Products.Include(p => p.Category).ToList().Where(p => p.CategoryID == Category.Tanks);
            ViewData["Title"] = "Tanks";
            return View("Index", product.ToPagedList(i ?? 1, 6));
        }

        public ActionResult Hoodies(string search, int? i)
        {
            var product = _context.Products.Include(p => p.Category).ToList().Where(p => p.CategoryID == Category.Hoods);
            ViewData["Title"] = "Hoodies";
            return View("Index", product.ToPagedList(i ?? 1, 6));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel
                {
                    Product = product,
                    Category = _context.Categories.ToList()
                };
                return View("New", viewModel);
            }

            if (product.Id == 0)
            {
                //Get File Name
                var fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                //Get File Extension
                var fileExtension = Path.GetExtension(product.ImageFile.FileName);
                //Add Current Date to Attached File Name
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + fileName.Trim() + fileExtension;
                //Get Upload path from Web.Config file AppSettings
                string uploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
                //Create complete path to store in server
                product.ImagePath = uploadPath + fileName;
                //Copy and Save File into server
                product.ImageFile.SaveAs(Server.MapPath(Path.Combine(uploadPath, fileName)));

                _context.Products.Add(product);

            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == product.Id);

                productInDb.Name = product.Name;
                productInDb.Description = product.Description;
                productInDb.Price = product.Price;
                productInDb.CategoryID = product.CategoryID;

                if (product.ImageFile != null)
                {
                    //Get File Name
                    var fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    //Get File Extension
                    var fileExtension = Path.GetExtension(product.ImageFile.FileName);
                    //Add Current Date to Attached File Name
                    fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + fileName.Trim() + fileExtension;
                    //Get Upload path from Web.Config file AppSettings
                    string uploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                    //Delete Image file in folder
                    var filePath = Server.MapPath(productInDb.ImagePath);
                    System.IO.File.Delete(filePath);

                    productInDb.ImagePath = uploadPath + fileName;
                    product.ImageFile.SaveAs(Server.MapPath(Path.Combine(uploadPath, fileName)));
                }

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        [Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult New()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new ProductFormViewModel
            {
                Product = new Product(),
                Category = categories

            };
            ViewData["Title"] = "New";

            return View("New", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel
            {
                Product = product,
                Category = _context.Categories.ToList()
            };
            ViewData["Title"] = "Edit";

            return View("New", viewModel);
        }

        public ActionResult Search(string searchString, int? i)
        {
            var products = from m in _context.Products select m;

            if (!String.IsNullOrEmpty(searchString))
                products = products.Where(p => p.Name.Contains(searchString));

            return View("Index", products.OrderBy(p => p.Id).ToPagedList(i ?? 1, 6));
        }
    }
}