using System;
using System.Collections.Generic;

namespace FotoFactory.CoreEntities
{
    public class Size
    {
        public int SizeId { get; set; }
        public string Dimensions { get; set; }
        public double PosterPrice { get; set; }
        public double FramePrice { get; set; }
        public IEnumerable<PosterSize> PosterSizes { get; set; }
    }
}

