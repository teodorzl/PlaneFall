namespace Planefall.Services.Models.Flight
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Common.Mapping.Interfaces;
    using Planefall.Models;

    public class FlightBookingServiceModel : IHaveCustomMapping
    {
        public string Id { get; set; }

        public string FromAirport { get; set; }

        public string ToAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string FlightNumber { get; set; }

        public int RemainingRegularSeats { get; set; }

        public int RemainingBusinessSeats { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Flight, FlightBookingServiceModel>()
                .ForMember(dest => dest.RemainingRegularSeats,
                    opt => opt.MapFrom(src =>
                        src.RegularSeats - src.Tickets.Count(t => t.TicketType == TicketType.Regular)))
                .ForMember(dest => dest.RemainingBusinessSeats,
                    opt => opt.MapFrom(src =>
                        src.BusinessSeats - src.Tickets.Count(t => t.TicketType == TicketType.Business)));
        }
    }
}