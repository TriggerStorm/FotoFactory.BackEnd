using System;
using System.Collections.Generic;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService.Service
{
    public class FavouriteService: IFavouriteService
    {
        readonly IFavouriteValidator _favouriteValidator;
        readonly IFavouriteRepository _favouriteRepo;


        public FavouriteService(IFavouriteValidator favouriteValidator, IFavouriteRepository favouriteRepository)
        {
            _favouriteValidator = favouriteValidator ?? throw new NullReferenceException("Validator cannot be null");
            _favouriteRepo = favouriteRepository ?? throw new NullReferenceException("Repository cannot be null");
        }


        public Favourite NewLoggedInUsersFavouritedPoster(int posterID)
        {
            return _favouriteRepo.CreateNewLoggedInUsersFavouritedPoster(posterID);
        }


        public IEnumerable<Poster> FindLoggedInUsersFavouritedPosters()
        {
            return _favouriteRepo.ReadLoggedInUsersFavouritedPosters();
        }


        public Favourite RemoveALoggedInUsersFavouritedPoster(int posterID)
        {
            return _favouriteRepo.DeleteALoggedInUsersFavouritedPoster(posterID);
        }
    }
}
