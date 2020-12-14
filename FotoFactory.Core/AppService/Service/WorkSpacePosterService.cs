using FotoFactory.CoreEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FotoFactory.Core.AppService.ValidatorInterface;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;

namespace FotoFactory.Core.AppService.Service
{
    public class WorkSpacePosterService : IWorkSpacePosterService
    {
        private readonly IWorkSpacePosterRepository _workSpacePosterRepository;
        private readonly IWorkSpacePosterValidator _workSpacePosterValidator;
        private readonly IAuthenticationHelper _authenticationHelper;

        public WorkSpacePosterService(IWorkSpacePosterRepository workSpacePosterRepository, IWorkSpacePosterValidator workSpacePosterValidator, IAuthenticationHelper authenticationHelper)
        {
            _workSpacePosterRepository = workSpacePosterRepository ?? throw new NullReferenceException($"Repo cannot be null");
            _workSpacePosterValidator = workSpacePosterValidator ?? throw new NullReferenceException($"validator cannot be null");
            _authenticationHelper = authenticationHelper ?? throw new NullReferenceException($"authentication helper cannot be null");
        }
        public WorkSpacePoster CreateWorkSpacePoster(int xpos, int ypos, int posterId, int frameId, int sizeId)
        {
            WorkSpacePoster workSpacePoster = new WorkSpacePoster()
            {
                XPos = xpos,
                YPos = ypos
            };
            _workSpacePosterValidator.DefaultValidation(workSpacePoster);
            return _workSpacePosterRepository.CreateWorkSpacePoster(workSpacePoster, posterId, frameId ,sizeId);
        }

        public WorkSpacePoster DeleteWorkSpacePoster(int id)
        {
            _workSpacePosterValidator.DeleteWorkSpacePoster(id);
            return _workSpacePosterRepository.DeleteWorkSpacePoster(id);
        }

        public ICollection<WorkSpacePoster> ReadAllWorkSpacePoster()
        {
           return _workSpacePosterRepository.ReadAllWorkSpacePoster().ToList();
        }

        public WorkSpacePoster ReadWorkSpacePosterById(int id)
        {
            return _workSpacePosterRepository.ReadWorkSpacePosterById(id);
        }

        public WorkSpacePoster UpdateWorkSpacePoster(int id , int xPos, int yPos)
        {
            _workSpacePosterValidator.UpdateWorkSpacePoster(id , xPos , yPos);
            return _workSpacePosterRepository.UpdateWorkSpacePoster(id , xPos, yPos);
        }
    }

}