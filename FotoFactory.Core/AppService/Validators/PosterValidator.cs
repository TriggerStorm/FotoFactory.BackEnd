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
                throw new NullReferenceException("PosterId cannot be less than 1");
            }
            if (string.IsNullOrEmpty(poster.PosterName))
            {
                throw new NullReferenceException("PosterName cannot be null or empty");
            }
            if (string.IsNullOrEmpty(poster.PosterSku))
            {
                throw new NullReferenceException("PosterSku code cannot be null or empty");
            }
            if (string.IsNullOrEmpty(poster.Path))
            {
                throw new NullReferenceException("Poster Path cannot be null or empty");
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
