﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FotoFactory.CoreEntities
{
    public class Poster
    {
        public int PosterId { get; set; }

        public string PosterName { get; set; }

        public string PosterSku { get; set; }

        public string Path { get; set; }

        public int TagId { get; set; }
        public List<Tag> Tags { get; set; }

        public int SizeId { get; set; }
        public List<Size> Sizes { get; set; }
    }
}