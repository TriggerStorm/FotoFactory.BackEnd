using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface IWorkSpacePosterService
    {
        WorkSpacePoster CreateWorkSpacePoster(int xpos, int ypos, int posterId,int frameId, int sizeId);

        List<WorkSpacePoster> ReadAllWorkSpacePoster();
        WorkSpacePoster ReadWorkSpacePosterById(int id);
        WorkSpacePoster UpdateWorkSpacePoster(int id, int xPos, int yPos);
        WorkSpacePoster DeleteWorkSpacePoster(int id);
    }
}
