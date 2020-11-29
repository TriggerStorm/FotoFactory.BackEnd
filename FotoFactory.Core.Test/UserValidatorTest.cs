using System;
using FluentAssertions;
using Xunit;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Validators;
using FotoFactory.CoreEntities;

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

    }
}
