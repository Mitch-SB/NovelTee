﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NovelTee.Models;

namespace NovelTee.ViewModels
{
    public class RandomTeeViewModel
    {
        public Tee Tee { get; set; }
        public IEnumerable<Image> Image { get; set; }

    }
}