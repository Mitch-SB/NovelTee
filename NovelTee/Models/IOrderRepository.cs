﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovelTee.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}