using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FotoFactory.Core.AppService.ValidatorInterface;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService.Validators
{
    public class WorkSpacePosterValidator : IWorkSpacePosterValidator
    {
       

        public void DefaultValidation(WorkSpacePoster workSpacePoster)
        {
            if (workSpacePoster.XPos <= -1 || workSpacePoster.YPos <= -1) 
                throw new Exception($"position of x and y cannot be negative");
        }

       
        public void DeleteWorkSpacePoster(int id)
        {
            if (id <= 0)
            {
                throw new NoNullAllowedException($"id cant be null or negative");
            }
        }

        public void UpdateWorkSpacePoster(int id , int XPos , int YPos)
        {
            if (id <= 0)
            {
                throw new NoNullAllowedException($"id cant be null or negative");
            }
            if (XPos <= -1 && YPos <= -1)
                throw new NoNullAllowedException($"position of x and y cannot be negative");

        }

    }
}
