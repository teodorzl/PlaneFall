namespace Planefall.Services.Models.Ticket
{
    using Common.Mapping.Interfaces;
    using Planefall.Models;

    public class TicketListingServiceModel : IMapWith<Ticket>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Citizenship { get; set; }
        
        public TicketType TicketType { get; set; }
    }
}