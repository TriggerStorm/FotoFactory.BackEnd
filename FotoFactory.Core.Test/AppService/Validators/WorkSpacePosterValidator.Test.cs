using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using FluentAssertions;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.Core.AppService.ValidatorInterface;
using FotoFactory.Core.AppService.Validators;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;
using FotoFactory.CoreEntities;
using Moq;
using Xunit;

namespace FotoFactory.Core.Test.AppService.Validators
{
    public class WorkSpacePosterValidator
    {
        [Fact]
        public void NewWorkSpacePosterValidator_ShouldBeOfTypeIWorkSpaceValidator()
        {
            new Core.AppService.Validators.WorkSpacePosterValidator().Should().BeAssignableTo<IWorkSpacePosterValidator>();
        }
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
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]

        public void NewWorkSpacePosterService_WithNullRepository_ShouldThrowException()
        {
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var authenticationHelperMock = new Mock<IAuthenticationHelper>();
            Action action = () => new WorkSpacePosterService(null as IWorkSpacePosterRepository, workSpacePosterValidatorMock.Object,
                authenticationHelperMock.Object);
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]

        public void NewWorkSpacePosterService_WithInvalidAuthentication_ShouldThrowException()
        {
            var workSpacePosterValidatorMock = new Mock<IWorkSpacePosterValidator>();
            var workSpacePosterRepositoryMock = new Mock<IWorkSpacePosterRepository>();
            Action action = () => new WorkSpacePosterService(workSpacePosterRepositoryMock.Object, workSpacePosterValidatorMock.Object,
                null as IAuthenticationHelper);
            action.Should().Throw<NullReferenceException>().WithMessage($"authentication helper cannot be null");
        }

        [Fact]
        public void TestValidWorkSpacePoster_DeafultValidationAsNegative_ThrowException()
        {
            IWorkSpacePosterValidator validator = new Core.AppService.Validators.WorkSpacePosterValidator();
            Action action = () => validator.DefaultValidation(new WorkSpacePoster() {XPos = -100 , YPos = -300});
            action.Should().Throw<Exception>().WithMessage($"position of x and y cannot be negative");
        }

        [Fact]
        public void TestValidWorkSpacePoster_DeafultValidationXPosAsNegative_ThrowException()
        {
            IWorkSpacePosterValidator validator = new Core.AppService.Validators.WorkSpacePosterValidator();
            Action action = () => validator.DefaultValidation(new WorkSpacePoster() { XPos = -100, YPos = 300 });
            action.Should().Throw<Exception>().WithMessage($"position of x and y cannot be negative");
        }
        [Fact]
        public void TestValidWorkSpacePoster_DeafultValidationYPosAsNegative_ThrowException()
        {
            IWorkSpacePosterValidator validator = new Core.AppService.Validators.WorkSpacePosterValidator();
            Action action = () => validator.DefaultValidation(new WorkSpacePoster() { XPos = 100, YPos = -300 });
            action.Should().Throw<Exception>().WithMessage($"position of x and y cannot be negative");
        }
        [Fact]

        public void Delete__WithZeroId_ShouldThrowException()
        {
            IWorkSpacePosterValidator validator = new Core.AppService.Validators.WorkSpacePosterValidator();
            Action action = () => validator.DeleteWorkSpacePoster(0);
            action.Should().Throw<NoNullAllowedException>().WithMessage("id cant be null or negative");
        }

        [Fact]
        public void Delete_WithNegativeId_ShouldThrowException()
        {
            IWorkSpacePosterValidator validator = new Core.AppService.Validators.WorkSpacePosterValidator();
            Action action = () => validator.DeleteWorkSpacePoster(-1);
            action.Should().Throw<NoNullAllowedException>().WithMessage($"id cant be null or negative");
        }

        [Fact]

        public void Update_WithNegativeId_ShouldThrowException()
        {
            IWorkSpacePosterValidator validator = new Core.AppService.Validators.WorkSpacePosterValidator();
            Action acton = () => validator.UpdateWorkSpacePoster(-1, 100, 500);
            acton.Should().Throw<NoNullAllowedException>();
        }

        [Fact]

        public void Update_WithXPosAsNull_ShouldThrowException()
        {
            IWorkSpacePosterValidator validator = new Core.AppService.Validators.WorkSpacePosterValidator();
            Action acton = () => validator.UpdateWorkSpacePoster(-1, 0, 500);
            acton.Should().Throw<NoNullAllowedException>();
        }

        [Fact]

        public void Update_WithYPosAsNull_ShouldThrowException()
        {
            IWorkSpacePosterValidator validator = new Core.AppService.Validators.WorkSpacePosterValidator();
            Action acton = () => validator.UpdateWorkSpacePoster(-1, 300, 0);
            acton.Should().Throw<NoNullAllowedException>();
        }

    }
}
