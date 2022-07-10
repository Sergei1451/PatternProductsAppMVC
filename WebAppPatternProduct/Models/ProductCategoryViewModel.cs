﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppPatternProduct.Models
{
    public class ProductCategoryViewModel
    {
        public List<ProductPOCO>? Products { get; set; }
        public SelectList? Category { get; set; }
        public string? ProductCategory { get; set; }
        public string SearchString { get; set; }
    }
}
