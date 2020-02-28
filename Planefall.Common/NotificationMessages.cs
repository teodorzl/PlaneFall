namespace Planefall.Common
{
    public static class NotificationMessages
    {
        public const string FlightCreateSuccessMessage = "Flight created successfully";
        public const string FlightCreateErrorMessage = "An error occurred while creating flight";

        public const string TicketBookSuccessMessage = "Ticket booked. A confirmation email will be sent soon.";
        public const string TicketBookErrorMessage = "No seats of the selected type are available";


        public const string UserDeleteErrorMessage = "An error occured while deleting user";
        public const string UserDeleteSuccessMessage = "Successfully deleted user";
        public const string UserPromoteErrorMessage = "An error occured while promoting user";
        public const string UserPromoteSuccessMessage = "Successfully promoted user";
        public const string UserDemoteErrorMessage = "An error occured while demoting user";
        public const string UserDemoteSuccessMessage = "Successfully demoted user";
        public const string UserCreateSuccessMessage = "Successfully created user";
    }
}