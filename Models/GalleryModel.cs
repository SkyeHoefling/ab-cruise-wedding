using System.Collections.Generic;

namespace ABCruiseWedding.Models
{
    public class GalleryModel
    {
        public IDictionary<string, IEnumerable<ImageModel>> Images { get; set;}
    }
}