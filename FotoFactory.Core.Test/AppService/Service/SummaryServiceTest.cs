using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;
using Moq;
using Xunit;

namespace FotoFactory.Core.Test.AppService.Service
{
    //public class SummaryServiceTest
    //{
    //    [Fact]
    //    public void PosterService_TestReadByIdBehaviour()
    //    {
    //        var validatorMock = new Mock<IPosterValidator>();
    //        var repositoryMock = new Mock<IPosterRepository>();
    //        PosterService posterService = new PosterService(validatorMock.Object, repositoryMock.Object);
    //        Poster mockPoster = new Poster()
    //        {
    //            PosterId = 84,
    //            PosterName = "Rold Skov",
    //            PosterSku = "FF160DK",
    //            Path = ".../Assets/FF160DK.jpg",
    //            CollectionId = 1
    //        };
    //        repositoryMock.Setup(repositoryMock => repositoryMock.ReadPosterById(84)).Returns(() => mockPoster);
    //        posterService.FindPosterById(84);
    //        repositoryMock.Verify(repositoryMock => repositoryMock.ReadPosterById(84), Times.Once);
    //    }
    //}
}
