namespace Planefall.ViewModels.Flight
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Mapping.Interfaces;
    using Models;
    using Services.Models.Flight;

    public class FlightCreateBindingModel : IMapWith<FlightCreateServiceModel>, IValidatableObject
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [Display(Name = "Departure airport")]
        [RegularExpression("[A-Z]{3}")]
        public string FromAirport { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [Display(Name = "Arrival airport")]
        [RegularExpression("[A-Z]{3}")]
        public string ToAirport { get; set; }

        [Required]
        [Display(Name = "Departure time")]
        public DateTime DepartureTime { get; set; }

        [Required]
        [Display(Name = "Arrival time")]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Plane type")]
        public string PlaneType { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Flight number")]
        public string FlightNumber { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 3)]
        [Display(Name = "Pilot name")]
        public string PilotName { get; set; }

        [Required]
        [Display(Name = "Number of regular seats")]
        public int RegularSeats { get; set; }

        [Required]
        [Display(Name = "Number of business seats")]
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