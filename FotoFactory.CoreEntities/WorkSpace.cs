using System;
using System.Collections.Generic;

namespace FotoFactory.CoreEntities
{
    public class WorkSpace
    {
        public int WorkSpaceId { get; set; } 
        public string Name { get; set; }
        public string BackGroundColour { get; set; }
        public List<WorkSpacePoster> WorkSpacePosters { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }


    }
}

