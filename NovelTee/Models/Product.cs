﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NovelTee.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }
        [Display(Name = "Category")]
        public byte CategoryID { get; set; }

        public String ImagePath { get; set; }
        //public HttpPostedFile ImageFile { get; set; }

    }
}