using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.SQLLite.Data.Repositories
{
    public class FavouriteRepository: IFavouriteRepository
    {
        readonly FotoFactoryContext _ctx;
        readonly int loggedInUserId = 1;  // MOCK DATA until singleton is implemented

        public FavouriteRepository(FotoFactoryContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Poster> ReadLoggedInUsersFavouritedPosters()
        {
            List<Poster> ufp = new List<Poster>();

            IEnumerable<Favourite> uf = _ctx.Favourites.Where(u => u.UserId == loggedInUserId);
            foreach (Favourite f in uf)
            {
                Poster p = _ctx.Posters.Include(p => p.PosterTags).Include(p => p.PosterSizes).FirstOrDefault(p => p.PosterId == f.PosterId);
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
                ufp.Add(p);
            }
            return ufp;
        }
    }
}
