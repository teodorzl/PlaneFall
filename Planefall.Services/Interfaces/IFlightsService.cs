namespace Planefall.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Flight;

    public interface IFlightsService
    {
        Task<IEnumerable<FlightListingServiceModel>> GetAllFlightsAsync();
        Task<FlightDetailsServiceModel> GetDetailsAsync(string id);
        Task<bool> CreateAsync(FlightCreateServiceModel model);
        Task<FlightBookingServiceModel> GetBasicFlightInformationAsync(string id);
    }
}