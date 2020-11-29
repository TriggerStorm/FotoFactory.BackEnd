using System;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface IFavouriteValidator
    {
        void DefaultValidation(Favourite favourite);
    }
}
