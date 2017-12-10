using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ABCruiseWedding.Models;
using ABCruiseWedding.Models.Vision;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Newtonsoft.Json;

namespace ABCruiseWedding.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var images = await GetImages();
            var data = images
                .Select(x => new ImageModel
                {
                    Uri = x,
                    Description = this.GetDescription(x).Result
                });

            var model = new IndexModel
            {
                Countdown = GetCountdown(),
                Images = data
            };

            return View(model);
        }

        private async Task<string> GetDescription(string imagePath)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "556351dbc36942b59fd8ce4d92aaaabc");
            var requestParameters = "visualFeatures=Description&details=Landmarks&language=en";
            var uri = $"https://eastus.api.cognitive.microsoft.com/vision/v1.0/analyze?{requestParameters}";
            
            var json = JsonConvert.SerializeObject(new { url = imagePath });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content);
            
            if(response.Content != null){
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AnalyzeImage>(responseContent);
                return result.Description.Captions.FirstOrDefault().Text;
            }

            return "";
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
