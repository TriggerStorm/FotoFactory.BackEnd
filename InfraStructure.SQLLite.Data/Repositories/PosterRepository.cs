using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.SQLLite.Data.Repositories
{
    public class PosterRepository: IPosterRepository
    {
        readonly FotoFactoryContext _ctx;

        public PosterRepository(FotoFactoryContext ctx)
        {
            _ctx = ctx;
        }


        public Poster ReadPosterById(int id)
        {
                       return _ctx.Posters.Include(p => p.PosterTags).Include(p => p.PosterSizes).FirstOrDefault(p => p.PosterId == id);
            //  return _ctx.Posters.Include(p => p.Tags).Include(p => p.Sizes);
            //return null;
        }


    }
}
