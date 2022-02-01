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
            if(ModelState.IsValid)
            { 
                DateAppContext.Add(ar);
                DateAppContext.SaveChanges();
                return View("Confirmation", ar); // pass in the bundled up ar
            }
            else
            {
                ViewBag.Majors = DateAppContext.Majors.ToList();

                return View("DatingApp");
            }
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
        [HttpGet]
        public IActionResult Edit(int applicationid) // this name has to match what the view has for asp-route- ________
        {
            ViewBag.Majors = DateAppContext.Majors.ToList();
            
            var application = DateAppContext.Responses.Single(x => x.ApplicationId == applicationid); // find the single record where the app id is the same as one of the ones in the database
            
            return View("DatingApp", application);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            DateAppContext.Update(ar);
            DateAppContext.SaveChanges();
            
            return RedirectToAction("Waitlist"); // makes it so we don't have to load up all of the same information for that action
        }
        [HttpGet]
        public IActionResult Delete(int applicationid)
        {

            var application = DateAppContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            DateAppContext.Responses.Remove(ar);
            DateAppContext.SaveChanges();
            return RedirectToAction("Waitlist");
        }
    }
}
