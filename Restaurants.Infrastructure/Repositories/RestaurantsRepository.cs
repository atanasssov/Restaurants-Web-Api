﻿using Microsoft.EntityFrameworkCore;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository
    {
    
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            var restaurant = await dbContext.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(r => r.Id == id);

            return restaurant;
        }

        public async Task<int> Create(Restaurant entity)
        {
            await dbContext.Restaurants.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Restaurant entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
