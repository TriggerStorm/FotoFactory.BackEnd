﻿using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.CoreEntities;
using FotoFactory.Core.DomainService;

namespace FotoFactory.Core.AppService.Service
{
    public class CollectionService: ICollectionService
    {
        readonly ICollectionRepository _collectionRepo;

        public CollectionService(ICollectionRepository collectionRepository)
        {
            _collectionRepo = collectionRepository;
        }


        public IEnumerable<Poster> FindPostersByCollectionId(int collectionId)
        {
            return _collectionRepo.ReadAllCollectionPosters(collectionId).ToList();
        }

    }
}
