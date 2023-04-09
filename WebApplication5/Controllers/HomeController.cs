using Microsoft.AspNetCore.Mvc;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        private ITourRepository _tourRepository;

        public HomeController(ILocationRepository locationRepository,ITourRepository tourRepository ) {
            _locationRepository = locationRepository;
            _tourRepository = tourRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
                var location = await _locationRepository.getAllLocationAsyn();
            ViewBag.location = location;
             var tour = await  _tourRepository.getAllTour();
            ViewBag.tour = tour;
            return View();
        }
    }
}
