using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovelTee.Dtos
{
    public class CategoryDto
    {
        public byte Id { get; set; }
        public string Cat_Name { get; set; }
        public string Description { get; set; }

        public static readonly byte Tees = 1;
        public static readonly byte Tanks = 2;
        public static readonly byte Hoods = 3;
    }
}