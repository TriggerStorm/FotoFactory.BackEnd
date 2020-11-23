using System;
using System.Collections.Generic;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.DomainService
//namespace FotoFactory.Core.AppService
{
    public interface IPosterRepository
    {
        Poster ReadPosterById(int id);
    }
}
