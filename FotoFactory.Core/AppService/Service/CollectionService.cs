using System;
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


          /*  IEnumerable<Poster> collectionPosters;
            var posterList = _collectionRepo.ReadAllCollectionPosters(collectionId);
            collectionPosters = posterList.Where(p => p.CollectionId == collectionId);
            //return collectionPosters.ToList();
            List<Poster> pl = collectionPosters.ToList();
            Console.WriteLine(pl[1].PosterSizes[1].Size.SizeId);
          */
        
        }


    }
}
