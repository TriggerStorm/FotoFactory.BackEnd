using System;
using FotoFactory.CoreEntities;
using System.Collections.Generic;

namespace FotoFactory.Core.AppService
{
    public interface ICollectionValidator
    {
        void DefaultValidation(IEnumerable<Poster> collectionPosters);
    }
}
