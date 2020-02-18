namespace Planefall.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Flight
    {
        public string Id { get; set; }
        
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string FromAirport { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string ToAirport { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string PlaneType { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string FlightNumber { get; set; }

        public int RegularSeats { get; set; }

        public int BusinessSeats { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}