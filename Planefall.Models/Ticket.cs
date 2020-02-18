namespace Planefall.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

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
        public string IdNumber { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Citizenship { get; set; }
        
        [Required]
        public TicketType TicketType { get; set; }
    }
}