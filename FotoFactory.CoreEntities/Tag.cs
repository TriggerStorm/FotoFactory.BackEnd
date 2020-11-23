using System;
using System.Collections.Generic;

namespace FotoFactory.CoreEntities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Description { get; set; }
        // public List<Poster> TaggedPosters { get; set; }
        public IList<PosterTag> PosterTags { get; set; }
    }

}
