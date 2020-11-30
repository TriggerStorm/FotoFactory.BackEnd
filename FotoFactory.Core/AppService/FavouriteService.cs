﻿using System;
using System.Collections.Generic;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public class FavouriteService: IFavouriteService
    {
        readonly IFavouriteRepository _favouriteRepo;


        public FavouriteService(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepo = favouriteRepository;
        }


        public IEnumerable<Poster> FindLoggedInUsersFavouritedPosters()
        {
            return _favouriteRepo.ReadLoggedInUsersFavouritedPosters();
        }

    }
}
