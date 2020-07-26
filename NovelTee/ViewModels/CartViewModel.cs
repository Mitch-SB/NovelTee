using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NovelTee.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelTee.ViewModels
{
    public class CartViewModel
    {
        public List<Product> Product { get; set; }
        public IEnumerable<TeeVariant> TeeVariant { get; set; }
        public IEnumerable<Category> Category { get; set; }

        public IEnumerable<Color> Color { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
        public IEnumerable<Size> Size { get; set; }

        public CartItem CartItems { get; set; }

    }
}