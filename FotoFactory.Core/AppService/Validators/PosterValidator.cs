using System;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService.Validators
{
    public class PosterValidator : IPosterValidator
    {
        public void DefaultValidation(Poster poster)
        {
            if (poster == null)
            {
                throw new NullReferenceException("Poster cannot be null");
            }
            if (poster.PosterId < 1)
            {
                throw new NullReferenceException("Poster id cannot be less than 1");
            }
            if (string.IsNullOrEmpty(poster.PosterName))
            {
                throw new NullReferenceException("Poster name cannot be empty");
            }
            if (string.IsNullOrEmpty(poster.PosterSku))
            {
                throw new NullReferenceException("Poster SKU code cannot be empty");
            }
            if (string.IsNullOrEmpty(poster.Path))
            {
                throw new NullReferenceException("Poster path code cannot be empty");
            }
            if (poster.CollectionId < 1)
            {
                throw new NullReferenceException("Poster CollectionId cannot be less than 1");
            }
            if (poster.PosterSizes == null)
            {
                throw new NullReferenceException("Poster must have at least one size");
            }
        }
    }
}
