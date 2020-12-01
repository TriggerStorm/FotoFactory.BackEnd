using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.SQLLite.Data.Repositories
{
    public class WorkSpaceRepository : IWorkSpaceRepository
    {
        private readonly FotoFactoryContext _ctx;

        public WorkSpaceRepository(FotoFactoryContext ctx)
        {
            _ctx = ctx;
        }
        public WorkSpace AddWorkSpacePoster(int workSpaceId, int workSpacePosterId)
        {
            var workSpace = ReadWorkSpaceByID(workSpaceId);
            var workSpacePoster = ReadWorkSpacePosterByID(workSpacePosterId);

            if (workSpace == null && workSpacePoster == null)
            {
                throw new NoNullAllowedException("Workspace or poster doesnt exist");
            }

            workSpace.WorkSpacePosters.Add(workSpacePoster);

            _ctx.Attach(workSpace).State = EntityState.Modified;
            _ctx.SaveChanges();

            return workSpace;

        }

        public WorkSpace CreateWorkSpace(WorkSpace workSpace)
        {
            _ctx.Attach(workSpace).State = EntityState.Added;
            _ctx.SaveChanges();
            return workSpace;
        }

        public WorkSpace DeleteWorkSpace(int id)
        {
            var WorkSpaceDeleted = ReadWorkSpaceByID(id);
            if (WorkSpaceDeleted != null)
            {
                _ctx.Attach(WorkSpaceDeleted).State = EntityState.Deleted;
                _ctx.SaveChanges();
                return WorkSpaceDeleted;
            }
            throw new ArgumentException($" workSpace not found");
        }

        public IEnumerable<WorkSpace> ReadAllWorkSpace(int userID)
        {
            return _ctx.WorkSpaces.Where(u => u.User.UserId == userID).Include(wsp => wsp.WorkSpacePosters).Include(wsp => wsp.User);
        }

        public WorkSpace ReadWorkSpaceByID(int id)// this is the workspace Id
        {
            return _ctx.WorkSpaces.AsNoTracking().Include(ws => ws.WorkSpacePosters).Include(wsp => wsp.User).FirstOrDefault(WorkSpace => WorkSpace.WorkSpaceId == id);
        }
        public WorkSpacePoster ReadWorkSpacePosterByID(int id)
        {
            return _ctx.WorkSpacePosters.AsNoTracking().FirstOrDefault(WorkSpace => WorkSpace.WorkSpacePosterId == id);
        }
        public WorkSpace RemoveWorkSpacePoster(int workSpaceId, int workSpacePosterID)
        {
            var workSpace = ReadWorkSpaceByID(workSpaceId);
            var workSpacePoster = ReadWorkSpacePosterByID(workSpacePosterID);

            if (workSpace == null && workSpacePoster == null)
            {
                throw new NoNullAllowedException("Workspace or poster doesn't exist");
            }

            workSpace.WorkSpacePosters.Remove(workSpacePoster);

            _ctx.Attach(workSpace).State = EntityState.Modified;
            _ctx.SaveChanges();

            return workSpace;
        }

        public WorkSpace UpdateWorkSpace(int id, WorkSpace modifyWorkSpace)
        {
            var workSpace = ReadWorkSpaceByID(id);

            if (workSpace == null)
            {
                throw new NoNullAllowedException($"Id is required to update workSpace");
            }

            workSpace.Name = modifyWorkSpace.Name;
            workSpace.BackGroundColour = modifyWorkSpace.BackGroundColour;

            _ctx.Attach(workSpace).State = EntityState.Modified;
            _ctx.SaveChanges();

            return workSpace;
        }
    }
}
