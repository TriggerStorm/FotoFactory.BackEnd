using System;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{

    public interface IUserValidator
    {
        void DefaultValidation(User user);
    }

}
