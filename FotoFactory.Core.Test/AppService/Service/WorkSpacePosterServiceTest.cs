using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.Core.AppService.ValidatorInterface;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;
using FotoFactory.CoreEntities;
using Moq;
using Xunit;

namespace FotoFactory.Core.Test.AppService.Service
{
    public class WorkSpacePosterServiceTest
    {
        [Fact]

        public void TestValidWorkSpacePosterServiceIsCreated()
        {
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var workSpaceAuthenticationHelper = new Mock<IAuthenticationHelper>();
            Action action = () => new WorkSpacePosterService(workSpacePosterRepositoryMock.Object,
                workSpacePosterValidatorMock.Object,
                workSpaceAuthenticationHelper.Object).Should().NotBe(null);
        }

        [Fact]

        public void workSpacePosterService_IsOfTypeIWorkSpacePosterService()
        {
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var workSpacePosterAuthenticationHelperMock = new Mock<IAuthenticationHelper>();
            Action action = () => new WorkSpacePosterService(workSpacePosterRepositoryMock.Object,
                workSpacePosterValidatorMock.Object,
                workSpacePosterAuthenticationHelperMock.Object).Should().BeAssignableTo<IWorkSpacePosterService>();

        }

        [Fact]

        public void NewWorkSpacePoster_WithNullRepository_ShouldThrowException()
        {
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var workSpaceAuthenticationHelperMock = new Mock<IAuthenticationHelper>();
            Action action = () => new WorkSpacePosterService(null as IWorkSpacePosterRepository, workSpacePosterValidatorMock.Object,
                workSpaceAuthenticationHelperMock.Object);
            action.Should().Throw<NullReferenceException>().WithMessage("Repo Cannot be null");
        }

        [Fact]

        public void NewWorkSpacePosterService_WithInvalidAuthentication_ShouldThrowException()
        {
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            Action action = () => new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                null as IAuthenticationHelper);
            action.Should().Throw<NullReferenceException>().WithMessage("AuthenticationHelper cannot be null");

        }


        //[Fact]
        //public void Create_CallsWorkSpacePosterRepositoryCreate_withCorrectParam_Once()
        //{
        //    //arrange
        //        var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
        //        var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
        //        var authenticationHelperMock = new Mock<IAuthenticationHelper>();
        //        IWorkSpacePosterService service = new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, 
        //            workSpacePosterValidatorMock.Object, authenticationHelperMock.Object);
        //    //assign
        //        var workSpacePoster = new WorkSpacePoster() { XPos = 100, YPos = 200};
        //        workSpacePosterRepositoryMock.Setup(r => r.CreateWorkSpacePoster(workSpacePoster, 2, 2, 2));
        //        service.CreateWorkSpacePoster(workSpacePoster.XPos, workSpacePoster.YPos, 
        //            workSpacePoster.Poster.PosterId, workSpacePoster.Frame.FrameId, workSpacePoster.Size.SizeId); 
        //    //assert
        //        workSpacePosterRepositoryMock.Verify(r => r.CreateWorkSpacePoster(workSpacePoster,2,2,2),Times.Once);
        //}


        [Fact]
        public void ReadAll_ShouldMatchReadAllInRepository_Once()
        {
            //arrange
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            IWorkSpacePosterService service = new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object);
            //assign
            var workSpacePoster = new WorkSpacePoster(){XPos = 100,YPos = 200};
            workSpacePosterRepositoryMock.Setup(r => r.ReadAllWorkSpacePoster());
            service.ReadAllWorkSpacePoster();
            workSpacePosterRepositoryMock.Verify(r => r.ReadAllWorkSpacePoster(), Times.Once);
        }

        [Fact]
        public void ReadById_ShouldMatchReadByIdInRepository_Once()
        {
            //arrange
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            IWorkSpacePosterService service = new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object);
            //assign
            var workSpacePoster = new WorkSpacePoster() { XPos = 500, YPos = 200 };
            workSpacePosterRepositoryMock.Setup(r => r.ReadWorkSpacePosterById(1));
            service.ReadWorkSpacePosterById(1);
            //assert
            workSpacePosterRepositoryMock.Verify(r => r.ReadWorkSpacePosterById(1),Times.Once);
        }

        [Fact]
        public void ReadWorkSpaceByID_WithZeroInParam_Once()
        {
            //arrange
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            IWorkSpacePosterService service = new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object);
            //assign
            var workSpacePoster = new WorkSpacePoster() { XPos = 400, YPos = 700 };
            workSpacePosterRepositoryMock.Setup(r => r.ReadWorkSpacePosterById(0));
            service.ReadWorkSpacePosterById(0);
            //assert
            workSpacePosterRepositoryMock.Verify(r => r.ReadWorkSpacePosterById(0), Times.Once);
        }

        [Fact]
        public void ReadWorkSpaceId_WithNegativeInputAsId_Once()
        {
            //arrange
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            IWorkSpacePosterService service = new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object);
            //assign
            var workSpacePoster = new WorkSpacePoster() { XPos = 400, YPos = 700 };
            workSpacePosterRepositoryMock.Setup(r => r.ReadWorkSpacePosterById(-1));
            service.ReadWorkSpacePosterById(-1);
            //assert
            workSpacePosterRepositoryMock.Verify(r => r.ReadWorkSpacePosterById(-1), Times.Once);

        }

        [Fact]
        public void Update_ShouldCallWorkSpacePosterRepositoryUpdate_Once()
        {
            //arrange
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            IWorkSpacePosterService service = new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object);
            var workSpacePoster = new WorkSpacePoster() { XPos = 400, YPos = 700 };
            //assign
            var updateWsp = new WorkSpacePoster(){XPos = 200,YPos = 300, Frame = workSpacePoster.Frame,Poster = workSpacePoster.Poster,Size = workSpacePoster.Size};
            var updatedWsp = new WorkSpacePoster() { XPos = 500, YPos = 700, Frame = workSpacePoster.Frame, Poster = workSpacePoster.Poster, Size = workSpacePoster.Size };
            workSpacePosterRepositoryMock.Setup(r => r.UpdateWorkSpacePoster(1, 500, 300)).Returns(() => updatedWsp);
            service.UpdateWorkSpacePoster(1, 500, 300);
            //assert
            workSpacePosterRepositoryMock.Verify(r => r.UpdateWorkSpacePoster(1,500,300),Times.Once);
        }

        [Fact]
        public void Delete_ShouldCallDeleteMethodInRepository_withId_Once()
        {
            //arrange
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            IWorkSpacePosterService service = new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object);
            var workSpacePoster = new WorkSpacePoster() { XPos = 200, YPos = 800 };
            var deletedWsp = new WorkSpacePoster(){ XPos = 200, YPos = 300, Frame = workSpacePoster.Frame, Poster = workSpacePoster.Poster, Size = workSpacePoster.Size };
            workSpacePosterRepositoryMock.Setup(r => r.DeleteWorkSpacePoster(1)).Returns(() => deletedWsp);
            service.DeleteWorkSpacePoster(1);
            workSpacePosterRepositoryMock.Verify(r => r.DeleteWorkSpacePoster(1), Times.Once);
        }

    }
}
