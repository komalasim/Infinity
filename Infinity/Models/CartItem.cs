﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinity.Models
{
    public class CartItem
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}