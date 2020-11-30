using System;

namespace FotoFactory.CoreEntities
{
    public class WorkSpacePoster
    {
        public int WorkSpacePosterId { get; set; }
        public Poster Poster { get; set; }// should be an id for relationship
        public Frame Frame { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Size Size { get; set; }// should be na id for relationship

    }

}

