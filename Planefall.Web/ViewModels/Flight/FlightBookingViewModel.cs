namespace Planefall.ViewModels.Flight
{
    using System;
    using Common.Mapping.Interfaces;
    using Services.Models.Flight;

    public class FlightBookingViewModel : IMapWith<FlightBookingServiceModel>
    {
        public string Id { get; set; }

        public string FromAirport { get; set; }

        public string ToAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string FlightNumber { get; set; }

        public int RemainingRegularSeats { get; set; }

        public int RemainingBusinessSeats { get; set; }
    }
}