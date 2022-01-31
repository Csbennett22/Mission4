using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DateMe.Controllers
{
    public class HomeController : Controller
    {

        private DateApplicationContext DateAppContext { get; set; }

        public HomeController(DateApplicationContext someName)
        {
            DateAppContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FillOutApplication ()
        {
            ViewBag.Majors = DateAppContext.Majors.ToList();
            return View("DatingApp");
        }
        [HttpPost]
        public IActionResult FillOutApplication (ApplicationResponse ar)
        {
            DateAppContext.Add(ar);
            DateAppContext.SaveChanges();
            return View("Confirmation", ar); // pass in the bundled up ar
        }
        [HttpGet]
        public IActionResult Waitlist()
        {
            var applications = DateAppContext.Responses
                .Include(x => x.Major) // also include the major object
                .Where(x => x.Stalker == false) //c# uses double = sign
                .OrderBy(x => x.LastName) // filtering the responses that are returned to the website
                .ToList();
            return View(applications);
        }

    }
}
