namespace Planefall.Services.Models.Flight
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping.Interfaces;
    using Planefall.Models;

    public class FlightCreateServiceModel : IMapWith<Flight>, IValidatableObject
    {
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

        [Required]
        [StringLength(35, MinimumLength = 3)]
        public string PilotName { get; set; }

        public int RegularSeats { get; set; }

        public int BusinessSeats { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.DepartureTime > this.ArrivalTime)
            {
                yield return new ValidationResult("The departure time must be before the arrival time",
                    new[] {nameof(this.DepartureTime)});
            }
        }
    }
}