using System;
using System.Collections.Generic;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService.Service
{
    public interface IPosterService
    {
        IEnumerable<Poster> FindPostersByCollectionId(int collectionId);

    }
}
