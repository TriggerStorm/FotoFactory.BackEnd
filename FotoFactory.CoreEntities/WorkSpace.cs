using System;
using System.Collections.Generic;

namespace FotoFactory.CoreEntities
{
    public class WorkSpace
    {
        public int WorkSpaceId { get; set; }
        public string Name { get; set; }
        public int WorkSpacePosterId { get; set; }
        public List<WorkSpacePoster> WorkSpacePosters { get; set; }
    }
}

