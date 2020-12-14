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
        public void Create_CallsWorkSpacePosterRepositoryCreate_withCorrectParam_Once()
        {
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            IWorkSpacePosterService workSpacePosterService = new WorkSpacePosterService(workSpacePosterRepositoryMock.Object,
                workSpacePosterValidatorMock.Object, authenticationHelperMock.Object);
            var workSpacePoster = new WorkSpacePoster() { XPos = 100, YPos = 200};
            workSpacePosterService.CreateWorkSpacePoster(workSpacePoster.XPos, workSpacePoster.YPos,
                workSpacePoster.Poster.PosterId, workSpacePoster.Frame.FrameId, workSpacePoster.Size.SizeId);
            workSpacePosterRepositoryMock.Verify(r => r.CreateWorkSpacePoster(workSpacePoster, workSpacePoster.Poster.PosterId,
                workSpacePoster.Frame.FrameId,workSpacePoster.Size.SizeId),Times.Once);
        }








    }
}
