namespace Planefall.Services.Models.Flight
{
    using System.Collections.Generic;
    using Common.Mapping.Interfaces;
    using Planefall.Models;
    using Ticket;

    public class FlightDetailsServiceModel : IMapWith<Flight>
    {
        public string Id { get; set; }

        public string FlightNumber { get; set; }

        public ICollection<TicketListingServiceModel> Tickets { get; set; }
    }
}