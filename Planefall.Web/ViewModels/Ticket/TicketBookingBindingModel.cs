namespace Planefall.ViewModels.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Mapping.Interfaces;
    using Flight;
    using Models;
    using Services.Models.Ticket;

    public class TicketBookingBindingModel : IMapWith<TicketBookingServiceModel>
    {
        [NotMapped]
        public FlightBookingViewModel FlightInformation { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("\\d{10}")]
        [Display(Name = "ID number")]
        public string IdNumber { get; set; }

        [Required]
        [Phone]
        [StringLength(15, MinimumLength = 8)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression("[A-Z]{3}")]
        public string Citizenship { get; set; }

        [Required]
        [Display(Name = "Ticket type")]
        public TicketType TicketType { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}