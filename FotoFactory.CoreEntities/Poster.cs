using System;
using System.Collections.Generic;

namespace FotoFactory.CoreEntities
{
    public class Poster
    {
        public int PosterId { get; set; }
        public string PosterName { get; set; }
        public string PosterSku { get; set; }
        public string Path { get; set; }
        public int CollectionId { get; set; }
        public  IEnumerable<PosterTag> PosterTags { get; set; }
        public IEnumerable<PosterSize> PosterSizes { get; set; }
        public IEnumerable<Favourite> Favourites { get; set; }

    }
}
