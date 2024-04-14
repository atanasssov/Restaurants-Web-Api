﻿
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }

    }
}