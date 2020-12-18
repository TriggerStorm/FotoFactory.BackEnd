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


        public List<Poster> ReadAllCollectionPosters(int collectionId)
        {
            // this works... but no tags
            List<Poster> list = _ctx.Posters.Where(p => p.CollectionId == collectionId)
                .Include(p => p.PosterTags)
                .Include(p => p.PosterSizes)
                .ToList();
            return list;
            // v2 Hacky but works
            /*IEnumerable<Poster> pl = _ctx.Posters.Where(p => p.CollectionId == collectionId).Include(p => p.PosterTags).Include(p => p.PosterSizes);
            foreach (Poster p in pl)
            {
                IEnumerable<PosterTag> ptlist = p.PosterTags;
                foreach (PosterTag pt in ptlist)
                {
                    Tag tag = _ctx.Tags.Where(pts => pts.TagId == pt.TagId).FirstOrDefault();
                    pt.Tag.TagId = tag.TagId;
                    pt.Tag.Description = tag.Description;
                    pt.Tag.PosterTags = null;
                }

                IEnumerable<PosterSize> pslist = p.PosterSizes;
                foreach (PosterSize ps in pslist)
                {
                    Size size = _ctx.Sizes.Where(pss => pss.SizeId == ps.SizeId).FirstOrDefault();
                    ps.Size.SizeId = size.SizeId;
                    ps.Size.Dimensions = size.Dimensions;
                    ps.Size.PosterPrice = size.PosterPrice;
                    ps.Size.FramePrice = size.FramePrice;
                    ps.Size.PosterSizes = null;
                }
            }
            return pl.ToList();*/
        }
    }
}
