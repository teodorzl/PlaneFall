namespace Planefall.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Flight;
    using Planefall.Models;

    public class FlightsService : BaseService, IFlightsService
    {
        public FlightsService(PlanefallDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FlightListingServiceModel>> GetAllFlightsAsync()
        {
            var flights = await this.Context.Flights
                .ProjectTo<FlightListingServiceModel>()
                .ToArrayAsync();

            return flights;
        }

        public async Task<FlightDetailsServiceModel> GetDetailsAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            var flight = await this.Context.Flights
                .Include(f => f.Tickets)
                .SingleOrDefaultAsync(f => f.Id == id);

            if (flight == null)
            {
                return null;
            }

            var serviceFlight = Mapper.Map<FlightDetailsServiceModel>(flight);

            return serviceFlight;
        }

        public async Task<bool> CreateAsync(FlightCreateServiceModel model)
        {
            if (!this.IsEntityStateValid(model))
            {
                return false;
            }

            var flight = Mapper.Map<Flight>(model);

            await this.Context.Flights.AddAsync(flight);

            await this.Context.SaveChangesAsync();

            return true;
        }
    }
}