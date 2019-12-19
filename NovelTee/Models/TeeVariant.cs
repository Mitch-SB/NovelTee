using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NovelTee.Models
{
    public class TeeVariant
    {
        public int Id { get; set; }
        
        public Color Color { get; set; }
        [Display(Name = "Color")]
        [Required]
        public byte ColorId { get; set; }

        public Size Size { get; set; }
        [Display(Name = "Size")]
        [Required]
        public byte SizeId { get; set; }

        public Gender Gender { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public byte GenderId { get; set; }

        public byte Quantity { get; set; }

    }
}