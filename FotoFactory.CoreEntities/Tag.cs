using System;
using System.Collections.Generic;

namespace FotoFactory.CoreEntities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Description { get; set; }
        public IEnumerable<PosterTag> PosterTags { get; set; }
    }
}
