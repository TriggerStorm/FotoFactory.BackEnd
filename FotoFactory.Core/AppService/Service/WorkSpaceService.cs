using FotoFactory.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;

namespace FotoFactory.Core.AppService.Service
{
    public class WorkSpaceService : IWorkSpaceService
    {
        private readonly IWorkSpaceRepository _workSpaceRepository;
        private readonly IWorkSpaceValidator _workSpaceValidator;
        private readonly IAuthenticationHelper _authenticationHelper;

        public WorkSpaceService(IWorkSpaceRepository workSpaceRepository , IWorkSpaceValidator workSpaceValidator, IAuthenticationHelper authenticationHelper)
        {
            _workSpaceRepository = workSpaceRepository;
            _workSpaceValidator = workSpaceValidator;
            _authenticationHelper = authenticationHelper;
        }
        public WorkSpace AddWorkSpacePoster(int workSpaceId, int workSpacePosterId)// need object.
        {
            _workSpaceValidator.CheckWorkspaceIdValidity(workSpaceId, workSpacePosterId);
            return _workSpaceRepository.AddWorkSpacePoster(workSpaceId, workSpacePosterId);
        }

        public WorkSpace CreateWorkSpace(string name, string backgroundColour)
        {
            WorkSpace workSpace = new WorkSpace()
            {
                Name = name,
                BackGroundColour = backgroundColour
            };
            _workSpaceValidator.DefaultValidation(workSpace);
            return _workSpaceRepository.CreateWorkSpace(workSpace);
        }

        public WorkSpace DeleteWorkSpace(int id)
        {

            _workSpaceValidator.DeleteWorkSpace(id);
            return _workSpaceRepository.DeleteWorkSpace(id);
        }

        public List<WorkSpace> ReadAllWorkSpace(int userId)
        {
            return _workSpaceRepository.ReadAllWorkSpace(userId).ToList();
        }

        public WorkSpace ReadWorkSpaceByID(int id)
        {
            return _workSpaceRepository.ReadWorkSpaceByID(id);
        }

        public WorkSpace RemoveWorkSpacePoster(int workSpaceId, int workSpacePosterID)
        {
            _workSpaceValidator.CheckWorkspaceIdValidity(workSpaceId, workSpacePosterID);
            return _workSpaceRepository.RemoveWorkSpacePoster(workSpaceId, workSpacePosterID);
        }

        public WorkSpace UpdateWorkSpace(int id, WorkSpace workSpace)
        {
            _workSpaceValidator.UpdateWorkSpace(id,workSpace);
            return _workSpaceRepository.UpdateWorkSpace(id, workSpace);
        }

    }
}
