using System;

namespace FotoFactory.CoreEntities
{
    public class PosterSize
    {
        public int PosterId { get; set; }
        public Poster Poster { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
    }
}
