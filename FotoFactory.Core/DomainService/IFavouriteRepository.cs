using System;
using System.Collections.Generic;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.DomainService
{
    public interface IFavouriteRepository
    {
        IEnumerable<Poster> ReadLoggedInUsersFavouritedPosters();  // Logged in User id??
    }
}
