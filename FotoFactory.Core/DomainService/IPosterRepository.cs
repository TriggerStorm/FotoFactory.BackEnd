using System;
using System.Collections.Generic;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.DomainService
{
    public interface IPosterRepository
    {
        Poster ReadPosterById(int id);
    }
}
