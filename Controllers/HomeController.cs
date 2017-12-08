using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCruiseWedding.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace ABCruiseWedding.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new IndexModel
            {
                Countdown = GetCountdown(),
                Images = await GetImages()
            };

            return View(model);
        }

        private async Task<IEnumerable<string>> GetImages()
        {
            var credentials = new StorageCredentials("abcruisewedding", "zh2vjSS6xAUnfCtp1RYtQcgDENlNKmR9CQ7PTaG14A1l8Ei79ytSduEnaBdZs9VM3c8hv8IdAt09dg08mVfjLA==");
            var storageAccount = new CloudStorageAccount(credentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("photos");
            var blobs = await container.ListBlobsSegmentedAsync(null);
            return blobs.Results.Select(x => x.Uri.AbsoluteUri);
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
