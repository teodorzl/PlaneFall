namespace Planefall.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using ViewModels.Flight;

    public class FlightsController : Controller
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
    }
}