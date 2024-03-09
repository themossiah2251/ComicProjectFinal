﻿using ComicProjectFinal.Models;

namespace ComicProjectFinal.Models.DTO
{
    public class ProductDisplayModel
    {
        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string STerm { get; set; } = "";
        public int CategoryId { get; set; } = 0;
    }
}
