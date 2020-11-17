using System;
using System.Collections.Generic;
using FotoFactory.Core.AppService;
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



        public IEnumerable<Poster> ReadAllPosters()
        {
            return _ctx.Posters./*AsNoTracking().*/Include(p => p.Tags).Include(p => p.Sizes);
        }


    }
}
