namespace Planefall.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FlightsService : BaseService, IFlightsService
    {
        public FlightsService(PlanefallDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FlightListingServiceModel>> GetAllFlightsAsync()
        {
            var serviceBooks = await this.Context.Flights
                .ProjectTo<FlightListingServiceModel>()
                .ToArrayAsync();

            return serviceBooks;
        }
    }
}