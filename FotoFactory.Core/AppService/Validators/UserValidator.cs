using System;
using System.IO;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService.Validators
{
    public class UserValidator: IUserValidator
    {

        public void DefaultValidation(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException("User cannot be null");
            }
            if (user.UserId < 1)
            {
                throw new InvalidDataException("UserId cannot be less than 1");
            }
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new InvalidDataException("Username cannot be null or empty");
            }
            if (user.PasswordHash == null)
            {
                throw new NullReferenceException("PasswordHash cannot be null");
            }
            if (user.PasswordSalt == null)
            {
                throw new NullReferenceException("PasswordSalt cannot be null");
            }
            if (user.IsAdmin != false || user.IsAdmin != true)
            {
                throw new InvalidDataException("IsAdmin must be true or false");
            }

        }

    }
}
