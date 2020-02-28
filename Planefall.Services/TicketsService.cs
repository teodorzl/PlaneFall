namespace Planefall.Services
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Ticket;
    using Planefall.Models;

    public class TicketsService : BaseService, ITicketsService
    {
        public TicketsService(PlanefallDbContext context) : base(context)
        {
        }

        public async Task<bool> BookTicket(TicketBookingServiceModel model)
        {
            if (!this.IsEntityStateValid(model))
            {
                return false;
            }

            var flight = await this.Context.Flights.FindAsync(model.FlightId);

            int purchasedTickets = await this.Context.Tickets
                .CountAsync(t => t.FlightId == model.FlightId && t.TicketType == model.TicketType);

            int totalSeats;

            switch (model.TicketType)
            {
                case TicketType.Regular:
                    totalSeats = flight.RegularSeats;
                    break;
                case TicketType.Business:
                    totalSeats = flight.BusinessSeats;
                    break;
                default:
                    return false;
            }

            if (totalSeats <= purchasedTickets)
            {
                return false;
            }

            var ticket = Mapper.Map<Ticket>(model);

            await this.Context.AddAsync(ticket);

            await this.Context.SaveChangesAsync();

            return true;
        }
    }
}