namespace Planefall.ViewModels.Flight
{
    using System.Collections.Generic;
    using Common.Mapping.Interfaces;
    using Services.Models.Flight;
    using Ticket;

    public class FlightDetailsViewModel : IMapWith<FlightDetailsServiceModel>
    {
        public string Id { get; set; }

        public string FlightNumber { get; set; }

        public ICollection<TicketListingViewModel> Tickets { get; set; }
    }
}