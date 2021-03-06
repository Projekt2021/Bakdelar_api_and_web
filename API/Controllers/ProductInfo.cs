﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Controllers
{
    /// <summary>
    /// Partial product info is exposed
    /// </summary>
    public class ProductInfo
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageLink { get; set; }
        public double SalePrice { get; set; }
    }
}
