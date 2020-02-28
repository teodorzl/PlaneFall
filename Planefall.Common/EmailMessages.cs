namespace Planefall.Common
{
    public static class EmailMessages
    {
        public const string ReservationConfirmationSubject = "Planefall Reservation Confirmation";

        public const string ReservationConfirmationBody = @"
Dear {0} {1},

Your reservation for flight {2} with Planefall has been confirmed. The details you have provided us with are as follows:

- First name: {0}
- Middle name: {3}
- Last name: {1}
- ID number: {4}
- Phone number: {5}
- Citizenship: {6}
- Ticket type: {7}

We hope you enjoy your safe flight with Planefall and look forward to working with you again.

Yours sincerely,
The Planefall team
";
    }
}