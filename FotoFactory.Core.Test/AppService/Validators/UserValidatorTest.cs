using System;
using FluentAssertions;
using Xunit;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Validators;
using FotoFactory.CoreEntities;
using System.IO;

namespace FotoFactory.Core.Test
{
    public class UserValidatorTest
    {
        [Fact]
        public void UserValidator_ShouldBeOfTypeIUserValidator()
        {
            new UserValidator().Should().BeAssignableTo<IUserValidator>();
        }


        [Fact]
        public void DefaultValidation_WithUserThatsNull_ShouldThrowExeption()
        {
            IUserValidator userValidator = new UserValidator();
            Action action = () => userValidator.DefaultValidation(null as User);
            action.Should().Throw<NullReferenceException>().WithMessage("User cannot be null");
        }


        [Fact]
        public void DefaultValidation_WithUserIdThatsLessThan1_ShouldThrowException()
        {
            IUserValidator userValidator = new UserValidator();
            Action action = () => userValidator.DefaultValidation(new User() { UserId = 0 } as User);
            action.Should().Throw<InvalidDataException>().WithMessage("UserId cannot be less than 1");
        }


        [Fact]
        public void DefaultValidation_WithUserNameThatsNull_ShouldThrowException()
        {
            IUserValidator userValidator = new UserValidator();
            Action action = () => userValidator.DefaultValidation(new User() { UserId = 1, Username = null } as User);
            action.Should().Throw<InvalidDataException>().WithMessage("Username cannot be null or empty");
        }


        [Fact]
        public void DefaultValidation_WithUserNameThatsEmpty_ShouldThrowException()
        {
            IUserValidator userValidator = new UserValidator();
            Action action = () => userValidator.DefaultValidation(new User() { UserId = 1, Username = "" } as User);
            action.Should().Throw<InvalidDataException>().WithMessage("Username cannot be null or empty");
        }


        [Fact]
        public void DefaultValidation_WithPasswordHashThatsNull_ShouldThrowException()
        {
            IUserValidator userValidator = new UserValidator();
            Action action = () => userValidator.DefaultValidation(new User() { UserId = 1, Username = "test", PasswordHash = null } as User);
            action.Should().Throw<NullReferenceException>().WithMessage("PasswordHash cannot be null");
        }


        [Fact]
        public void DefaultValidation_WithPasswordSaltThatsNull_ShouldThrowException()
        {
            IUserValidator userValidator = new UserValidator();
            Action action = () => userValidator.DefaultValidation(new User() { UserId = 1, Username = "test", PasswordHash = new byte[3], PasswordSalt = null } as User);
            action.Should().Throw<NullReferenceException>().WithMessage("PasswordSalt cannot be null");
        }


      /*  [Fact]
        public void DefaultValidation_WithIsAdminThatsNotTrueOrFalse_ShouldThrowException()
        {
            IUserValidator userValidator = new UserValidator();
            Action action = () => userValidator.DefaultValidation(new User() { UserId = 1, Username = "test", PasswordHash = new byte[3], PasswordSalt  = new byte[3], IsAdmin = "smurf" } as User);
            action.Should().Throw<InvalidDataException>().WithMessage("IsAdmin must be true or false");
        } */
    }
}