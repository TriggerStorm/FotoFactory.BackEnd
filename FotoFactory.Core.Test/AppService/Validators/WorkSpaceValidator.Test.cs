using System;
using System.Collections.Generic;
using System.IO;
using System;
using System.Data;
using System.Text;
using FluentAssertions;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.Core.AppService.Validators;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;
using FotoFactory.CoreEntities;
using Moq;
using Xunit;

namespace FotoFactory.Core.Test.AppService.Validators
{
    public class WorkSpaceServiceValidator
    {
       
        [Fact]
        public void NewWorkSpaceValidator_ShouldBeOfTypeIWorkSpaceValidator()
        {
            new WorkSpaceValidator().Should().BeAssignableTo<IWorkSpaceValidator>();
        }

        [Fact]
        public void TestValidWorkSpace_DeafultValidationNameAsNull_ThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.DefaultValidation(new WorkSpace() { Name = null, BackGroundColour = "green" });
            action.Should().Throw<NoNullAllowedException>().WithMessage("Name cannot be null");
        }

        [Fact]
        public void TestValidWorkSpace_DeafultValidationBCAsNull_ThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.DefaultValidation(new WorkSpace() { Name = "stairs", BackGroundColour = null });
            action.Should().Throw<NullReferenceException>().WithMessage("BackgroundColour cannot be null");
        }


        [Fact]

        public void TestWorkSpace_DefaultValidation_NameLengthCountBelow5_ThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.DefaultValidation(new WorkSpace() {Name =  Int64.MinValue.ToString("1")});
            action.Should().Throw<InvalidDataException>().WithMessage($"name cannot be less than 5 characters");
        }

        [Fact]

        public void TestworkSpace_DeafultValidatiion_NameLengthNotMoreThan200_ThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.DefaultValidation(new WorkSpace() {Name = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", BackGroundColour = "lol" });
            action.Should().Throw<InvalidDataException>().WithMessage($"name cannot be more than 200 characters");
        }



        [Fact]
        public void Delete__WithZeroId_ShouldThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.DeleteWorkSpace(0);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]

        public void Update_WithNegativeId_ShouldThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.UpdateWorkSpace(-1,new WorkSpace() { WorkSpaceId = -1 ,Name = " Kitchen" , BackGroundColour = "Grey"});
            action.Should().Throw<NoNullAllowedException>().WithMessage($"id cannot be null");
        }

        [Fact]

        public void Update_WithNullWorkSpace_ShouldThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.UpdateWorkSpace(1,new WorkSpace() {  Name = null, BackGroundColour = null });
            action.Should().Throw<NoNullAllowedException>().WithMessage("name cannot have numbers or be empty");
        }

        [Fact]

        public void CheckValidity_WspIdAsNegative_ThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.CheckWorkspaceIdValidity(1, -1 );
            action.Should().Throw<InvalidDataException>().WithMessage("workSpaceId and WorkSpacePosterId cannot be less than 1");
        }
        [Fact]

        public void CheckValidity_WorkSpaceIdAsZero_ThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.CheckWorkspaceIdValidity(0, 1);
            action.Should().Throw<InvalidDataException>().WithMessage("workSpaceId and WorkSpacePosterId cannot be less than 1");
        }
        
        [Fact]

        public void CheckValidity_WspIdAsZero_ThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.CheckWorkspaceIdValidity(1, 0);
            action.Should().Throw<InvalidDataException>().WithMessage("workSpaceId and WorkSpacePosterId cannot be less than 1");
        }


        [Fact]

        public void CheckValidity_WithNegativeId_ThrowException()
        {
            IWorkSpaceValidator validator = new WorkSpaceValidator();
            Action action = () => validator.CheckWorkspaceIdValidity(-1, -1);
            action.Should().Throw<InvalidDataException>().WithMessage("workSpaceId and WorkSpacePosterId cannot be less than 1");

        }





    }
}
