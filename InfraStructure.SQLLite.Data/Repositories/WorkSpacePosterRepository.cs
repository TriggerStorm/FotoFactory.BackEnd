using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace InfraStructure.SQLLite.Data.Repositories
{
    public class WorkSpacePosterRepository : IWorkSpacePosterRepository
    {
        private readonly FotoFactoryContext _ctx;

        public WorkSpacePosterRepository(FotoFactoryContext ctx)
        {
            _ctx = ctx;
        }
        public WorkSpacePoster CreateWorkSpacePoster(WorkSpacePoster workSpacePoster , int posterId,int frameId ,int sizeId)
        {
            var poster = _ctx.Posters.AsNoTracking().FirstOrDefault(wsp => wsp.PosterId == posterId);
            var size = _ctx.Sizes.AsNoTracking().FirstOrDefault(wsp => wsp.SizeId == sizeId);
            var frame = _ctx.Frames.AsNoTracking().FirstOrDefault(wsp => wsp.FrameId == frameId);

            workSpacePoster.Frame = frame;
            workSpacePoster.Poster = poster;
            workSpacePoster.Size = size;

            _ctx.Attach(workSpacePoster).State = EntityState.Added;
            _ctx.SaveChanges();
            return workSpacePoster;
        }

        public WorkSpacePoster DeleteWorkSpacePoster(int id)
        {
            var WorkSpacePosterDeleted = ReadWorkSpacePosterById(id);
            if (WorkSpacePosterDeleted != null)
            {
                _ctx.Attach(WorkSpacePosterDeleted).State = EntityState.Deleted;
                _ctx.SaveChanges();
                return WorkSpacePosterDeleted;
            }
            throw new ArgumentException($" workSpace not found");
        }


        public IEnumerable<WorkSpacePoster> ReadAllWorkSpacePoster()
        {
            return _ctx.WorkSpacePosters.Include(p => p.Poster).Include(f => f.Frame).Include(s => s.Size).ToList();
        }

        public WorkSpacePoster ReadWorkSpacePosterById(int id)
        {
            return _ctx.WorkSpacePosters.AsNoTracking().Include(p => p.Poster).Include(f => f.Frame).Include(s => s.Size).FirstOrDefault(wsp => wsp.WorkSpacePosterId == id);
        }

        public WorkSpacePoster UpdateWorkSpacePoster(int id, int xPos, int yPos)
            {
                var workSpacePoster = ReadWorkSpacePosterById(id);

                if (workSpacePoster == null)
                {
                    throw new NoNullAllowedException($"Id is required to update workSpace");
                }

                workSpacePoster.XPos = xPos;
                workSpacePoster.YPos = yPos;
                _ctx.Attach(workSpacePoster).State = EntityState.Modified;
                _ctx.SaveChanges();

                return workSpacePoster;
        }
        
    }
}

