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
                throw new NullReferenceException("Favouriting user id cannot be less than 1");
            }
            if (favourite.User == null)
            {
                throw new NullReferenceException("Favouriting user cannot be null");
            }
            if (favourite.PosterId < 1)
            {
                throw new NullReferenceException("Favourited poster id cannot be less than 1");
            }
            if (favourite.Poster == null)
            {
                throw new NullReferenceException("Favourited poster cannot be null");
            }
        }
    }
}
