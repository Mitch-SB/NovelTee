using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NovelTee.Models;

namespace NovelTee.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public TeeVariant TeeVariant { get; set; }
        public IEnumerable<Color> Color { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
        public IEnumerable<Size> Size { get; set; }

    }
}