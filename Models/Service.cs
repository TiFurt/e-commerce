﻿namespace e_commerce.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public bool HasOffer { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}
