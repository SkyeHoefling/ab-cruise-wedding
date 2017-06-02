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
            var model = new IndexModel
            {
                Countdown = GetCountdown()
            };

            return View(model);
        }

        public CountdownModel GetCountdown(){
            var weddingDate = new DateTime(2017,11,26,15,0,0);
            var currentDate = DateTime.Now;
            var difference = weddingDate.Subtract(currentDate);

            return new CountdownModel{
                Days = difference.Days,
                Hours = difference.Hours,
                Minutes = difference.Minutes,
                Seconds = difference.Seconds
            };
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
