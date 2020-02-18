namespace Planefall.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IFlightsService
    {
        Task<IEnumerable<FlightListingServiceModel>> GetAllFlightsAsync();
    }
}