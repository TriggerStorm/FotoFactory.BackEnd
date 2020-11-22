using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.SQLLite.Data.Repositories
{
    public class CollectionRepository: ICollectionRepository
    {
        readonly FotoFactoryContext _ctx;
       
        public CollectionRepository(FotoFactoryContext ctx)
        {
            _ctx = ctx;
        }


        public IEnumerable<Poster> ReadAllCollectionPosters(int collectionId)
        {
            return _ctx.Posters.Where(p => p.Collection == collectionId).Include(p => p.PosterTags).Include(p => p.PosterSizes);
        }

    }
}
