using System;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface IPosterValidator
    {
        void DefaultValidation(Poster poster);
    }
}
