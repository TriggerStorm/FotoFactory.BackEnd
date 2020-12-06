using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService.ValidatorInterface
{
   public interface IWorkSpacePosterValidator
    {

        void DefaultValidation(WorkSpacePoster workSpacePoster);
        void DeleteWorkSpacePoster(int id );
        void UpdateWorkSpacePoster(int id, int XPos, int YPos);
      
    }
}
