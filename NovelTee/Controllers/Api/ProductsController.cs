using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NovelTee.Models;
using System.ComponentModel.DataAnnotations;
using NovelTee.Dtos;
using AutoMapper;

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
        public IEnumerable<ProductDto> GetProducts()
        {
            return _context.Products.ToList().Select(Mapper.Map<Product, ProductDto>);
        }

        //GET /api/products/1
        public ProductDto GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Product, ProductDto>(product);
        }

        //POST /api/products
        [HttpPost]
        public ProductDto CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.Id = product.Id;

            return productDto;
            //NEEDS MORE for images
        }

        //PUT /api/products/1
        [HttpPut]
        public void UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);
            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(productDto, productInDb);

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
