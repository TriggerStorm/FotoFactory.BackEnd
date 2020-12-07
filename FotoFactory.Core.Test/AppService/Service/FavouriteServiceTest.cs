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


        [Fact]
        public void FavouriteService_TestAddBehaviour()
        {
            var validatorMock = new Mock<IFavouriteValidator>();
            var repositoryMock = new Mock<IFavouriteRepository>();
            FavouriteService fService = new FavouriteService(validatorMock.Object, repositoryMock.Object);
            Favourite favouriteToDelete = fService.NewLoggedInUsersFavouritedPoster(19);
            repositoryMock.Verify(repositoryMock => repositoryMock.CreateNewLoggedInUsersFavouritedPoster(19), Times.Once);
        }


        [Fact]
        public void FavouriteService_TestReadByIdBehaviour()
        {
            var validatorMock = new Mock<IFavouriteValidator>();
            var repositoryMock = new Mock<IFavouriteRepository>();
            FavouriteService favouriteService = new FavouriteService(validatorMock.Object, repositoryMock.Object);
            List<Poster> mockCollection = new List<Poster>()
            {
                new Poster
                {
                    PosterId = 84,
                    PosterName = "Rold Skov",
                    PosterSku = "FF160DK",
                    Path = ".../Assets/FF160DK.jpg",
                    CollectionId = 1
                },
                new Poster
                {
                    PosterId = 85,
                    PosterName = "Rold",
                    PosterSku = "FF140DK",
                    Path = ".../Assets/FF140DK.jpg",
                    CollectionId = 1
                }
            };
            repositoryMock.Setup(repositoryMock => repositoryMock.ReadLoggedInUsersFavouritedPosters()); //.Returns(() => mockPoster);
            favouriteService.FindLoggedInUsersFavouritedPosters();
            repositoryMock.Verify(repositoryMock => repositoryMock.ReadLoggedInUsersFavouritedPosters(), Times.Once);
        }


        [Fact]
        public void FavouriteService_TestDeleteBehaviour()
        {
            var validatorMock = new Mock<IFavouriteValidator>();
            var repositoryMock = new Mock<IFavouriteRepository>();
            FavouriteService favouriteService = new FavouriteService(validatorMock.Object, repositoryMock.Object);
            Favourite favouriteToDelete = favouriteService.RemoveALoggedInUsersFavouritedPoster(9);
            repositoryMock.Verify(repositoryMock => repositoryMock.DeleteALoggedInUsersFavouritedPoster(9), Times.Once);
        }

    }
}
