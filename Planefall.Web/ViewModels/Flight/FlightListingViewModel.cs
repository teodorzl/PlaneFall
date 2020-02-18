namespace Planefall.ViewModels.Flight
{
    using System;
    using Common.Mapping.Interfaces;
    using Services.Models;

    public class FlightListingViewModel : IMapWith<FlightListingServiceModel>
    {
        public string Id { get; set; }

        public string FromAirport { get; set; }

        public string ToAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string PlaneType { get; set; }

        public string FlightNumber { get; set; }

        public int RegularSeats { get; set; }

        public int BusinessSeats { get; set; }
    }
}