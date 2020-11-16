using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.Core.Helper;
using FotoFactory.CoreEntities;

namespace InfraStructure.SQLLite.Data
{
    public class DBInitialiser : IDBInitialiser
    {

        private readonly IAuthenticationHelper _authenticationHelper;

        public DBInitialiser(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }

        

        public void SeedDB(FotoFactoryContext ctx)  // Using context. Could use repository but ctx is a cleaner change tracker
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            if (ctx.Users.Any())
            {
                return;
            }

            string password = "1234";
            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashAdmin,
                out byte[] passwordSaltAdmin);

            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashUser,
                out byte[] passwordSaltUser);



//  Create Users
            List<User> users = new List<User>
            {
                new User
                {
                    Username = "admin",
                    PasswordHash = passwordHashAdmin,
                    PasswordSalt = passwordSaltAdmin,
                    IsAdmin = true
                },

                new User
                {
                    Username = "user",
                    PasswordHash = passwordHashUser,
                    PasswordSalt = passwordSaltUser,
                    IsAdmin = false
                }
            };



//  Create Tags
           
            Tag tag01 = ctx.Tags.Add(new Tag
            {
                Description = "Grøn"
            }).Entity;

            Tag tag02 = ctx.Tags.Add(new Tag
            {
            Description = "Skov"
            }).Entity;

            Tag tag03 = ctx.Tags.Add(new Tag
                {
                    Description = "Træer"
            }).Entity;

            Tag tag04 = ctx.Tags.Add(new Tag
                {
                    Description = "Søer"
            }).Entity;

            Tag tag05 = ctx.Tags.Add(new Tag
                {
                    Description = "Silkeborg"
            }).Entity;



 //  Create Sizes

            Size size01 = ctx.Sizes.Add(new Size
            {
                Dimensions = "A5 (15 x 21cm)",
                PosterPrice = 100.00,
                FramePrice = 100.00
            }).Entity;

            Size size02 = ctx.Sizes.Add(new Size
            {
                Dimensions = "A4 (21 x 29.7cm)",
                PosterPrice = 200.00,
                FramePrice = 150.00
            }).Entity;

            Size size03 = ctx.Sizes.Add(new Size
            {
                Dimensions = "A3 (29.7 x 42cm)",
                PosterPrice = 300.00,
                FramePrice = 200.00
            }).Entity;

            Size size04 = ctx.Sizes.Add(new Size
            {
                Dimensions = "A2 (42 x 59.4cm)",
                PosterPrice = 500.00,  // unsure of price. Not yet used
                FramePrice = 400.00
            }).Entity;

            Size size05 = ctx.Sizes.Add(new Size
            {
                Dimensions = "B2 (50 x 70cm)",
                PosterPrice = 550.00,
                FramePrice = 400.00
            }).Entity;

            Size size06 = ctx.Sizes.Add(new Size
            {
                Dimensions = "B1 (70 x 100cm)",
                PosterPrice = 850.00,
                FramePrice = 600.00
            }).Entity;



//  Create Posters

            Poster poster160DK = ctx.Posters.Add(new Poster
            {
                PosterName = "Rold Skov",
                PosterSku = "FF160DK",
                Path = ".../Assets/FF160DK.jpg",
                Tags = new List<Tag>{ tag01, tag02, tag03 },
                Sizes = new List<Size>{ size01, size02, size03, size05, size06 }
            }).Entity;

            Poster poster159DK = ctx.Posters.Add(new Poster
            {
                PosterName = "Skovsø",
                PosterSku = "FF159DK",
                Path = ".../Assets/FF159DK.jpg",
                Tags = new List<Tag>{ tag02, tag03, tag04 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster158DK = ctx.Posters.Add(new Poster
            {
                PosterName = "Nordskoven",
                PosterSku = "FF158DK",
                Path = ".../Assets/FF158DK.jpg",
                Tags = new List<Tag>{ tag01, tag02, tag03 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster157DK = ctx.Posters.Add(new Poster
            {
                PosterName = "Fredskov",
                PosterSku = "FF157DK",
                Path = ".../Assets/FF157DK.jpg",
                Tags = new List<Tag> { tag01, tag02, tag03 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster156DK = ctx.Posters.Add(new Poster
            {
                PosterName = "Slåensø",
                PosterSku = "FF156DK",
                Path = ".../Assets/FF156DK.jpg",
                Tags = new List<Tag> { tag01, tag02, tag04, tag05 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster155DK = ctx.Posters.Add(new Poster
            {
                PosterName = "Morgendis",
                PosterSku = "FF155DK",
                Path = ".../Assets/FF155DK.jpg",
                Tags = new List<Tag> { tag01, tag02, tag04, tag05 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster154DK = ctx.Posters.Add(new Poster
            {
                PosterName = "Nordskov",
                PosterSku = "FF154DK",
                Path = ".../Assets/FF154DK.jpg",
                Tags = new List<Tag> { tag01, tag02, tag05 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster153DK = ctx.Posters.Add(new Poster
            {
                PosterName = "Vesterskov",
                PosterSku = "FF153DK",
                Path = ".../Assets/FF153DK.jpg",
                Tags = new List<Tag> { tag01, tag02, tag05 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;



            ctx.Users.AddRange(users);
            ctx.SaveChanges();

        }

    }
}