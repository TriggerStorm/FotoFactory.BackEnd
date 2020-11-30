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
                throw new NoNullAllowedException($" Name cannot be empty");
            if (workSpace.Name.Length >= 200 || workSpace.Name.Length <= 5)
                throw new InvalidDataException($" name cannot be less than 5 or more than 200 characters");
            if (workSpace.BackGroundColour == null)
                throw new NullReferenceException($"Workspace needs a colour");

        }

        public void DeleteWorkSpace(int id)
        {
            if(id == null || id<=0)
                throw new ArgumentNullException("provide a valid id to delete");
            
        }

        public void UpdateWorkSpace(int id, WorkSpace workSpace)
        {
            if(id == null || id <= 0)
                throw new NoNullAllowedException($"id cannot be null");
            if(String.IsNullOrEmpty(workSpace.Name))// need to write integer here
                throw new NoNullAllowedException("name cannot have numbers or be empty");
        }

        public void CheckWorkspaceIdValidity(int workSpaceId , int workSpacePosterId) //Used for adding and removing workspace posters
        // Only checks workspaceID and poster ID because we get objects from database using ID.
        {
            if (workSpaceId <= 0 || workSpacePosterId <= 0)
                throw new ArgumentNullException("provide a valid id to add");
            /* if(workSpacePoster.WorkSpaceId == null || workSpacePoster.WorkSpaceId <=0)
                 throw new NoNullAllowedException();
             if(workSpacePoster.Frame.FrameType == null )
                 throw new NoNullAllowedException($"each frame has a type");
             if(workSpacePoster.Frame.FrameSku == null)
                 throw new NoNullAllowedException($"every frame has a skuId");
             if(workSpacePoster.Poster.PosterId == null || workSpacePoster.Poster.PosterId <=0)
                 throw new NoNullAllowedException($"foreign key constraint as poster Id cannot be null or in negative");
             if(workSpacePoster.Size.SizeId == null || workSpacePoster.Size.SizeId <=0)
                 throw new NoNullAllowedException($"foreign key constraint");
             if(workSpacePoster.XPos <= -1 && workSpacePoster.YPos <= -1)
                 throw new Exception($" post of x and y cannot be null");*/
        }

        public void AddWorkSpacePoster(int workSpaceId, int workSpacePosterId)
        {
            CheckWorkspaceIdValidity(workSpaceId,workSpacePosterId);
        }



    };



}
