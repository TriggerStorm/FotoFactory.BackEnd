using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.DomainService
{
   public interface IWorkSpaceRepository
    {
        WorkSpace CreateWorkSpace(WorkSpace workSpace);
        WorkSpace ReadWorkSpaceByID(int id);
        IEnumerable<WorkSpace> ReadAllWorkSpace(int userID);
        WorkSpace UpdateWorkSpace(int id,WorkSpace workSpace);
        WorkSpace AddWorkSpacePoster(int workSpaceId, int workSpacePosterId);//add this workspaceposter to this workspace. shall we send just the wspId or the whole object.
        WorkSpace RemoveWorkSpacePoster(int workSpaceId, int posterID);// from this workspace remove this workspace poster
        WorkSpace DeleteWorkSpace(int id);
    }
}
