using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface IWorkSpaceValidator
    {
        void DefaultValidation(WorkSpace workSpace);
        void DeleteWorkSpace(int id); 
        void UpdateWorkSpace(int id, WorkSpace workSpace);
        void CheckWorkspaceIdValidity(int workSpaceId, int workSpacePosterId);
    }
}
