using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.CoreEntities;
using FotoFactory.Core.DomainService;

namespace FotoFactory.Core.AppService.Service
{
    public class PosterService: IPosterService
    {
        readonly IPosterValidator _posterValidator;
        readonly IPosterRepository _posterRepo;


        public PosterService(IPosterValidator posterValidator, IPosterRepository posterRepository)
        {
            _posterValidator = posterValidator ?? throw new NullReferenceException("Validator cannot be null");
            _posterRepo = posterRepository ?? throw new NullReferenceException("Repository cannot be null");
        }


        public Poster FindPosterById(int id)
        {
            return _posterRepo.ReadPosterById(id);
        }

    }
}
