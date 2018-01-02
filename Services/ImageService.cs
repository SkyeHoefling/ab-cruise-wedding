using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ABCruiseWedding.Models;
using ABCruiseWedding.Models.Vision;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Newtonsoft.Json;

namespace ABCruiseWedding.Services
{
    public class ImageService
    {
        public async Task<List<String>> GetCategories()
        {
            await Task.Delay(1);
            return new List<string> { "Wedding", "Engagement" };
        }

        public async Task<List<ImageModel>> GetImages(string container)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"https://abcruisewedding-functions.azurewebsites.net/api/HttpGetPhotos?code=Ed1WgMcqiI2Knik/0QmZ10vd93X5TK/SKFAdr1gSlPZVWQmfChbDsg==&container={container}");
            var response = await client.GetAsync("");

            if (response.Content != null)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<ImageModel>>(responseContent);
                return results;
            }

            return new List<ImageModel>();
        }
    }
}