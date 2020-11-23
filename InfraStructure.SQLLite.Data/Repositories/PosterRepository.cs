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
            // this works... but no tags
            // return _ctx.Posters.Include(p => p.PosterTags).Include(p => p.PosterSizes).FirstOrDefault(p => p.PosterId == id);

            // v2 Hacky but works
            Poster p = _ctx.Posters.Include(p => p.PosterTags).Include(p => p.PosterSizes).FirstOrDefault(p => p.PosterId == id);
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
            return p;
        }
    }
}
