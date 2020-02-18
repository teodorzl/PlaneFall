namespace Planefall.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.Models.Flight;
    using ViewModels.Flight;

    public class FlightsController : BaseController
    {
        private readonly IFlightsService flightsService;

        public FlightsController(IFlightsService flightsService)
        {
            this.flightsService = flightsService;
        }

        public async Task<IActionResult> Index()
        {
            var flights = (await this.flightsService.GetAllFlightsAsync())
                .Select(Mapper.Map<FlightListingViewModel>)
                .ToArray();

            return this.View(flights);
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