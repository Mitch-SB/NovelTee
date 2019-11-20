using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NovelTee.Models;
using System.ComponentModel.DataAnnotations;

namespace NovelTee.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/products
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        //GET /api/products/1
        public Product GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return product;
        }

        //POST /api/products
        [HttpPost]
        public Product CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
            //NEEDS MORE for images
        }

        //PUT /api/products/1
        [HttpPut]
        public void UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);
            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            productInDb.Name = product.Name;
            productInDb.Description = product.Description;
            productInDb.CategoryID = product.CategoryID;
            productInDb.ImageFile = product.ImageFile;
            productInDb.ImagePath = product.ImagePath;
            productInDb.Price = product.Price;

            _context.SaveChanges();
        }

        //DELETE /api/products/1
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Products.Remove(productInDb);
            _context.SaveChanges();
        }
    }
}
