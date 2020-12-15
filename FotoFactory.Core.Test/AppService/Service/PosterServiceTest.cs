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
    public class PosterServiceTest
    {

        [Fact]
        public void NewPosterService_WithNullValidator_ShouldThrowException()
        {
            Action action = () => new PosterService(null as IPosterValidator, null as IPosterRepository);
            action.Should().Throw<NullReferenceException>("Validator cannot be null");
        }


        [Fact]
        public void NewPosterService_WithNullRepository_ShouldThrowException()
        {
            var validatorMock = new Mock<IPosterValidator>();
            Action action = () => new PosterService(validatorMock.Object, null as IPosterRepository);
            action.Should().Throw<NullReferenceException>("Repository cannot be null");
        }


        [Fact]
        public void PosterService_ShouldBeOfTypeIPosterService()
        {
            var validatorMock = new Mock<IPosterValidator>();
            var repositoryMock = new Mock<IPosterRepository>();
            new PosterService(validatorMock.Object, repositoryMock.Object).Should().BeAssignableTo<IPosterService>();
        }


        [Fact]
        public void PosterService_TestReadByIdBehaviour()
        {
            var validatorMock = new Mock<IPosterValidator>();
            var repositoryMock = new Mock<IPosterRepository>();
            PosterService posterService = new PosterService(validatorMock.Object, repositoryMock.Object);
            Poster mockPoster = new Poster()
            {
                PosterId = 84,
                PosterName = "Rold Skov",
                PosterSku = "FF160DK",
                Path = ".../Assets/FF160DK.jpg",
                CollectionId = 1
            };

            repositoryMock.Setup(repositoryMock => repositoryMock.ReadPosterById(84)).Returns(() => mockPoster);
            posterService.FindPosterById(84);
            repositoryMock.Verify(repositoryMock => repositoryMock.ReadPosterById(84), Times.Once);
        }     
    }
}