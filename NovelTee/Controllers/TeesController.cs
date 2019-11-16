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
    public class TeesController : Controller
    {
        private ApplicationDbContext _context;

        public TeesController()
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
            var tees = _context.Tees.Include(t => t.Image).ToList();

            return View(tees);
        }

        public ActionResult Details(int id)
        {
            var tee = _context.Tees.SingleOrDefault(t => t.Id == id);
            if (tee == null)
                HttpNotFound();

            var viewModel = new TeeFormViewModel
            {
                Tee = tee,
                Image = _context.Images.ToList(),
                Color = _context.Colors.ToList(),
                Gender = _context.Genders.ToList(),
                Size = _context.Sizes.ToList()
            };
            
            return View("Details", viewModel);
        }

        public ActionResult Product(int id)
        {
            var tee = _context.Tees.SingleOrDefault(t => t.Id == id);
            if (tee == null)
                HttpNotFound();

            var viewModel = new TeeFormViewModel
            {
                Tee = tee,
                Image = _context.Images.ToList(),
                Color = _context.Colors.ToList(),
                Gender = _context.Genders.ToList(),
                Size = _context.Sizes.ToList()
            };

            ViewData["Title"] = "Product";

            return View("TeeForm", viewModel);
        }

        public ActionResult AddToCart(TeeFormViewModel viewModel)
        {
            //_context.Tees.

            return View(viewModel);
        }

        //public ActionResult Random()
        //{
        //    //var tee = _context.Tees.ToList();
        //    var tee = _context.Tees.SingleOrDefault();
        //    var img = _context.Images.ToList();

        //    var viewModel = new RandomTeeViewModel
        //    {
        //        //Tee = tee
        //        Image = img
        //    };

        //    return View(viewModel);
        //}

        //public IEnumerable<Tee> GetTees()
        //{
        //    return new List<Tee>
        //    {
        //        new Tee {Id = 1, Name = "Coffee Tea"},
        //        new Tee {Id = 2, Name = "Tea Tee"},
        //        new Tee {Id = 3, Name = "Book Tee"},
        //        new Tee {Id = 4, Name = "Game Tee"},
        //        new Tee {Id = 5, Name = "PC Tee"},
        //        new Tee {Id = 6, Name = "Pot Tee"},
        //        new Tee {Id = 7, Name = "Novel Tee"}
        //    };
        //}
        
    }
}