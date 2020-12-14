using FotoFactory.CoreEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;

namespace FotoFactory.Core.AppService.Validators
{
    public class WorkSpaceValidator : IWorkSpaceValidator
    {
        public void DefaultValidation(WorkSpace workSpace)
        {
            if (workSpace.Name == null)
                throw new NoNullAllowedException($"Name cannot be null");
            if (workSpace.Name.Length >= 200)
                throw new InvalidDataException($"name cannot be more than 200 characters");
            if(workSpace.Name.Length <= 5)
                throw new InvalidDataException($"name cannot be less than 5 characters");
            if (workSpace.BackGroundColour == null)
                throw new NullReferenceException($"BackGroundColour cannot be null");

        }

        public void DeleteWorkSpace(int id)
        {
            if(id == null || id<=0)
                throw new ArgumentNullException("id cannot be null or negative");
            
        }

        public void UpdateWorkSpace(int id, WorkSpace workSpace)
        {
            if(id == null || id <= 0)
                throw new NoNullAllowedException($"id cannot be null");
            if(String.IsNullOrEmpty(workSpace.Name))
                throw new NoNullAllowedException("name cannot have numbers or be empty");
            if (string.IsNullOrEmpty(workSpace.BackGroundColour))
                throw new NoNullAllowedException($"background colour cannot be null");
            
        }

        public void CheckWorkspaceIdValidity(int workSpaceId , int workSpacePosterId) //Used for adding and removing workspace posters
        // Only checks workspaceID and poster ID because we get objects from database using ID.
        {
            if (workSpaceId <= 0 || workSpacePosterId <= 0)
                throw new InvalidDataException("workSpaceId and WorkSpacePosterId cannot be less than 1");
            
        }

        public void AddWorkSpacePoster(int workSpaceId, int workSpacePosterId)
        {
            CheckWorkspaceIdValidity(workSpaceId,workSpacePosterId);
        }



    };



}
