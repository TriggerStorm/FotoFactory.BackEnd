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
        public int Collection { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Size> Sizes { get; set; }
    }
}
