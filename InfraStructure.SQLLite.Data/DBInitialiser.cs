using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.Core.Helper;
using FotoFactory.CoreEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InfraStructure.SQLLite.Data
{
    public class DBInitialiser : IDBInitialiser
    {

        private readonly IAuthenticationHelper _authenticationHelper;

        public DBInitialiser(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }



        public void
            SeedDB(FotoFactoryContext ctx) // Using context. Could use repository but ctx is a cleaner change tracker
        {
            if (ctx.Users.Any())
            {
                return;
            }




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
                PosterPrice = 500.00, // unsure of price. Not yet used
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

            ctx.SaveChanges();



//  Create Posters

            Poster poster160DK = ctx.Posters.Add(new Poster()  // TEST
            {
                PosterName = "Rold Skov",
                PosterSku = "FF160DK",
                Path = ".../Assets/FF160DK.jpg",

                Collection = 1,
               // Tags = new List<Tag> { tag01, tag02, tag03 },
              //  Sizes = new List<Size> { size01, size02, size03, size05, size06 }

            }).Entity;

            poster160DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster160DK,
                    Tag = tag01
                },
                 new PosterTag
                {
                    Poster = poster160DK,
                    Tag = tag02
                },
                   new PosterTag
                {
                    Poster = poster160DK,
                    Tag = tag03
                }
            };

            poster160DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster160DK,
                    Size = size01
                },
                 new PosterSize
                {
                    Poster = poster160DK,
                    Size = size02
                },
                   new PosterSize
                {
                    Poster = poster160DK,
                    Size = size03
                },
                   new PosterSize
                {
                    Poster = poster160DK,
                    Size = size05
                },
                   new PosterSize
                {
                    Poster = poster160DK,
                    Size = size06
                }
            };

          //  ctx.Posters.Add(poster160DK);

     
            Poster poster159DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Skovsø",
                PosterSku = "FF159DK",
                Path = ".../Assets/FF159DK.jpg",

                Collection = 1,
               //  Tags = new List<Tag>{ tag02, tag03, tag04 },
               //  Sizes = new List<Size> { size01, size03, size05, size06 }
             }).Entity;


            poster159DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster159DK,
                    Tag = tag02
                },
                 new PosterTag
                {
                    Poster = poster159DK,
                    Tag = tag03
                },
                   new PosterTag
                {
                    Poster = poster159DK,
                    Tag = tag04
                }
            };

            poster159DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster159DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster159DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster159DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster159DK,
                    Size = size06
                }
            };
           // ctx.Posters.Add(poster159DK);
           // ctx.SaveChanges();


            Poster poster158DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "Nordskoven",
                PosterSku = "FF158DK",
                Path = ".../Assets/FF158DK.jpg",

                Collection = 1,
                //  Tags = new List<Tag>{ tag01, tag02, tag03 },
                //  Sizes = new List<Size> { size01, size03, size05, size06 }

            }).Entity;

            poster158DK.PosterTags = new List<PosterTag>
            {

                new PosterTag
                {
                    Poster = poster158DK,
                    Tag = tag01
                },
                 new PosterTag
                {
                    Poster = poster158DK,
                    Tag = tag02
                },
                   new PosterTag
                {
                    Poster = poster158DK,
                    Tag = tag03
                }
            };


            poster158DK.PosterSizes = new List<PosterSize>
            {

                new PosterSize
                {
                    Poster = poster158DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster158DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster158DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster158DK,
                    Size = size06
                }
            };


            Poster poster157DK = ctx.Posters.Add(new Poster()
                {
                    PosterName = "Fredskov",
                    PosterSku = "FF157DK",
                    Path = ".../Assets/FF157DK.jpg",
                    Collection = 1,
                  //  Tags = new List<Tag> { tag01, tag02, tag03 },
                  //  Sizes = new List<Size> { size01, size03, size05, size06 }
                }).Entity;

            poster157DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster157DK,
                    Tag = tag01
                },
                 new PosterTag
                {
                    Poster = poster157DK,
                    Tag = tag02
                },
                   new PosterTag
                {
                    Poster = poster157DK,
                    Tag = tag03
                }
            };


            poster157DK.PosterSizes = new List<PosterSize>
            {

                new PosterSize
                {
                    Poster = poster157DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster157DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster157DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster157DK,
                    Size = size06
                }
            };


            Poster poster156DK = ctx.Posters.Add(new Poster()
                {
                    PosterName = "Slåensø",
                    PosterSku = "FF156DK",
                    Path = ".../Assets/FF156DK.jpg",
                    Collection = 1,
                  //  Tags = new List<Tag> { tag01, tag02, tag04, tag05 },
                  //  Sizes = new List<Size> { size01, size03, size05, size06 }
                }).Entity;

            poster156DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster156DK,
                    Tag = tag01
                },
                 new PosterTag
                {
                    Poster = poster156DK,
                    Tag = tag02
                },
                   new PosterTag
                {
                    Poster = poster156DK,
                    Tag = tag04
                },
                   new PosterTag
                {
                    Poster = poster156DK,
                    Tag = tag05
                }
            };

            poster156DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster156DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster156DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster156DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster156DK,
                    Size = size06
                }
            };


            Poster poster155DK = ctx.Posters.Add(new Poster()
                {
                    PosterName = "Morgendis",
                    PosterSku = "FF155DK",
                    Path = ".../Assets/FF155DK.jpg",
                    Collection = 1,
                  //  Tags = new List<Tag> { tag01, tag02, tag04, tag05 },
                  //  Sizes = new List<Size> { size01, size03, size05, size06 }
                }).Entity;

            poster155DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster155DK,
                    Tag = tag01
                },
                 new PosterTag
                {
                    Poster = poster155DK,
                    Tag = tag02
                },
                   new PosterTag
                {
                    Poster = poster155DK,
                    Tag = tag04
                },
                   new PosterTag
                {
                    Poster = poster155DK,
                    Tag = tag05
                }
            };

            poster155DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster155DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster155DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster155DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster155DK,
                    Size = size06
                }
            };


            Poster poster154DK = ctx.Posters.Add(new Poster()
                {
                    PosterName = "Nordskov",
                    PosterSku = "FF154DK",
                    Path = ".../Assets/FF154DK.jpg",
                    Collection = 1,
                  //  Tags = new List<Tag> { tag01, tag02, tag05 },
                  //  Sizes = new List<Size> { size01, size03, size05, size06 }
                }).Entity;

            poster154DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster154DK,
                    Tag = tag01
                },
                 new PosterTag
                {
                    Poster = poster154DK,
                    Tag = tag02
                },
                   new PosterTag
                {
                    Poster = poster154DK,
                    Tag = tag05
                }
            };

            poster154DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster154DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster154DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster154DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster154DK,
                    Size = size06
                }
            };


            Poster poster153DK = ctx.Posters.Add(new Poster()
                {
                    PosterName = "Vesterskov",
                    PosterSku = "FF153DK",
                    Path = ".../Assets/FF153DK.jpg",
                    Collection = 1,
                  //  Tags = new List<Tag> { tag01, tag02, tag05 },
                  //  Sizes = new List<Size> { size01, size03, size05, size06 }
                }).Entity;

            poster153DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster153DK,
                    Tag = tag01
                },
                 new PosterTag
                {
                    Poster = poster153DK,
                    Tag = tag02
                },
                   new PosterTag
                {
                    Poster = poster153DK,
                    Tag = tag05
                }
            };

            poster153DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster153DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster153DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster153DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster153DK,
                    Size = size06
                }
            };


            Poster poster106FO = ctx.Posters.Add(new Poster()
                {
                    PosterName = "Kyst",
                    PosterSku = "FF106FO",
                    Path = ".../Assets/FF106FO.jpg",
                    Collection = 2,
                  //  Tags = new List<Tag> { tag06, tag07, tag08 },
                  //  Sizes = new List<Size> { size03, size05, size06 }
                }).Entity;

            poster106FO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster106FO,
                    Tag = tag06
                },
                 new PosterTag
                {
                    Poster = poster106FO,
                    Tag = tag07
                },
                   new PosterTag
                {
                    Poster = poster106FO,
                    Tag = tag08
                }
            };

            poster106FO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster106FO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster106FO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster106FO,
                    Size = size06
                }
            };


            Poster poster107FO = ctx.Posters.Add(new Poster()
                {
                    PosterName = "NordAtlanten",
                    PosterSku = "FF107FO",
                    Path = ".../Assets/FF107FO.jpg",
                    Collection = 2,
                  //  Tags = new List<Tag> { tag06, tag07, tag08, tag09 },
                  //  Sizes = new List<Size> { size03, size05, size06 }
                }).Entity;

            poster107FO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster107FO,
                    Tag = tag06
                },
                 new PosterTag
                {
                    Poster = poster107FO,
                    Tag = tag07
                },
                  new PosterTag
                {
                    Poster = poster107FO,
                    Tag = tag08
                },
                   new PosterTag
                {
                    Poster = poster107FO,
                    Tag = tag09
                }
            };

            poster107FO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster107FO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster107FO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster107FO,
                    Size = size06
                }
            };


            Poster poster101CPH = ctx.Posters.Add(new Poster()
                {
                    PosterName = "Cyclen",
                    PosterSku = "FF101CPH",
                    Path = ".../Assets/FF101CPH.jpg",
                    Collection = 3,
                  //  Tags = new List<Tag> { tag03 },
                  //  Sizes = new List<Size> { size01, size03, size05, size06 }
                }).Entity;

            poster101CPH.PosterTags = new List<PosterTag>
            {
                   new PosterTag
                {
                    Poster = poster101CPH,
                    Tag = tag03
                }
            };

            poster101CPH.PosterSizes = new List<PosterSize>
            {
                  new PosterSize
                {
                    Poster = poster101CPH,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster101CPH,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster101CPH,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster101CPH,
                    Size = size06
                }
            };


            Poster poster104CPH = ctx.Posters.Add(new Poster()
                {
                    PosterName = "Sosiden",
                    PosterSku = "FF104CPH",
                    Path = ".../Assets/FF104CPH.jpg",
                    Collection = 3,
                  //  Tags = new List<Tag> { tag03 },
                  //  Sizes = new List<Size> { size01, size03, size05, size06 }
                }).Entity;

            poster104CPH.PosterTags = new List<PosterTag>
            {
                   new PosterTag
                {
                    Poster = poster104CPH,
                    Tag = tag03
                }
            };

            poster104CPH.PosterSizes = new List<PosterSize>
            {
                  new PosterSize
                {
                    Poster = poster104CPH,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster104CPH,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster104CPH,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster104CPH,
                    Size = size06
                }
            };


            Poster poster106BW = ctx.Posters.Add(new Poster()
                {
                    PosterName = "Længsel",
                    PosterSku = "FF106BW",
                    Path = ".../Assets/FF106BW.jpg",
                    Collection = 4,
                  //  Tags = new List<Tag> { tag07, tag10, tag11 },
                  //  Sizes = new List<Size> { size03, size05, size06 }
                }).Entity;

            poster106BW.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster106BW,
                    Tag = tag07
                },
                 new PosterTag
                {
                    Poster = poster106BW,
                    Tag = tag10
                },
                   new PosterTag
                {
                    Poster = poster106BW,
                    Tag = tag11
                }
            };

            poster106BW.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster106BW,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster106BW,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster106BW,
                    Size = size06
                }
            };


            Poster poster104BW = ctx.Posters.Add(new Poster()
            {
                PosterName = "Linie",
                PosterSku = "FF104BW",
                Path = ".../Assets/FF104BW.jpg",
                Collection = 4,
                //  Tags = new List<Tag> { tag11, tag12 },
                //  Sizes = new List<Size> { size03, size05, size06 }

            }).Entity;

            poster104BW.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster104BW,
                    Tag = tag11
                },
                   new PosterTag
                {
                    Poster = poster104BW,
                    Tag = tag12
                }
            };

            poster104BW.PosterSizes = new List<PosterSize>
            {

                new PosterSize
                {
                    Poster = poster104BW,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster104BW,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster104BW,
                    Size = size06
                }
            };


            Poster poster104SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "The Storr",
                PosterSku = "FF104SCO",
                Path = ".../Assets/FF104SCO.jpg",
                Collection = 5,
                //  Tags = new List<Tag> { tag13, tag14 },
                //  Sizes = new List<Size> { size03, size05, size06 }

            }).Entity;

            poster104SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster104SCO,
                    Tag = tag13
                },
                   new PosterTag
                {
                    Poster = poster104SCO,
                    Tag = tag14
                }
            };

            poster104SCO.PosterSizes = new List<PosterSize>
            {

                new PosterSize
                {
                    Poster = poster104SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster104SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster104SCO,
                    Size = size06
                }
            };


            Poster poster108SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "Black Cuillin",
                PosterSku = "FF108SCO",
                Path = ".../Assets/FF108SCO.jpg",
                Collection = 5,
              //  Tags = new List<Tag> { tag13, tag14, tag11 },
              //  Sizes = new List<Size> { size03, size05, size06 }

            }).Entity;

            poster108SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster108SCO,
                    Tag = tag13
                },
                 new PosterTag
                {
                    Poster = poster108SCO,
                    Tag = tag14
                },
                   new PosterTag
                {
                    Poster = poster108SCO,
                    Tag = tag11
                }
            };

            poster108SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster108SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster108SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster108SCO,
                    Size = size06
                }
            };


//  Create Frames

            Frame NOFRAME = ctx.Frames.Add(new Frame
            {
                FrameType = "NOFRAME",
                FrameSku = "NOFRAME"
            }).Entity;


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


// Create WorkSpacePoster

            WorkSpacePoster workSpacePoster1 = ctx.WorkSpacePoster.Add(new WorkSpacePoster
            {

                Poster = poster160DK,
                Frame = OAKNATURE, // add frame id here ? or just description
                XPos = 0,
                YPos = 0,
                Size = size01,

            }).Entity;

            WorkSpacePoster workSpacePoster2 = ctx.WorkSpacePoster.Add(new WorkSpacePoster
            {
                Poster = poster159DK,
                Frame = OAKBLACK,
                XPos = 700,
                YPos = 800,
                Size = size05,

            }).Entity;

            WorkSpacePoster workSpacePoster3 = ctx.WorkSpacePoster.Add(new WorkSpacePoster
            {
                Poster = poster155DK,
                Frame = WHITEALU,
                XPos = 650,
                YPos = 550,
                Size = size03,
            }).Entity;

            WorkSpacePoster workSpacePoster4 = ctx.WorkSpacePoster.Add(new WorkSpacePoster
            {
                Poster = poster155DK,
                Frame = ALUBLACK,
                XPos = 250,
                YPos = 300,
                Size = size06,
            }).Entity;

            WorkSpacePoster workSpacePoster5 = ctx.WorkSpacePoster.Add(new WorkSpacePoster
            {
                Poster = poster159DK,
                Frame = NOFRAME,
                XPos = 150,
                YPos = 100,
                Size = size04,

            }).Entity;

            WorkSpacePoster workSpacePoster6 = ctx.WorkSpacePoster.Add(new WorkSpacePoster
            {
                Poster = poster159DK,
                Frame = OAKDARK,
                XPos = 400,
                YPos = 500,
                Size = size03,

            }).Entity;


            // create Users

            string password = "1234";
            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashAdmin,
                out byte[] passwordSaltAdmin);

            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashUser,
                out byte[] passwordSaltUser);

            User user1 = new User()
            {
                Username = "admin",
                PasswordHash = passwordHashAdmin,
                PasswordSalt = passwordSaltAdmin,
                IsAdmin = true,
                WorkSpaces = new List<WorkSpace> { }
            };

            User user2 = new User()
            {
                Username = "user",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = false,
                WorkSpaces = new List<WorkSpace> { }
            };
            ctx.Users.Add(user1);
            ctx.Users.Add(user2);
            // Create WorkSpace

            WorkSpace workSpace1 = ctx.WorkSpace.Add(new WorkSpace
            {
                Name = "LivingRoom",
                WorkSpacePosters = new List<WorkSpacePoster>
                    {workSpacePoster1, workSpacePoster4, workSpacePoster2, workSpacePoster3},
                User = user1
            }).Entity;

            WorkSpace workSpace2 = ctx.WorkSpace.Add(new WorkSpace
            {
                Name = "Bedroom",
                WorkSpacePosters = new List<WorkSpacePoster> { workSpacePoster4, workSpacePoster5, workSpacePoster6 },
                User = user1
            }).Entity;

            WorkSpace workSpace3 = ctx.WorkSpace.Add(new WorkSpace
            {
                Name = "MasterBedroom",
                WorkSpacePosters = new List<WorkSpacePoster> { workSpacePoster2, workSpacePoster3, workSpacePoster4 },
                User = user2
            }).Entity;

            WorkSpace workSpace4 = ctx.WorkSpace.Add(new WorkSpace
            {
                Name = "Kitchen",
                WorkSpacePosters = new List<WorkSpacePoster> { },
                User = user2
            }).Entity;

            WorkSpace workSpace5 = ctx.WorkSpace.Add(new WorkSpace
            {
                Name = "Staircase",
                WorkSpacePosters = new List<WorkSpacePoster> { workSpacePoster4, workSpacePoster1, workSpacePoster3 },
                User =user1
            }).Entity;

            user1.WorkSpaces.Add(workSpace1);
            user1.WorkSpaces.Add(workSpace2);
            user1.WorkSpaces.Add(workSpace5);
            user2.WorkSpaces.Add(workSpace3);
            user2.WorkSpaces.Add(workSpace4);

            ctx.SaveChanges();
        }
    }
}


        

    
