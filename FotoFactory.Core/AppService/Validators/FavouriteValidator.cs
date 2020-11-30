using System;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService.Validators
{
    public class FavouriteValidator: IFavouriteValidator
    {
        public void DefaultValidation(Favourite favourite)
        {
            if (favourite == null)
            {
                throw new NullReferenceException("Favourite cannot be null");
            }
            if (favourite.UserId < 1)
            {
                throw new NullReferenceException("Favourite UserId cannot be less than 1");
            }
            if (favourite.User == null)
            {
                throw new NullReferenceException("Favourite User cannot be null");
            }
            if (favourite.PosterId < 1)
            {
                throw new NullReferenceException("Favourite PosterId cannot be less than 1");
            }
            if (favourite.Poster == null)
            {
                throw new NullReferenceException("Favourite Poster cannot be null");
            }
        }
    }
}
