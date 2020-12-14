using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentAssertions;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.Core.AppService.ValidatorInterface;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;
using Moq;
using Xunit;

namespace FotoFactory.Core.Test.AppService.Validators
{
    public class WorkSpacePosterValidator
    {
        [Fact]
        public void workSpacePosterService_IsOfTypeIWorkSpacePosterService()
        {
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object).Should().BeAssignableTo<IWorkSpacePosterService>();
        }

        [Fact]
        public void NewWorkSpacePosterService_WithNullValidator_ShouldThrowException()
        {
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            Action action = () => new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, null as IWorkSpacePosterValidator,
                authenticationHelperMock.Object);
            action.Should().Throw<NullReferenceException>().WithMessage("Validator Cannot be null");
        }

        [Fact]

        public void NewWorkSpacePosterService_WithNullRepository_ShouldThrowException()
        {
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            Action action = () => new WorkSpacePosterService(null as IWorkSpacePosterRepository, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object);
            action.Should().Throw<NullReferenceException>().WithMessage("Repo Cannot be null");
        }

        [Fact]

        public void NewWorkSpacePosterService_WithInvalidAuthentication_ShouldThrowException()
        {
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var authenticationHelper = new Mock<IAuthenticationHelper>();
            Action action = () => new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                null as IAuthenticationHelper);
            action.Should().Throw<NullReferenceException>().WithMessage($" authentication helper cannot be null");
        }

        [Fact]
        public void ReadWorkSpacePosterByID_WithZeroInParam_ShouldThrowException()
        {
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            Action action = () => new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object).ReadWorkSpacePosterById(0);
        }


    }
}
