using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NovelTee.Dtos
{
    public class TeeVariantDto
    {
        public int Id { get; set; }
                
        [Required]
        public byte ColorId { get; set; }
        
        [Required]
        public byte SizeId { get; set; }
        
        [Required]
        public byte GenderId { get; set; }

        public byte Quantity { get; set; }
    }
}