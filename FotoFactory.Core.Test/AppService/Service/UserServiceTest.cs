using System;
using System.Collections.Generic;
using FluentAssertions;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;
using FotoFactory.CoreEntities;
using Moq;
using Xunit;

namespace FotoFactory.Core.Test.AppService.Service
{
    public class UserServiceTest
    {
       
        [Fact]
        public void NewUserService_WithNullValidator_ShouldThrowException()
        {
            Action action = () => new UserService(null as IUserValidator, null as IUserRepository, null as IAuthenticationHelper);
            action.Should().Throw<NullReferenceException>("Validator cannot be null");
        }


        [Fact]
        public void NewUserService_WithNullRepository_ShouldThrowException()
        {
            var validatorMock = new Mock<IUserValidator>();
            Action action = () => new UserService(validatorMock.Object, null as IUserRepository, null as IAuthenticationHelper);
            action.Should().Throw<NullReferenceException>("Repository cannot be null");
        }


        [Fact]
        public void NewUser_WithNullRepository_ShouldThrowException()
        {
            var validatorMock = new Mock<IUserValidator>();
            var repositoryMock = new Mock<IUserRepository>();
            Action action = () => new UserService(validatorMock.Object, repositoryMock.Object, null as IAuthenticationHelper);
            action.Should().Throw<NullReferenceException>("AuthenticationHelper cannot be null");
        }


        [Fact]
        public void UserService_ShouldBeOfTypeIPosterService()
        {
            var validatorMock = new Mock<IUserValidator>();
            var repositoryMock = new Mock<IUserRepository>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            new UserService(validatorMock.Object, repositoryMock.Object, authenticationHelperMock.Object).Should().BeAssignableTo<IUserService>();
        }
    
    }
}
