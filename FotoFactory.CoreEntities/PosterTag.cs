
    using System;
namespace FotoFactory.CoreEntities
{
    public class PosterTag
    {
        public int PosterId { get; set; }
        public Poster Poster { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

}
