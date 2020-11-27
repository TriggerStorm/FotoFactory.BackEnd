using System;
using System.Collections.Generic;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface IFavouriteService
    {
        Favourite NewLoggedInUsersFavouritedPoster(int posterID);

        IEnumerable<Poster> FindLoggedInUsersFavouritedPosters();
    }
}
