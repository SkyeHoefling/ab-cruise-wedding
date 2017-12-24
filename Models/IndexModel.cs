using System;
using System.Collections.Generic;

namespace ABCruiseWedding.Models 
{
    public class IndexModel : IGalleryModel
    {
        public CountdownModel Countdown { get; set; }
        public IEnumerable<ImageModel> EngagementImages { get; set; }
        public IEnumerable<ImageModel> WeddingImages { get; set; }
        public IEnumerable<string> GalleryCategories { get; set; }
    }

    public interface IGalleryModel
    {
        IEnumerable<string> GalleryCategories { get; }
    }
}