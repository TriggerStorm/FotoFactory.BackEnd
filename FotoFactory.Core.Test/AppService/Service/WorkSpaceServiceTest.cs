using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
    //given >>>> service
    //when>>>> 
    //then>>>>result
    ////where>>>
    public class WorkSpaceServiceTest
    {
        private void CheckPerformance(Action a, int ms)
        {
            DateTime start = DateTime.Now;
            a.Invoke();
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= ms);

        }

        [Fact]
        public void testValidWorkSpaceServiceIsCreated()
        {
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var workSpaceAuthenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            Action action = () => new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object, userRepoMock.Object,
                workSpaceAuthenticationHelperMock.Object).Should().NotBe(null);
            
        }

        [Fact]
        public void workSpaceService_IsOfTypeIWorkSpaceService()
        {
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var workSpaceAuthenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object,userRepoMock.Object,
                workSpaceAuthenticationHelperMock.Object).Should().BeAssignableTo<IWorkSpaceService>();
        }

        [Fact]

        public void NewWorkSpace_WithNullRepository_ShouldThrowException()
        {
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var workSpaceAuthenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            Action action = () => new WorkSpaceService(null as IWorkSpaceRepository, workSpaceValidatorMock.Object,userRepoMock.Object,
                workSpaceAuthenticationHelperMock.Object);
            action.Should().Throw<NullReferenceException>().WithMessage("Repo Cannot be null");
        }

        [Fact]

        public void NewWorkSpaceService_WithInvalidAuthentication_ShouldThrowException()
        {
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var userRepoMock = new Mock<IUserRepository>();
            Action action = () => new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object,userRepoMock.Object,
                null as IAuthenticationHelper);
            action.Should().Throw<NullReferenceException>().WithMessage("AuthenticationHelper cannot be null");
            
        }


        //[Fact]
        //public void Create_ChecksWorkSpaceRepositoryCreate_withCorrectParam_Once()
        //{
        //arrange
        //    var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
        //    var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
        //    var authenticationHelperMock = new Mock<IAuthenticationHelper>();
        //    var userRepoMock = new Mock<IUserRepository>();
        //    IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object,userRepoMock.Object
        //    authenticationHelperMock.Object);
        //    var workSpace = new WorkSpace() { Name = "kitchen", BackGroundColour = "grey" };
        // assign
        //    workSpaceRepositoryMock.Setup(workSpaceRepositoryMock => workSpaceRepositoryMock.CreateWorkSpace(workSpace)).Returns(() => workSpace);
        //    service.CreateWorkSpace("kitchen",  "grey");
        // assert
        //    workSpaceRepositoryMock.Verify(r => r.CreateWorkSpace(workSpace), Times.Once);
        //    CheckPerformance(() => service.CreateWorkSpace("kitchen" , "grey"), 1000);
        //}

        [Fact]
        public void ReadAll_ShouldMatchReadAllInRepository_Once()
        {
            //arrange
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object,userRepoMock.Object,
                authenticationHelperMock.Object);
            var readWorkSpace = new WorkSpace(){WorkSpaceId = 50 , Name = "", BackGroundColour = ""};
            //assign
            workSpaceRepositoryMock.Setup(r => r.ReadAllWorkSpace(50));
            service.ReadAllWorkSpace(50);
            //assert
            workSpaceRepositoryMock.Verify(r => r.ReadAllWorkSpace(50), Times.Once());
            CheckPerformance(() => service.ReadAllWorkSpace(50), 1000);
        }

        [Fact]
        public void ReadAllWorkSpace_WithZeroAsUserId_ShouldFail_Once()
        {
            //arrange
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object, userRepoMock.Object,
                authenticationHelperMock.Object);
            var mockWorkSpace = new WorkSpace(){WorkSpaceId = 0, Name = "", BackGroundColour = ""};// need a userid to read all workspace
            //assign
            workSpaceRepositoryMock.Setup(r => r.ReadAllWorkSpace(0));
            service.ReadAllWorkSpace(0);
            // assert
            workSpaceRepositoryMock.Verify(r => r.ReadAllWorkSpace(0), Times.Once());
            CheckPerformance(() => service.ReadAllWorkSpace(0), 1000);
        }

        [Fact]
        public void ReadAllWorkSpace_withNegativeUserId_Once()
        {
            //arrange
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object,userRepoMock.Object,
                authenticationHelperMock.Object);
            WorkSpace mockWorkSpace = new WorkSpace() { WorkSpaceId = -1, Name = " bedroom", BackGroundColour = "yellow" };
            //assign
            workSpaceRepositoryMock.Setup(rm => rm.ReadAllWorkSpace(-1));
            service.ReadAllWorkSpace(-1);
            //assert
            workSpaceRepositoryMock.Verify(rm => rm.ReadAllWorkSpace(-1), Times.Once);


        }

        [Fact]
        public void ReadById_ShouldMatchReadByIdInRepository_Once()
        {
            //aarange
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object,userRepoMock.Object,
                authenticationHelperMock.Object);
            var mockWorkSpace = new WorkSpace() { WorkSpaceId = 10, Name = " kitchen", BackGroundColour = "green" };
           //assign 
            workSpaceRepositoryMock.Setup(r => r.ReadWorkSpaceByID(10)).Returns(() => mockWorkSpace);
            service.ReadWorkSpaceByID(10);
            //assert
            workSpaceRepositoryMock.Verify(r => r.ReadWorkSpaceByID(10), Times.Once);
            CheckPerformance(() => service.ReadWorkSpaceByID(10), 1000);
        }

        [Fact]
        public void ReadWorkSpaceByID_WithZeroInParam_Once()
        {
            //arrange
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object,userRepoMock.Object,
                authenticationHelperMock.Object);
            WorkSpace mockWorkSpace = new WorkSpace() {WorkSpaceId = 0,Name = " stairs", BackGroundColour = "green"};
            //assign
            workSpaceRepositoryMock.Setup(rm => rm.ReadWorkSpaceByID(0)).Returns(() =>mockWorkSpace);
            service.ReadWorkSpaceByID(0);
            //assert
            workSpaceRepositoryMock.Verify(rm => rm.ReadWorkSpaceByID(0),Times.Once);
            CheckPerformance(() => service.ReadWorkSpaceByID(0), 1000);
            
        }

        [Fact]
        public void ReadWorkSpaceId_WithNegativeInputAsId_ShouldThrowException()
        {//arrange
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object,userRepoMock.Object,
                authenticationHelperMock.Object);
            WorkSpace mockWorkSpace = new WorkSpace() { WorkSpaceId = -1, Name = " bedroom", BackGroundColour = "yellow" };
            //assign
            workSpaceRepositoryMock.Setup(rm => rm.ReadWorkSpaceByID(-1));
            service.ReadWorkSpaceByID(-1);
            //assert
            workSpaceRepositoryMock.Verify(rm => rm.ReadWorkSpaceByID(-1), Times.Once);
            CheckPerformance(() => service.ReadWorkSpaceByID(-1), 1000);
        }


        [Fact]
        public void Update_ShouldCallWorkSpaceRepositoryUpdate_WithWorkSpaceObjectAndIdAsParam_Once()
        {
            //arrange
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object,workSpaceValidatorMock.Object,userRepoMock.Object,
                authenticationHelperMock.Object);
            var workSpace = new WorkSpace(){ WorkSpaceId = 11, Name = " Bedroom", BackGroundColour = " blue" };
            //assign
            var workSpaceUpdate = new WorkSpace() { WorkSpaceId = 11, Name = " Bathroom", BackGroundColour = " black" };
            var workSpaceUpdated = new WorkSpace(){ WorkSpaceId = 11, Name = " stairs", BackGroundColour = " grey" };
            workSpaceRepositoryMock.Setup(r => r.ReadWorkSpaceByID(11)).Returns(() => workSpaceUpdated);
            service.UpdateWorkSpace(11, workSpaceUpdated);
            //assert
            workSpaceRepositoryMock.Verify(repository => repository.UpdateWorkSpace(11, workSpaceUpdated), Times.Once);
            CheckPerformance(() => service.UpdateWorkSpace(11, workSpace), 1000);
        }

        
        [Fact]
        public void Delete_ShouldCallDeleteMethodInRepository_withParamAsId_Once()
        {
            //arrange
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object, 
                userRepoMock.Object,authenticationHelperMock.Object);
            //assign
            var deletedWorkSpace = new WorkSpace() {WorkSpaceId = 3, Name = "", BackGroundColour = ""};
            workSpaceRepositoryMock.Setup(r => r.DeleteWorkSpace(3)).Returns(() => deletedWorkSpace);
            service.DeleteWorkSpace(3);
            //assert
            workSpaceRepositoryMock.Verify(r => r.DeleteWorkSpace(3), Times.Once());
            CheckPerformance(() => service.DeleteWorkSpace(3), 1000);
        }

        [Fact]

        public void Add_WorkSpacePoster_ShouldFail_WithIncorrectParam()
        {
            //arrange
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object,
                userRepoMock.Object,authenticationHelperMock.Object);
            //assign
            workSpaceRepositoryMock.Setup(r => r.AddWorkSpacePoster(2, 0));
            service.AddWorkSpacePoster(2, 0);
            //assert
            workSpaceRepositoryMock.Verify(r => r.AddWorkSpacePoster(2, 0));
            CheckPerformance(() => service.AddWorkSpacePoster(2, 0), 1000);
        }

        [Fact]

        public void Delete_WorkSpacePoster_ShouldFail_WithIncorrectParam()
        {
            //arrange
            var workSpaceValidatorMock = new Mock<IWorkSpaceValidator>();
            var workSpaceRepositoryMock = new Mock<IWorkSpaceRepository>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var userRepoMock = new Mock<IUserRepository>();
            IWorkSpaceService service = new WorkSpaceService(workSpaceRepositoryMock.Object, workSpaceValidatorMock.Object, 
                userRepoMock.Object,authenticationHelperMock.Object);
          //assign
            var deleteWorkSpacePoster = new WorkSpacePoster() {WorkSpacePosterId = -2};
            workSpaceRepositoryMock.Setup(r => r.RemoveWorkSpacePoster(-2, -2));
            service.RemoveWorkSpacePoster(-2, -2);
            //assert
            workSpaceRepositoryMock.Verify(r => r.RemoveWorkSpacePoster(-2, -2));
            CheckPerformance(() => service.RemoveWorkSpacePoster(-2, -2), 1000);
        }

    }
}
