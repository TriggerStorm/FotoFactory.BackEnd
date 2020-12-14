using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.CoreEntities;
using FotoFactory.Core.DomainService;

namespace FotoFactory.Core.AppService.Service
{
    public class CollectionService: ICollectionService
    {
        readonly ICollectionValidator _collectionValidator;
        readonly ICollectionRepository _collectionRepo;

        public CollectionService(ICollectionValidator collectionValidator, ICollectionRepository collectionRepository)
        {
            _collectionValidator = collectionValidator ?? throw new NullReferenceException("Validator cannot be null");
            _collectionRepo = collectionRepository ?? throw new NullReferenceException("Repository cannot be null");
        }


        public List<Poster> FindPostersByCollectionId(int collectionId)
        {
            return _collectionRepo.ReadAllCollectionPosters(collectionId);
        }

    }
}
