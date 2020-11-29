using System;
using FluentAssertions;
using Xunit;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Validators;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.Test
{
    public class FavouriteValidatorTest
    {
        [Fact]
        public void FavouriteValidator_ShouldBeOfTypeIFavouriteValidator()
        {
            new FavouriteValidator().Should().BeAssignableTo<IFavouriteValidator>();
        }


        /*   [Fact]
           public void DefaultValidation_WithPosterThatsNull_ShouldThrowExeption()
           {
               IPosterValidator posterValidator = new PosterValidator();
               Action action = () => posterValidator.DefaultValidation(null as Poster);
               action.Should().Throw<NullReferenceException>().WithMessage("Poster cannot be null");
           } */
    }
}
