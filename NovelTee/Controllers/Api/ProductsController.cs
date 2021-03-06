﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NovelTee.Models;
using System.ComponentModel.DataAnnotations;
using NovelTee.Dtos;
using AutoMapper;
using System.Data.Entity;

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

            return _context.Products
                .Include(p => p.Category)
                .ToList()
                .Select(Mapper.Map<Product, ProductDto>);
        }

        //GET /api/products/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();
            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        //POST /api/products
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageProducts)]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.Id = product.Id;

            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
            //NEEDS MORE for images
        }

        //PUT /api/products/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageProducts)]
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
        [Authorize(Roles = RoleName.CanManageProducts)]
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
