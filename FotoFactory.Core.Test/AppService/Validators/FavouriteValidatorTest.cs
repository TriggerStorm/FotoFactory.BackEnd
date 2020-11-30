﻿using System;
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


        [Fact]
        public void DefaultValidation_WithFavouriteUserIdLessThen1_ShouldThrowException()
        {
            IFavouriteValidator posterValidator = new FavouriteValidator();
            Action action = () => posterValidator.DefaultValidation(new Favourite() { UserId = 0 } as Favourite);
            action.Should().Throw<NullReferenceException>().WithMessage("Favourite UserId cannot be less than 1");
        }


        [Fact]
        public void DefaultValidation_WithFavouriteUserIsNull_ShouldThrowException()
        {
            IFavouriteValidator posterValidator = new FavouriteValidator();
            Action action = () => posterValidator.DefaultValidation(new Favourite() { UserId = 1, User = null } as Favourite);
            action.Should().Throw<NullReferenceException>().WithMessage("Favourite User cannot be null");
        }


        [Fact]
        public void DefaultValidation_WithFavouritePosterIdLessThen1_ShouldThrowException()
        {
            IFavouriteValidator posterValidator = new FavouriteValidator();
            Action action = () => posterValidator.DefaultValidation(new Favourite() { UserId = 1,
                User = new User
                {
                    UserId = 1,
                    Username = "test"
                },
                PosterId = 0 } as Favourite);
            action.Should().Throw<NullReferenceException>().WithMessage("Favourite PosterId cannot be less than 1");
        }


        [Fact]
        public void DefaultValidation_WithFavouritePosterIdIsNull_ShouldThrowException()
        {
            IFavouriteValidator posterValidator = new FavouriteValidator();
            Action action = () => posterValidator.DefaultValidation(new Favourite()
            {
                UserId = 1,
                User = new User
                {
                    UserId = 1,
                    Username = "test"
                },
                PosterId = 1,
                Poster = null
            } as Favourite);
            action.Should().Throw<NullReferenceException>().WithMessage("Favourite Poster cannot be null");
        }
    }
}
