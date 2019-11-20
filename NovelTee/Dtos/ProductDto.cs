using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NovelTee.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public byte CategoryID { get; set; }
        
        public String ImagePath { get; set; }
        
        public HttpPostedFileBase ImageFile { get; set; }
    }
}