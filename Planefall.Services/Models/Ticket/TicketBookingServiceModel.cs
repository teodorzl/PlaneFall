namespace Planefall.Services.Models.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping.Interfaces;
    using Planefall.Models;

    public class TicketBookingServiceModel : IMapWith<Ticket>
    {
        [Required]
        public string FlightId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("\\d{10}")]
        public string IdNumber { get; set; }

        [Required]
        [Phone]
        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression("[A-Z]{3}")]
        public string Citizenship { get; set; }

        [Required]
        public TicketType TicketType { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}