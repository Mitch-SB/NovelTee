using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NovelTee.Models;
using System.ComponentModel.DataAnnotations;

namespace NovelTee.ViewModels
{
    public class NewProductFormViewModel
    {
        public Product Product { get; set; }
        public TeeVariant TeeVariant { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Image> Image { get; set; }
    }
}