﻿using Microsoft.Extensions.Logging;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

using MediatR;
using AutoMapper;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler (ILogger<CreateDishCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository,
        IMapper mapper,
        IDishesRepository dishesRepository) : IRequestHandler<CreateDishCommand, int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new dish: {@DishRequest}", request);

            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());


            var dish = mapper.Map<Dish>(request);

           return await dishesRepository.Create(dish);
        }

      
    }
}