using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private object db;

        [MyLoggingFilter]
        [OutputCache(Duration = 1800)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Product p = null;// = db.Products.find(id);
            return View(p);
        }

        [HandleError(View="MyError", ExceptionType = typeof(StackOverflowException))]
        public ActionResult ErrorMethod()
        {
            throw new StackOverflowException("My Error");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having Trouble? Send us message ... !";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.TheMessage = "Thanks ! Got the Message !";

            return View();
        }

        public ActionResult Foo()
        {
            ViewBag.message = "My Foo page.";
            return View("About");
        }

        [Authorize(Roles = "administrator", Users = "jsmith")] // all admin & jsmith user
        [Authorize] // authorize all loggedin users
        [Route("home/MySerial")]
        public ActionResult MyMethod()
        {
            return Json(new { name = "MyMethod"});
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if(letterCase == "lower")
            {
                return Content(serial.ToLower());
            }

            return RedirectToAction("index");
            //return Json(new { name="serial", value = serial }, JsonRequestBehavior.AllowGet); 
            //return Content(serial);
        }
    }
}