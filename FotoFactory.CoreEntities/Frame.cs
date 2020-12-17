using System;
using System.Collections.Generic;

namespace FotoFactory.CoreEntities
{
    public class Frame
    {
        public int FrameId { get; set; }
        public string FrameType { get; set; }
        public string FrameSku { get; set; }
        public IEnumerable<WorkSpacePoster> WorkSpacePosters { get; set; }
    }

}

