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
    public class CollectionServiceTest
    {

        [Fact]
        public void NewCollectionService_WithNullValidator_ShouldThrowException()
        {
            Action action = () => new CollectionService(null as ICollectionValidator, null as ICollectionRepository);
            action.Should().Throw<NullReferenceException>("Validator cannot be null");
        }


        [Fact]
        public void NewPosterService_WithNullRepository_ShouldThrowException()
        {
            var validatorMock = new Mock<ICollectionValidator>();
            Action action = () => new CollectionService(validatorMock.Object, null as ICollectionRepository);
            action.Should().Throw<NullReferenceException>("Repository cannot be null");
        }


        [Fact]
        public void CollectionService_ShouldBeOfTypeICollectionService()
        {
            var validatorMock = new Mock<ICollectionValidator>();
            var repositoryMock = new Mock<ICollectionRepository>();
            new CollectionService(validatorMock.Object, repositoryMock.Object).Should().BeAssignableTo<ICollectionService>();
        }
    }
}
