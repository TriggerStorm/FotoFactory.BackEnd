using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.CoreEntities;
using FotoFactory.Core.DomainService;

namespace FotoFactory.Core.AppService.Service
{
    public class PosterService: IPosterService
    {
        readonly IPosterRepository _posterRepo;

    
        public PosterService(IPosterRepository posterRepository)
        {
            _posterRepo = posterRepository;
        }


        public Poster FindPosterById(int id)
        {
            return _posterRepo.ReadPosterById(id);
        }

    }
}
