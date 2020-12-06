using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.DomainService
{
    public interface IWorkSpacePosterRepository
    {
        WorkSpacePoster CreateWorkSpacePoster(WorkSpacePoster workSpacePoster, int posterId, int frameId, int sizeId);

        IEnumerable<WorkSpacePoster> ReadAllWorkSpacePoster();
        WorkSpacePoster ReadWorkSpacePosterById(int id);
        WorkSpacePoster UpdateWorkSpacePoster(int id, int xPos, int yPos);
        WorkSpacePoster DeleteWorkSpacePoster(int id);
    }
}
