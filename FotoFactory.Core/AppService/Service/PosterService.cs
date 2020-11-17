using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService.Service
{
    public class PosterService: IPosterService
    {
        readonly IPosterRepository _posterRepo;

    
        public PosterService(IPosterRepository posterRepository)
        {
            _posterRepo = posterRepository;
        }


        public IEnumerable<Poster> FindPostersByCollectionId(int collectionId)
        {
            IEnumerable<Poster> collectionPosters;
            var posterList = _posterRepo.ReadAllPosters();
            collectionPosters = posterList.Where(p => p.Collection == collectionId);
            return collectionPosters.ToList();
        }

      

    }
}
