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
    }
}
