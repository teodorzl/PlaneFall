namespace Planefall.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.Models.Flight;
    using Services.Models.Ticket;
    using ViewModels.Flight;
    using ViewModels.Ticket;

    public class FlightsController : BaseController
    {
        private readonly IFlightsService flightsService;
        private readonly ITicketsService ticketsService;

        public FlightsController(IFlightsService flightsService, ITicketsService ticketsService)
        {
            this.flightsService = flightsService;
            this.ticketsService = ticketsService;
        }

        public async Task<IActionResult> Index()
        {
            var flights = (await this.flightsService.GetAllFlightsAsync())
                .Select(Mapper.Map<FlightListingViewModel>)
                .ToArray();


            // only show future flights to non-authenticated users

            if (!this.User.Identity.IsAuthenticated)
            {
                flights = flights
                    .Where(f => f.DepartureTime > DateTime.UtcNow)
                    .ToArray();
            }

            return this.View(flights);
        }

        public async Task<IActionResult> Book(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var flightBookingServiceModel = await this.flightsService.GetBasicFlightInformationAsync(id);

            if (flightBookingServiceModel == null)
            {
                return this.NotFound();
            }

            var flightDetailsViewModel = Mapper.Map<FlightBookingViewModel>(flightBookingServiceModel);

            var ticketBookingBindingModel = new TicketBookingBindingModel {FlightInformation = flightDetailsViewModel};

            return this.View(ticketBookingBindingModel);
        }

        [HttpPost]
        public async Task<IActionResult> Book(string id, TicketBookingBindingModel bindingModel)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                var flightBookingServiceModel = await this.flightsService.GetBasicFlightInformationAsync(id);

                if (flightBookingServiceModel == null)
                {
                    return this.NotFound();
                }

                var flightDetailsViewModel = Mapper.Map<FlightBookingViewModel>(flightBookingServiceModel);

                bindingModel.FlightInformation = flightDetailsViewModel;

                return this.View(bindingModel);
            }

            var serviceModel = Mapper.Map<TicketBookingServiceModel>(bindingModel);

            serviceModel.FlightId = id;

            var success = await this.ticketsService.BookTicket(serviceModel);

            if (!success)
            {
                var flightBookingServiceModel = await this.flightsService.GetBasicFlightInformationAsync(id);

                if (flightBookingServiceModel == null)
                {
                    return this.NotFound();
                }

                var flightDetailsViewModel = Mapper.Map<FlightBookingViewModel>(flightBookingServiceModel);

                bindingModel.FlightInformation = flightDetailsViewModel;

                this.ShowErrorMessage(NotificationMessages.TicketBookErrorMessage);

                return this.View(bindingModel);
            }

            this.ShowSuccessMessage(NotificationMessages.TicketBookSuccessMessage);

            return this.RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var serviceFlight = await this.flightsService.GetDetailsAsync(id);

            if (serviceFlight == null)
            {
                return this.NotFound();
            }

            var flightDetailsViewModel = Mapper.Map<FlightDetailsViewModel>(serviceFlight);

            return this.View(flightDetailsViewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(FlightCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var serviceModel = Mapper.Map<FlightCreateServiceModel>(model);

            var success = await this.flightsService.CreateAsync(serviceModel);

            if (!success)
            {
                this.ShowErrorMessage(NotificationMessages.FlightCreateErrorMessage);

                return this.View(model);
            }

            this.ShowSuccessMessage(NotificationMessages.FlightCreateSuccessMessage);

            return this.RedirectToAction("Index");
        }
    }
}