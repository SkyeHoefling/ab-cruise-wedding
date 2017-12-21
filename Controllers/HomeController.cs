﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCruiseWedding.Models;
using ABCruiseWedding.Services;
using Microsoft.AspNetCore.Mvc;

namespace ABCruiseWedding.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var imageService = new ImageService();

            var engagementImages = (await imageService.GetImages("engagement-sm"))
                .Select(async x => new ImageModel
                {
                    Uri = x,
                    Description = await imageService.GetDescription(x)
                })
                .Select(t => t.Result);

            var weddingImages = (await imageService.GetImages("photos-sm"))
                .Select(async x => new ImageModel
                {
                    Uri = x,
                    Description = await imageService.GetDescription(x)
                })
                .Select(t => t.Result);

            var model = new IndexModel
            {
                Countdown = GetCountdown(),
                EngagementImages = engagementImages,
                WeddingImages = weddingImages
            };

            return View(model);          
        }

        public CountdownModel GetCountdown(){
            var weddingDate = new DateTime(2018,5,13,12,0,0);
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
