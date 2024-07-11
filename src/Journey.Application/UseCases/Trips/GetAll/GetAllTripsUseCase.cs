using Journey.Communication.Responses;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.GetAll
{
    public class GetAllTripsUseCase
    {
        public ResponseTripsJson Execute()
        {
            var dbContext = new JourneyDbContext();

            var trips = dbContext.Trips.ToList();

            return new ResponseTripsJson
            {
                Trips = trips.Select(x => new ResponseShortTripJson
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                }).ToList()
            };
        }
    }
}
