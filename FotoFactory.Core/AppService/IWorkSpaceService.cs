using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface IWorkSpaceService
    {
        WorkSpace CreateWorkSpace(string name, string backgroundColour, int userID);//ask neds can we not just pass the object in param
        WorkSpace ReadWorkSpaceByID(int id);
        List<WorkSpace> ReadAllWorkSpace(int userId);
        WorkSpace UpdateWorkSpace(int id, WorkSpace workSpace);
        WorkSpace AddWorkSpacePoster(int workSpaceId, int workSpacePosterId);//add this workspaceposter to this workspace. shall we send just the wspId or the whole object..
        WorkSpace RemoveWorkSpacePoster(int workSpaceId, int posterID);// from this workspace remove this workspace poster
        WorkSpace DeleteWorkSpace(int id);
    }
}
