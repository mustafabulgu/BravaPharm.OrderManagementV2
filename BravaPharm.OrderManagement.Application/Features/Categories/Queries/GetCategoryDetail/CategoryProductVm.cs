﻿namespace BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class CategoryProductVm
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}