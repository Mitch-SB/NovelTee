using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NovelTee.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelTee.ViewModels
{
    public class NewProductFormViewModel
    {
        public Product Product { get; set; }
        //public TeeVariant TeeVariant { get; set; }
        public IEnumerable<Category> Category { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}