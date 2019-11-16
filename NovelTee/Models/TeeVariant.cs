using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovelTee.Models
{
    public class TeeVariant
    {
        public int Id { get; set; }

        public Color Color { get; set; }
        public byte ColorId { get; set; }

        public Size Size { get; set; }
        public byte SizeId { get; set; }

        public Gender Gender { get; set; }
        public byte GenderId { get; set; }

        public byte Quantity { get; set; }

    }
}