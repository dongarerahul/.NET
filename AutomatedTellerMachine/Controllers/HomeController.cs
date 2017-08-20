using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [Authorize(Roles ="administrator", Users="jsmith")] // all admin & jsmith user
        [Authorize] // all loggedin users
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