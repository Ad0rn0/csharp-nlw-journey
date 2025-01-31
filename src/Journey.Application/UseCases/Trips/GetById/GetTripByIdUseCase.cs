﻿using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetById
{
    public class GetTripByIdUseCase
    {
        public ResponseTripJson Excute(Guid id)
        {
            var dbContext = new JourneyDbContext();

             var trip = dbContext
                .Trips
                .Include(x => x.Activities)
                .FirstOrDefault(x => x.Id == id);
            
            if (trip is null)
            {
                throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
            }

            return new ResponseTripJson
            {
                Id = trip.Id,
                Name = trip.Name,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                Activities = trip.Activities.Select(x => new ResponseActivityJson
                {
                    Id = x.Id,
                    Name = x.Name,
                    Date = x.Date,
                    Status = (Communication.Enums.ActivityStatus)x.Status
                }).ToList()
            };
        }
    }
}
