using System;
using System.Collections.Generic;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface ICollectionService
    {
        IEnumerable<Poster> FindPostersByCollectionId(int collectionId);
    }

}