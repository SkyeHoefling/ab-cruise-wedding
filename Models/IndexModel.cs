using System;
using System.Collections.Generic;

namespace ABCruiseWedding.Models 
{
    public class IndexModel 
    {
        public CountdownModel Countdown { get; set; }
        public IEnumerable<ImageModel> EngagementImages { get; set; }
        public IEnumerable<ImageModel> WeddingImages { get; set; }
    }
}