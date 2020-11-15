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
                throw new NullReferenceException("User id cannot be less than 1");
            }
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new InvalidDataException("User name cannot be empty");
            }
            if (user.PasswordHash == null)
            {
                throw new InvalidDataException("To create a user you need a password hash");
            }
            if (user.PasswordSalt == null)
            {
                throw new InvalidDataException("To create a user you need to a password salt");
            }
            if (user.IsAdmin != false || user.IsAdmin != true)
            {
                throw new InvalidDataException("To create a user you need to specify if they are an admin or user");
            }

        }

    }
}
