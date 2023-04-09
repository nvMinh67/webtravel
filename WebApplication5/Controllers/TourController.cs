using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebApplication5.EditModel;
using WebApplication5.Entity;
using WebApplication5.Migrations;
using WebApplication5.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication5.Controllers
{
    public class TourController : Controller
    {

        private readonly ITourRepository _tourRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly ICompositeViewEngine _viewEngine;

        public TourController(ITourRepository tourRepository, IBookingRepository bookingRepository, ICompositeViewEngine viewEngine)
        {

            _tourRepository = tourRepository;
            _bookingRepository = bookingRepository;
            _viewEngine = viewEngine;
        }
        public async Task<IActionResult> Index()
        {
            var tours = await _tourRepository.getAllTour();
            ViewBag.tours = tours;
            return View();
        }
        [HttpGet("id")]
        public async Task<IActionResult> DetailTour(int id)
        {
            var tour = await _tourRepository.getTour(id);
            ViewBag.tour1 = tour;
            return View();

        }
        [HttpPost]
        public async Task<JsonResult> calcPrice(int id, int value)
        {
            var tour = await _tourRepository.getTour(id);
            var price = tour.Price;
            var totalPrice = price * value;

            return Json(new { totalPrice = totalPrice });
        }
        [HttpPost]
        public async Task<IActionResult> booking(BookingEM model)
        {
            ViewBag.model = model;
            var tour = await _tourRepository.getTour(model.id_tour);
            ViewBag.tour = tour;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> checkout(ContactDetailEM model)
        {
            ViewBag.model = model;
            var tour = await _tourRepository.getTour(model.id_tour);
            ViewBag.tour = tour;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Payment(CheckOutEM model)
        {

            await _bookingRepository.createBooking(model);
            return Redirect("/");
        }
        [HttpPost]
        public async Task<ActionResult> filterPrice(int price)
        {
            var tour = await  _tourRepository.filterPrice(price);
            PartialViewResult partialViewResult =  PartialView("_Phone",tour);
            string viewContent = ConvertViewToString(this.ControllerContext, partialViewResult, _viewEngine);
            return Json(new { PartialView = viewContent });
        }
        public string ConvertViewToString(ControllerContext controllerContext, PartialViewResult pvr, ICompositeViewEngine _viewEngine)
        {
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = _viewEngine.FindView(controllerContext, pvr.ViewName, false);
                ViewContext viewContext = new ViewContext(controllerContext, vResult.View, pvr.ViewData, pvr.TempData, writer, new HtmlHelperOptions());

                vResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
