using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ABCruiseWedding.Models.Vision;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Newtonsoft.Json;

namespace ABCruiseWedding.Services
{
    public class ImageService
    {
        public async Task<IEnumerable<string>> GetImages()
        {
            var credentials = new StorageCredentials("abcruisewedding", "zh2vjSS6xAUnfCtp1RYtQcgDENlNKmR9CQ7PTaG14A1l8Ei79ytSduEnaBdZs9VM3c8hv8IdAt09dg08mVfjLA==");
            var storageAccount = new CloudStorageAccount(credentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("photos");
            var blobs = await container.ListBlobsSegmentedAsync(null);
            return blobs.Results.Select(x => x.Uri.AbsoluteUri);
        }

        public async Task<string> GetDescription(string imagePath)
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
    }
}