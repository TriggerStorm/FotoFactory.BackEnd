using System;
using System.Collections.Generic;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.DomainService
{
    public interface ICollectionRepository
    {
        List<Poster> ReadAllCollectionPosters(int collectionId);
    }
}
