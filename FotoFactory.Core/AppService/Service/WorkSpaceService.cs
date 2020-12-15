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
        private readonly IUserRepository _userRepository;
        private readonly IWorkSpaceValidator _workSpaceValidator;
        private readonly IAuthenticationHelper _authenticationHelper;

        public WorkSpaceService(IWorkSpaceRepository workSpaceRepository , IWorkSpaceValidator workSpaceValidator, IUserRepository userRepository, IAuthenticationHelper authenticationHelper)
        {

            _workSpaceRepository = workSpaceRepository ?? throw new NullReferenceException("Repo cannot be null"); 
            _workSpaceValidator = workSpaceValidator ?? throw new NullReferenceException("Validator cannot be null"); 
            _authenticationHelper = authenticationHelper ?? throw new NullReferenceException("AuthenticationHelper cannot be null"); ;

            _userRepository = userRepository;

        }
        public WorkSpace AddWorkSpacePoster(int workSpaceId, int workSpacePosterId)// need object.
        {
            _workSpaceValidator.CheckWorkspaceIdValidity(workSpaceId, workSpacePosterId);
            return _workSpaceRepository.AddWorkSpacePoster(workSpaceId, workSpacePosterId);
        }

        public WorkSpace CreateWorkSpace(string name, string backgroundColour, int userID)
        {
            WorkSpace workSpace = new WorkSpace()
            {
                Name = name,
                BackGroundColour = backgroundColour,
                User = _userRepository.ReadById(userID)

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
