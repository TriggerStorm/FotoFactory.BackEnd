using System;
using System.Collections.Generic;
using FluentAssertions;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;
using Moq;
using Xunit;

namespace FotoFactory.Core.Test.AppService.Service
{
    public class FavouriteServiceTest
    {
        [Fact]
        public void NewFavouriteService_WithNullValidator_ShouldThrowException()
        {
            Action action = () => new FavouriteService(null as IFavouriteValidator, null as IFavouriteRepository);
            action.Should().Throw<NullReferenceException>("Validator cannot be null");
        }


        [Fact]
        public void NewFavouriteService_WithNullRepository_ShouldThrowException()
        {
            var validatorMock = new Mock<IFavouriteValidator>();
            Action action = () => new FavouriteService(validatorMock.Object, null as IFavouriteRepository);
            action.Should().Throw<NullReferenceException>("Repository cannot be null");
        }


        [Fact]
        public void FavouriteService_ShouldBeOfTypeIFavouriteService()
        {
            var validatorMock = new Mock<IFavouriteValidator>();
            var repositoryMock = new Mock<IFavouriteRepository>();
            new FavouriteService(validatorMock.Object, repositoryMock.Object).Should().BeAssignableTo<IFavouriteService>();
        }


    }
}
