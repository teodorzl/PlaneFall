namespace Planefall.ViewModels.User
{
    using Common.Mapping.Interfaces;
    using Models;

    public class UserListingViewModel : IMapWith<PlanefallUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string IdNumber { get; set; }

        public string Address { get; set; }

        public bool IsAdmin { get; set; }
    }
}