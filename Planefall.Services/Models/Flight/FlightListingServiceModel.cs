namespace Planefall.Services.Models.Flight
{
    using System;
    using Common.Mapping.Interfaces;
    using Planefall.Models;

    public class FlightListingServiceModel : IMapWith<Flight>
    {
        public string Id { get; set; }

        public string FromAirport { get; set; }

        public string ToAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string PlaneType { get; set; }

        public string FlightNumber { get; set; }

        public string PilotName { get; set; }

        public int RegularSeats { get; set; }

        public int BusinessSeats { get; set; }
    }
}