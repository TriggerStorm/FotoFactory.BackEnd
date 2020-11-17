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



// Create Collections

            Collection collection01 = ctx.Collections.Add(new Collection()
            {
                Name = "Denmark"
            }).Entity;

            Collection collection02 = ctx.Collections.Add(new Collection()
            {
                Name = "Faroe Islands"
            }).Entity;

            Collection collection03 = ctx.Collections.Add(new Collection()
            {
                Name = "Copenhagen"
            }).Entity;

            Collection collection04 = ctx.Collections.Add(new Collection()
            {
                Name = "Black and White"
            }).Entity;

            Collection collection05 = ctx.Collections.Add(new Collection()
            {
                Name = "Scotland"
            }).Entity;



//  Create Tags

            Tag tag01 = ctx.Tags.Add(new Tag()
            {
                Description = "Grøn"
            }).Entity;

            Tag tag02 = ctx.Tags.Add(new Tag()
            {
            Description = "Skov"
            }).Entity;

            Tag tag03 = ctx.Tags.Add(new Tag()
                {
                    Description = "Træer"
            }).Entity;

            Tag tag04 = ctx.Tags.Add(new Tag()
                {
                    Description = "Søer"
            }).Entity;

            Tag tag05 = ctx.Tags.Add(new Tag()
                {
                    Description = "Silkeborg"
            }).Entity;

            Tag tag06 = ctx.Tags.Add(new Tag()
            {
                Description = "Farøerne"
            }).Entity;

            Tag tag07 = ctx.Tags.Add(new Tag()
            {
                Description = "Havet"
            }).Entity;

            Tag tag08 = ctx.Tags.Add(new Tag()
            {
                Description = "Kyster"
            }).Entity;

            Tag tag09 = ctx.Tags.Add(new Tag()
            {
                Description = "Strand"
            }).Entity;

            Tag tag10 = ctx.Tags.Add(new Tag()
            {
                Description = "Både"
            }).Entity;

            Tag tag11 = ctx.Tags.Add(new Tag()
            {
                Description = "Sort/Hvid"
            }).Entity;

            Tag tag12 = ctx.Tags.Add(new Tag()
            {
                Description = "Klitter"
            }).Entity;

            Tag tag13 = ctx.Tags.Add(new Tag()
            {
                Description = "Bjerg"
            }).Entity;

            Tag tag14 = ctx.Tags.Add(new Tag()
            {
                Description = "Skotland"
            }).Entity;






            //  Create Sizes

            Size size01 = ctx.Sizes.Add(new Size()
            {
                Dimensions = "A5 (15 x 21cm)",
                PosterPrice = 100.00,
                FramePrice = 100.00
            }).Entity;

            Size size02 = ctx.Sizes.Add(new Size()
            {
                Dimensions = "A4 (21 x 29.7cm)",
                PosterPrice = 200.00,
                FramePrice = 150.00
            }).Entity;

            Size size03 = ctx.Sizes.Add(new Size()
            {
                Dimensions = "A3 (29.7 x 42cm)",
                PosterPrice = 300.00,
                FramePrice = 200.00
            }).Entity;

            Size size04 = ctx.Sizes.Add(new Size()
            {
                Dimensions = "A2 (42 x 59.4cm)",
                PosterPrice = 500.00,  // unsure of price. Not yet used
                FramePrice = 400.00
            }).Entity;

            Size size05 = ctx.Sizes.Add(new Size()
            {
                Dimensions = "B2 (50 x 70cm)",
                PosterPrice = 550.00,
                FramePrice = 400.00
            }).Entity;

            Size size06 = ctx.Sizes.Add(new Size()
            {
                Dimensions = "B1 (70 x 100cm)",
                PosterPrice = 850.00,
                FramePrice = 600.00
            }).Entity;



//  Create Posters

            Poster poster160DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Rold Skov",
                PosterSku = "FF160DK",
                Path = ".../Assets/FF160DK.jpg",
                Collection = 1,
                Tags = new List<Tag>{ tag01, tag02, tag03 },
                Sizes = new List<Size>{ size01, size02, size03, size05, size06 }
            }).Entity;

            Poster poster159DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Skovsø",
                PosterSku = "FF159DK",
                Path = ".../Assets/FF159DK.jpg",
                Collection = 1,
                Tags = new List<Tag>{ tag02, tag03, tag04 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster158DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Nordskoven",
                PosterSku = "FF158DK",
                Path = ".../Assets/FF158DK.jpg",
                Collection = 1,
                Tags = new List<Tag>{ tag01, tag02, tag03 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster157DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Fredskov",
                PosterSku = "FF157DK",
                Path = ".../Assets/FF157DK.jpg",
                Collection = 1,
                Tags = new List<Tag> { tag01, tag02, tag03 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster156DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Slåensø",
                PosterSku = "FF156DK",
                Path = ".../Assets/FF156DK.jpg",
                Collection = 1,
                Tags = new List<Tag> { tag01, tag02, tag04, tag05 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster155DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Morgendis",
                PosterSku = "FF155DK",
                Path = ".../Assets/FF155DK.jpg",
                Collection = 1,
                Tags = new List<Tag> { tag01, tag02, tag04, tag05 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster154DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Nordskov",
                PosterSku = "FF154DK",
                Path = ".../Assets/FF154DK.jpg",
                Collection = 1,
                Tags = new List<Tag> { tag01, tag02, tag05 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster153DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Vesterskov",
                PosterSku = "FF153DK",
                Path = ".../Assets/FF153DK.jpg",
                Collection = 1,
                Tags = new List<Tag> { tag01, tag02, tag05 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster106FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "Kyst",
                PosterSku = "FF106FO",
                Path = ".../Assets/FF106FO.jpg",
                Collection = 2,
                Tags = new List<Tag> { tag06, tag07, tag08 },
                Sizes = new List<Size> { size03, size05, size06 }
            }).Entity;

            Poster poster107FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "Kyst",
                PosterSku = "FF106FO",
                Path = ".../Assets/FF107FO.jpg",
                Collection = 2,
                Tags = new List<Tag> { tag06, tag07, tag08, tag09 },
                Sizes = new List<Size> { size03, size05, size06 }
            }).Entity;

            Poster poster101CPH = ctx.Posters.Add(new Poster()
            {
                PosterName = "Cyclen",
                PosterSku = "FF101CPH",
                Path = ".../Assets/FF101CPH.jpg",
                Collection = 3,
                Tags = new List<Tag> { tag03 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster104CPH = ctx.Posters.Add(new Poster()
            {
                PosterName = "Sosiden",
                PosterSku = "FF104CPH",
                Path = ".../Assets/FF104CPH.jpg",
                Collection = 3,
                Tags = new List<Tag> { tag03 },
                Sizes = new List<Size> { size01, size03, size05, size06 }
            }).Entity;

            Poster poster106BW = ctx.Posters.Add(new Poster()
            {
                PosterName = "Længsel",
                PosterSku = "FF106BW",
                Path = ".../Assets/FF106BW.jpg",
                Collection = 4,
                Tags = new List<Tag> { tag07, tag10, tag11 },
                Sizes = new List<Size> { size03, size05, size06 }
            }).Entity;

            Poster poster104BW = ctx.Posters.Add(new Poster()
            {
                PosterName = "Linie",
                PosterSku = "FF104BW",
                Path = ".../Assets/FF104BW.jpg",
                Collection = 4,
                Tags = new List<Tag> { tag11, tag12 },
                Sizes = new List<Size> { size03, size05, size06 }
            }).Entity;

            Poster poster104SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "The Storr",
                PosterSku = "FF104SCO",
                Path = ".../Assets/FF104SCO.jpg",
                Collection = 5,
                Tags = new List<Tag> { tag13, tag14 },
                Sizes = new List<Size> { size03, size05, size06 }
            }).Entity;

            Poster poster108SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "Black Cuillin",
                PosterSku = "FF108SCO",
                Path = ".../Assets/FF108SCO.jpg",
                Collection = 5,
                Tags = new List<Tag> { tag13, tag14, tag11 },
                Sizes = new List<Size> { size03, size05, size06 }
            }).Entity;



//  Create Frames

            Frame OAKNATURE = ctx.Frames.Add(new Frame()
            {
                FrameType = "Natural Oak",
                FrameSku = "OAKNATURE"
            }).Entity;

            Frame OAKDARK = ctx.Frames.Add(new Frame()
            {
                FrameType = "Dark Oak",
                FrameSku = "OAKDARK"
            }).Entity;

            Frame OAKBLACK = ctx.Frames.Add(new Frame()
            {
                FrameType = "Black Oak",
                FrameSku = "OAKBLACK"
            }).Entity;

            Frame OAKWHITE = ctx.Frames.Add(new Frame()
            {
                FrameType = "White Oak",
                FrameSku = "OAKWHITE"
            }).Entity;

            Frame ALUBLACK = ctx.Frames.Add(new Frame()
            {
                FrameType = "Black Aluminium",
                FrameSku = "ALUBLACK"
            }).Entity;

            Frame WHITEALU = ctx.Frames.Add(new Frame()
            {
                FrameType = "White Aluminium",
                FrameSku = "WHITEALU"
            }).Entity;




            ctx.Users.AddRange(users);
            ctx.SaveChanges();
        }

    }
}