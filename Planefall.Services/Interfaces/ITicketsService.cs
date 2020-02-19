namespace Planefall.Services.Interfaces
{
    using System.Threading.Tasks;
    using Models.Ticket;

    public interface ITicketsService
    {
        Task<bool> BookTicket(TicketBookingServiceModel model);
    }
}