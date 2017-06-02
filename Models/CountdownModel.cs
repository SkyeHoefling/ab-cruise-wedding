using System;
using Newtonsoft.Json;

namespace ABCruiseWedding.Models 
{
    [JsonObject]
    public class CountdownModel 
    {
        [JsonProperty]
        public int Days { get; set; }

        [JsonProperty]
        public int Hours { get; set; }

        [JsonProperty]
        public int Minutes { get; set; }

        [JsonProperty]
        public int Seconds { get; set; }
    }
}