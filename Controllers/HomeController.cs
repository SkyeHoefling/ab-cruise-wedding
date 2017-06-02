using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ab_cruise_wedding.Models;
using Microsoft.AspNetCore.Mvc;

namespace ab_cruise_wedding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var weddingDate = new DateTime(2017,11,26,15,0,0);
            var currentDate = DateTime.Now;
            var difference = weddingDate.Subtract(currentDate);            
            
            var model = new IndexModel
            {
                Countdown = difference
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
