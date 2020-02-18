namespace Planefall.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class PlanefallUser : IdentityUser
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string IdNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }
    }
}