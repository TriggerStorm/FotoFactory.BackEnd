using System;
using System.Collections.Generic;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.DomainService
{
    public interface IFavouriteRepository
    {
        Favourite CreateNewLoggedInUsersFavouritedPoster(int posterID);

        IEnumerable<Poster> ReadLoggedInUsersFavouritedPosters();  // Logged in User id??

        Favourite DeleteALoggedInUsersFavouritedPoster(int posterID);
    }
}
