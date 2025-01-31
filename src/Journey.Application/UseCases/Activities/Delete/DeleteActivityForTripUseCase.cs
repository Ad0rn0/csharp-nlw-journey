﻿using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Activities.Delete
{
    public class DeleteActivityForTripUseCase
    {
        public void Execute( Guid tripId, Guid activityId)
        {

            var dbContext = new JourneyDbContext();

            var avtivity = dbContext
                .Activities
                .FirstOrDefault(x => x.Id == activityId && x.TripId == tripId);

            if (avtivity is null)
            {
                throw new NotFoundException(ResourceErrorMessages.ACTIVITY_NOT_FOUND);
            }

            dbContext.Activities.Remove(avtivity);
            dbContext.SaveChanges();
        }
    }
}
