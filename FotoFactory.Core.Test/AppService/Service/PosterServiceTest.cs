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



        /*  NO UPDATE FUCTION YET
           [Fact]
           public void Update_ShouldCallPosterValidatorDefaultValidationWithPosterParam_Once()
           {
               var validatorMock = new Mock<IPosterValidator>();
               var repositoryMock = new Mock<IPosterRepository>();
               IPosterService service = new PosterService(validatorMock.Object, repositoryMock.Object);
               var poster = new Poster
               {
                   PosterId = 1,
                   PosterName = "Rold Skov",
                   PosterSku = "FF160DK",
                   Path = "/assets/denmark-posters/FF160DK.png",
                   CollectionId = 1,
                   PosterTags = null,
                   PosterSizes = null,
                   Favourites = null
               };
             //      Additional = "Ost", City = new City { ZipCode = 1 }, StreetName = "Osteby", StreetNr = 2 };
               service.Update(poster);
               validatorMock.Verify(validator => validator.DefaultValidation(poster), Times.Once);
           }
        */


      /*  
        [Fact]
        public void TestReadByIdBehaviour()
        {
            var validatorMock = new Mock<IPosterValidator>();
            var repositoryMock = new Mock<IPosterRepository>();

            PosterService posterService = new PosterService(mock.Object);

            Poster poster160DK = new Poster()
            {
                PosterName = "Rold Skov",
                PosterSku = "FF160DK",
                Path = ".../Assets/FF160DK.jpg",
                CollectionId = 1
            };

        }       /*  PosterTags = new List<PosterTag>
                {
                    new Tag
                    {
                        TagId = 5,
                        Description = "Skov",
                        PosterTags = new List<PosterTag>
                        {
                            new PosterTag
                            {
                                Poster = null,

                            }


                        }


                        } 
        //   },


        /*   poster160DK.PosterSizes = new List<PosterSize>
           {
               new PosterSize
               {
                   Poster = poster160DK,
                   Size = size01
               },
                new PosterSize
               {
                   Poster = poster160DK,
                   Size = size02
               },
                  new PosterSize
               {
                   Poster = poster160DK,
                   Size = size03
               },
                  new PosterSize
               {
                   Poster = poster160DK,
                   Size = size05
               },
                  new PosterSize
               {
                   Poster = poster160DK,
                   Size = size06
               }
           };


           mock.Setup(mock => mock.GetCarById(2)).Returns(() => carList[0]);

           cService.GetCarById(2);

           mock.Verify(mock => mock.GetCarById(2), Times.Once);
       }

   }

   /*
using System.Linq;
using System.Text;

namespace XUnitTestCore
{
   public class TestService
   {
       //test actions
       [Fact]
       public void PassNullAsICarRepository_ThrowsNullRefException()
       {
           ICarRepository carRepo = null;
           Assert.Throws<NullReferenceException>(() => new CarService(carRepo));
       }

       [Fact]
       public void TestCreateBehaviour()
       {
           Mock<ICarRepository> mock = new Mock<ICarRepository>();

           CarService cService = new CarService(mock.Object);

           Car car = new Car
           {
               Id = 2,
               Brand = "Volvo",
               CarType = "Coupe",
               Color = "White",
               Price = 19500,
               ReleaseDate = new DateTime(2020, 01, 10)
           };
           cService.Create(car);

           mock.Verify(mock => mock.Create(car), Times.Once);
       }

       [Fact]
       public void TestReadAllBehaviour()
       {
           Mock<ICarRepository> mock = new Mock<ICarRepository>();

           Car[] returnValue =    {new Car { Id = 2, Brand = "Volvo", CarType = "Coupe", Color = "White"
               ,Price = 19500, ReleaseDate = new DateTime(2020, 01, 10)},
                                   new Car{ Id = 3, Brand = "Audi", CarType = "Sedan", Color = "Black"
               ,Price = 20000, ReleaseDate = new DateTime(2020, 01, 10)}};

           mock.Setup(mock => mock.GetAllCars()).Returns(() => returnValue.ToList());

           CarService cService = new CarService(mock.Object);

           cService.GetAllCars();

           mock.Verify(mock => mock.GetAllCars(), Times.Once);
       }

       [Fact]
       public void TestReadByIdBehaviour()
       {
           Mock<ICarRepository> mock = new Mock<ICarRepository>();

           CarService cService = new CarService(mock.Object);

           Car[] carList =    {new Car { Id = 2, Brand = "Volvo", CarType = "Coupe", Color = "White"
               ,Price = 19500, ReleaseDate = new DateTime(2020, 01, 10)},
                                   new Car{ Id = 3, Brand = "Audi", CarType = "Sedan", Color = "Black"
               ,Price = 20000, ReleaseDate = new DateTime(2020, 01, 10)}};

           mock.Setup(mock => mock.GetCarById(2)).Returns(() => carList[0]);

           cService.GetCarById(2);

           mock.Verify(mock => mock.GetCarById(2), Times.Once);
       }

       [Fact]
       public void TestDeleteBehaviour()
       {
           Mock<ICarRepository> mock = new Mock<ICarRepository>();

           CarService cService = new CarService(mock.Object);

           Car carToDelete = cService.Delete(2);

           mock.Verify(mock => mock.Delete(2), Times.Once);
       }


   } */
    }

}
