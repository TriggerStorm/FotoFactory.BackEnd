using System;
using FluentAssertions;
using Xunit;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Validators;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.Test
{
    public class PosterValidatorTest
    {
        [Fact]
        public void PosterValidator_ShouldBeOfTypeIPosterValidator()
        {
            new PosterValidator().Should().BeAssignableTo<IPosterValidator>();
        }


        [Fact]
        public void DefaultValidation_WithPosterThatsNull_ShouldThrowExeption()
        {
            IPosterValidator posterValidator = new PosterValidator();
            Action action = () => posterValidator.DefaultValidation(null as Poster);
            action.Should().Throw<NullReferenceException>().WithMessage("Poster cannot be null");
        }


        [Fact]
        public void DefaultValidation_WithPosterIdLessThen1_ShouldThrowException()
        {
            IPosterValidator posterValidator = new PosterValidator();
            Action action = () => posterValidator.DefaultValidation(new Poster() { PosterId = 0 } as Poster);
            action.Should().Throw<NullReferenceException>().WithMessage("PosterId cannot be less than 1");
        }


        [Fact]
        public void DefaultValidation_WithPosterNameThatsNull_ShouldThrowException()
        {
            IPosterValidator posterValidator = new PosterValidator();
            Action action = () => posterValidator.DefaultValidation(new Poster() { PosterId = 1, PosterName = null } as Poster);
            action.Should().Throw<NullReferenceException>().WithMessage("PosterName cannot be null or empty");
        }


        [Fact]
        public void DefaultValidation_WithPosterNameThatsEmpty_ShouldThrowException()
        {
            IPosterValidator posterValidator = new PosterValidator();
            Action action = () => posterValidator.DefaultValidation(new Poster() { PosterId = 1, PosterName = "" } as Poster);
            action.Should().Throw<NullReferenceException>().WithMessage("PosterName cannot be null or empty");
        }


        [Fact]
        public void DefaultValidation_WithPosterSkuCodeThatsNull_ShouldThrowException()
        {
            IPosterValidator posterValidator = new PosterValidator();
            Action action = () => posterValidator.DefaultValidation(new Poster() { PosterId = 1, PosterName = "test", PosterSku = null } as Poster);
            action.Should().Throw<NullReferenceException>().WithMessage("PosterSku code cannot be null or empty");
        }


        [Fact]
        public void DefaultValidation_WithPosterSkuCodeThatsEmpty_ShouldThrowException()
        {
            IPosterValidator posterValidator = new PosterValidator();
            Action action = () => posterValidator.DefaultValidation(new Poster() { PosterId = 1, PosterName = "test", PosterSku = "" } as Poster);
            action.Should().Throw<NullReferenceException>().WithMessage("PosterSku code cannot be null or empty");
        }


        [Fact]
        public void DefaultValidation_WithPosterPathThatsNull_ShouldThrowException()
        {
            IPosterValidator posterValidator = new PosterValidator();
            Action action = () => posterValidator.DefaultValidation(new Poster() { PosterId = 1, PosterName = "test", PosterSku = "test", Path = null } as Poster);
            action.Should().Throw<NullReferenceException>().WithMessage("Poster Path cannot be null or empty");
        }


        [Fact]
        public void DefaultValidation_WithPosterPathThatsEmpty_ShouldThrowException()
        {
            IPosterValidator posterValidator = new PosterValidator();
            Action action = () => posterValidator.DefaultValidation(new Poster() { PosterId = 1, PosterName = "test", PosterSku = "test", Path = "" } as Poster);
            action.Should().Throw<NullReferenceException>().WithMessage("Poster Path cannot be null or empty");
        }


        [Fact]
        public void DefaultValidation_WithCollectionIdLessThen1_ShouldThrowException()
        {
            IPosterValidator posterValidator = new PosterValidator();
            Action action = () => posterValidator.DefaultValidation(new Poster() { PosterId = 1, PosterName = "test", PosterSku = "test", Path = "test", CollectionId = 0 } as Poster);
            action.Should().Throw<NullReferenceException>().WithMessage("Poster CollectionId cannot be less than 1");
        }
    }
}
