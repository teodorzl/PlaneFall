namespace Planefall.ViewModels.Ticket
{
    using Common.Mapping.Interfaces;
    using Models;
    using Services.Models.Ticket;

    public class TicketListingViewModel : IMapWith<TicketListingServiceModel>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Citizenship { get; set; }

        public TicketType TicketType { get; set; }

        public string Email { get; set; }
    }
}