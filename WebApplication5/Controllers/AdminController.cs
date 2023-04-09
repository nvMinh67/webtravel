using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using WebApplication5.EditModel;
using WebApplication5.Entity;
using WebApplication5.ViewModel;

namespace WebApplication5.Controllers
{
  
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly RoleManager<ApplicationUser> _roleManager;

        public AdminController(RoleManager<ApplicationUser> roleManager ,MyDbContext context,UserManager<ApplicationUser> userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment) {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var ListL = (from a in _context.DIADIEMs.AsNoTracking()
                         select new ListLocation()
                         {
                             DIACHI = a.DIACHI,
                             TENDIADIEM = a.TENDIADIEM,
                             MAP = a.MAP,
                             MOTA = a.MOTA,
                             Images = (from i in _context.image_DIADIEMs where i.id_DIADIEM == a.ID
                                       select i.Name).
                                       ToList(),
                         }).ToList();
            return View(ListL);
        }
        public IActionResult CreateDiaDiem()
        {
            var editview = new LocationModel();
            return View(editview);
        }
        [HttpPost]
        public IActionResult CreateDiaDiem ([FromForm]LocationModel model)
        {
            var diadiem = new DIADIEM()
            {
                TENDIADIEM = model.TENDIADIEM,
                MAP = model.MAP,
                MOTA = model.MOTA,
                DIACHI = model.DIACHI,
               
            };
            _context.DIADIEMs.Add(diadiem);
            _context.SaveChanges();
            var getCurrenDirectory = Directory.GetCurrentDirectory();
            foreach (var item in model.Images)
            {
                var path = Path.Combine(getCurrenDirectory,_hostingEnvironment.WebRootPath, item.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                  item.CopyTo(stream);
                }
                var image = new image_DIADIEM()
                {
                    id_DIADIEM = diadiem.ID,
                    Name = item.FileName,
                    dIADIEM = diadiem,
                };
                _context.image_DIADIEMs.Add(image);
            }
            _context.SaveChanges();

            return RedirectToAction("CreateDiaDiem") ;


        }
        [HttpGet]
        public ActionResult CreateTour()
        {
            var diadiem = (from d in _context.DIADIEMs.AsNoTracking() select d).ToList();
            ViewBag.diadiem = diadiem;
  
            var user1 = (from u in _userManager.Users.AsNoTracking() select u).ToList();
            ViewBag.user = user1;
            return View();
        }
        [HttpPost]
        public IActionResult CreateTour(TourModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model.ToString());
            }
            var day = model.endDate-model.startDate;

            var tour = new Tour()
            {
                Name = model.Title,
                Description = model.Description,
                startDate = model.startDate,
                endDate = model.endDate,
                id_user = model.id_user,
                Amount = model.Amount,
                num_day = day.Days,
                Price = model.Price,
            };
            _context.tours.Add(tour);
            _context.SaveChanges();
            foreach(var item in model.id_diadiem)
            {
                var diadiem = _context.DIADIEMs.Find(item);
                var detailtour = new DetailTour()
                {
                    Title = model.Title,
                    Description = model.Description,
                    id_diadiem = item,
                    DIADIEM  = diadiem,
                    id_tour =tour.Id,
                };
                _context.detailTours.Add(detailtour);
            }
            _context.SaveChanges();
            return RedirectToAction("CreateTour");
          
        }
        
    }
}
