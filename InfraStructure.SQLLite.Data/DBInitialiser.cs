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
                Description = "Green"
            }).Entity;

            Tag tag02 = ctx.Tags.Add(new Tag()
            {
                Description = "Forest"
            }).Entity;


            Tag tag03 = ctx.Tags.Add(new Tag()
                {
                    Description = "Trees"
            }).Entity;

            Tag tag04 = ctx.Tags.Add(new Tag()
                {
                    Description = "Lake"
            }).Entity;

            Tag tag05 = ctx.Tags.Add(new Tag()
                {
                    Description = "Silkeborg"

            }).Entity;

            Tag tag06 = ctx.Tags.Add(new Tag()
            {
                Description = "Faroe"
            }).Entity;

            Tag tag07 = ctx.Tags.Add(new Tag()
            {
                Description = "Harbour"
            }).Entity;

            Tag tag08 = ctx.Tags.Add(new Tag()
            {
                Description = "Coast"
            }).Entity;

            Tag tag09 = ctx.Tags.Add(new Tag()
            {
                Description = "Beach"
            }).Entity;

            Tag tag10 = ctx.Tags.Add(new Tag()
            {
                Description = "Boats"
            }).Entity;

            Tag tag11 = ctx.Tags.Add(new Tag()
            {
                Description = "Black/White"
            }).Entity;

            Tag tag12 = ctx.Tags.Add(new Tag()
            {
                Description = "Dunes"
            }).Entity;

            Tag tag13 = ctx.Tags.Add(new Tag()
            {
                Description = "Mountains"
            }).Entity;

            Tag tag14 = ctx.Tags.Add(new Tag()
            {
                Description = "Scotland"
            }).Entity;

            Tag tag15 = ctx.Tags.Add(new Tag()
            {
                Description = "Aerø"
            }).Entity;

            Tag tag16 = ctx.Tags.Add(new Tag()
            {
                Description = "Sea"
            }).Entity;

            Tag tag17 = ctx.Tags.Add(new Tag()
            {
                Description = "Anholt"
            }).Entity;

            Tag tag18 = ctx.Tags.Add(new Tag()
            {
                Description = "Lighthouse"
            }).Entity;

            Tag tag19 = ctx.Tags.Add(new Tag()
            {
                Description = "Sunset"
            }).Entity;

            Tag tag20 = ctx.Tags.Add(new Tag()
            {
                Description = "Mist"
            }).Entity;

            Tag tag21 = ctx.Tags.Add(new Tag()
            {
                Description = "Cabin"
            }).Entity;

            Tag tag22 = ctx.Tags.Add(new Tag()
            {
                Description = "Urban"
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

            Poster poster160DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "ROLD SKOV",
                PosterSku = "FF160DK",
                Path = "/assets/denmark-posters/FF160DK.png",
                CollectionId = 1,

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


            Poster poster159DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "FOREST LAKE", // "Skovsø"
                PosterSku = "FF159DK",
                Path = "/assets/denmark-posters/FF159DK.png",
                CollectionId = 1,
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


            Poster poster158DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "NATURAL FOREST", // "Nordskoven"
                PosterSku = "FF158DK",
                Path = "/assets/denmark-posters/FF158DK.png",
                CollectionId = 1,

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
                    PosterName = "FOREST RESERVE", // Fredskov"
                    PosterSku = "FF157DK",
                    Path = "/assets/denmark-posters/FF157DK.png",
                    CollectionId = 1,
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
                    PosterName = "SLÅENSØ",
                    PosterSku = "FF156DK",
                    Path = "/assets/denmark-posters/FF156DK.png",
                    CollectionId = 1,
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
                    PosterName = "MIST", // Morgendis"
                    PosterSku = "FF155DK",
                    Path = "/assets/denmark-posters/FF155DK.png",
                    CollectionId = 1,
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
                    PosterName = "NORDSKOV",
                    PosterSku = "FF154DK",
                    Path = "/assets/denmark-posters/FF154DK.png",
                    CollectionId = 1,
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
                    PosterName = "VESTERSKOV",
                    PosterSku = "FF153DK",
                    Path = "/assets/denmark-posters/FF153DK.png",
                    CollectionId = 1,
                }).Entity;

            poster153DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster153DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster153DK,
                    Tag = tag03
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


            Poster poster152DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "ØRNSØ",
                PosterSku = "FF152DK",
                Path = "/assets/denmark-posters/FF152DK.png",
                CollectionId = 1,
            }).Entity;

            poster152DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster152DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster152DK,
                    Tag = tag04
                },
                new PosterTag
                {
                    Poster = poster152DK,
                    Tag = tag05
                }
            };

            poster152DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster152DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster152DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster152DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster152DK,
                    Size = size06
                }
            };


            Poster poster151DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "LAKE ALMIND",
                PosterSku = "FF151DK",
                Path = "/assets/denmark-posters/FF151DK.png",
                CollectionId = 1,
            }).Entity;

            poster151DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster151DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster151DK,
                    Tag = tag04
                },
                new PosterTag
                {
                    Poster = poster151DK,
                    Tag = tag05
                }
            };

            poster151DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster151DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster151DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster151DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster151DK,
                    Size = size06
                }
            };


            Poster poster150DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "STOVBJERG",
                PosterSku = "FF150DK",
                Path = "/assets/denmark-posters/FF150DK.png",
                CollectionId = 1,
            }).Entity;

            poster150DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster150DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster150DK,
                    Tag = tag13
                },
                new PosterTag
                {
                    Poster = poster150DK,
                    Tag = tag05
                }
            };

            poster150DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster150DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster150DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster150DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster150DK,
                    Size = size06
                }
            };


            Poster poster149DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BEACH HOUSES",
                PosterSku = "FF149DK",
                Path = "/assets/denmark-posters/FF149DK.png",
                CollectionId = 1,
            }).Entity;

            poster149DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster149DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster149DK,
                    Tag = tag15
                },
                new PosterTag
                {
                    Poster = poster149DK,
                    Tag = tag16
                }
            };

            poster149DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster149DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster149DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster149DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster149DK,
                    Size = size06
                }
            };


            Poster poster148DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BATHING HUTS",
                PosterSku = "FF148DK",
                Path = "/assets/denmark-posters/FF148DK.png",
                CollectionId = 1,
            }).Entity;

            poster148DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster148DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster148DK,
                    Tag = tag15
                },
                new PosterTag
                {
                    Poster = poster148DK,
                    Tag = tag16
                }
            };

            poster148DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster148DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster148DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster148DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster148DK,
                    Size = size06
                }
            };


            Poster poster147DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "VODERUP CLIFF",
                PosterSku = "FF147DK",
                Path = "/assets/denmark-posters/FF147DK.png",
                CollectionId = 1,
            }).Entity;

            poster147DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster147DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster147DK,
                    Tag = tag15
                },
                new PosterTag
                {
                    Poster = poster147DK,
                    Tag = tag16
                }
            };

            poster147DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster147DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster147DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster147DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster147DK,
                    Size = size06
                }
            };


            Poster poster146DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "HALENS JETTY",
                PosterSku = "FF146DK",
                Path = "/assets/denmark-posters/FF146DK.png",
                CollectionId = 1,
            }).Entity;

            poster146DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster146DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster146DK,
                    Tag = tag15
                },
                new PosterTag
                {
                    Poster = poster146DK,
                    Tag = tag16
                }
            };

            poster146DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster146DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster146DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster146DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster146DK,
                    Size = size06
                }
            };


            Poster poster145DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "MARSTAL BEACH",
                PosterSku = "FF145DK",
                Path = "/assets/denmark-posters/FF145DK.png",
                CollectionId = 1,
            }).Entity;

            poster145DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster145DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster145DK,
                    Tag = tag15
                },
                new PosterTag
                {
                    Poster = poster145DK,
                    Tag = tag16
                }
            };

            poster145DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster145DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster145DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster145DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster145DK,
                    Size = size06
                }
            };


            Poster poster139DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "DESERT",
                PosterSku = "FF139DK",
                Path = "/assets/denmark-posters/FF139DK.png",
                CollectionId = 1,
            }).Entity;

            poster139DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster139DK,
                    Tag = tag17
                },
                new PosterTag
                {
                    Poster = poster139DK,
                    Tag = tag16
                }
            };

            poster139DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster139DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster139DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster139DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster139DK,
                    Size = size06
                }
            };


            Poster poster140DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "ANHOLT",
                PosterSku = "FF140DK",
                Path = "/assets/denmark-posters/FF140DK.png",
                CollectionId = 1,
            }).Entity;

            poster140DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster140DK,
                    Tag = tag17
                },
                new PosterTag
                {
                    Poster = poster140DK,
                    Tag = tag18
                }
            };

            poster140DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster140DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster140DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster140DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster140DK,
                    Size = size06
                }
            };


            Poster poster141DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "LIGHTHOUSE",
                PosterSku = "FF141DK",
                Path = "/assets/denmark-posters/FF141DK.png",
                CollectionId = 1,
            }).Entity;

            poster141DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster141DK,
                    Tag = tag17
                },
                new PosterTag
                {
                    Poster = poster141DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster141DK,
                    Tag = tag18
                },
                new PosterTag
                {
                    Poster = poster141DK,
                    Tag = tag16
                }
            };

            poster141DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster141DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster141DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster141DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster141DK,
                    Size = size06
                }
            };


            Poster poster142DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "THE BAY",
                PosterSku = "FF142DK",
                Path = "/assets/denmark-posters/FF142DK.png",
                CollectionId = 1,
            }).Entity;

            poster142DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster142DK,
                    Tag = tag17
                },
                new PosterTag
                {
                    Poster = poster142DK,
                    Tag = tag09
                },
                new PosterTag
                {
                    Poster = poster142DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster142DK,
                    Tag = tag16
                }
            };

            poster142DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster142DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster142DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster142DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster142DK,
                    Size = size06
                }
            };


            Poster poster143DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "TURQUOISE WATER",
                PosterSku = "FF143DK",
                Path = "/assets/denmark-posters/FF143DK.png",
                CollectionId = 1,
            }).Entity;

            poster143DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster143DK,
                    Tag = tag17
                },
                 new PosterTag
                {
                    Poster = poster143DK,
                    Tag = tag09
                },
                 new PosterTag
                {
                    Poster = poster143DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster143DK,
                    Tag = tag16
                }
            };

            poster143DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster143DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster143DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster143DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster143DK,
                    Size = size06
                }
            };


            Poster poster144DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "CAMPING",
                PosterSku = "FF144DK",
                Path = "/assets/denmark-posters/FF144DK.png",
                CollectionId = 1,
            }).Entity;

            poster144DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster144DK,
                    Tag = tag17
                },
                new PosterTag
                {
                    Poster = poster144DK,
                    Tag = tag09
                },
                new PosterTag
                {
                    Poster = poster144DK,
                    Tag = tag16
                }
            };

            poster144DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster144DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster144DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster144DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster144DK,
                    Size = size06
                }
            };


            Poster poster138DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "TISVILDELEJE BEACH",
                PosterSku = "FF138DK",
                Path = "/assets/denmark-posters/FF138DK.png",
                CollectionId = 1,
            }).Entity;

            poster138DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster138DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster138DK,
                    Tag = tag01
                },
                new PosterTag
                {
                    Poster = poster138DK,
                    Tag = tag16
                }
            };

            poster138DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster138DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster138DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster138DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster138DK,
                    Size = size06
                }
            };


            Poster poster137DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BREAKWATERS",
                PosterSku = "FF137DK",
                Path = "/assets/denmark-posters/FF137DK.png",
                CollectionId = 1,
            }).Entity;

            poster137DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster137DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster137DK,
                    Tag = tag01
                },
                new PosterTag
                {
                    Poster = poster137DK,
                    Tag = tag16
                }
            };

            poster137DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster137DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster137DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster137DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster137DK,
                    Size = size06
                }
            };


            Poster poster133DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "TISVILDE HEGN",
                PosterSku = "FF133DK",
                Path = "/assets/denmark-posters/FF133DK.png",
                CollectionId = 1,
            }).Entity;

            poster133DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster133DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster133DK,
                    Tag = tag03
                }
            };

            poster133DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster133DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster133DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster133DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster133DK,
                    Size = size06
                }
            };


            Poster poster136DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "COLD HAWAII - PINK",
                PosterSku = "FF136DK",
                Path = "/assets/denmark-posters/FF136DK.png",
                CollectionId = 1,
            }).Entity;

            poster136DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster136DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster136DK,
                    Tag = tag16
                },
                new PosterTag
                {
                    Poster = poster136DK,
                    Tag = tag19
                }
            };

            poster136DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster136DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster136DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster136DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster136DK,
                    Size = size06
                }
            };


            Poster poster135DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "COLD HAWAII - BLUE",
                PosterSku = "FF135DK",
                Path = "/assets/denmark-posters/FF135DK.png",
                CollectionId = 1,
            }).Entity;

            poster135DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster135DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster135DK,
                    Tag = tag16
                },
                new PosterTag
                {
                    Poster = poster135DK,
                    Tag = tag19
                }
            };

            poster135DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster135DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster135DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster135DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster135DK,
                    Size = size06
                }
            };


            Poster poster134DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "GREEN DUNES",
                PosterSku = "FF134DK",
                Path = "/assets/denmark-posters/FF134DK.png",
                CollectionId = 1,
            }).Entity;

            poster134DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster134DK,
                    Tag = tag12
                },
                new PosterTag
                {
                    Poster = poster134DK,
                    Tag = tag01
                },
                new PosterTag
                {
                    Poster = poster134DK,
                    Tag = tag16
                }
            };

            poster134DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster134DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster134DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster134DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster134DK,
                    Size = size06
                }
            };


            Poster poster132DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "STAIRS",
                PosterSku = "FF132DK",
                Path = "/assets/denmark-posters/FF132DK.png",
                CollectionId = 1,
            }).Entity;

            poster132DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster132DK,
                    Tag = tag09
                },
                new PosterTag
                {
                    Poster = poster132DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster132DK,
                    Tag = tag16
                }
            };

            poster132DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster132DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster132DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster132DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster132DK,
                    Size = size06
                }
            };


            Poster poster131DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BEACH POSTER",
                PosterSku = "FF131DK",
                Path = "/assets/denmark-posters/FF131DK.png",
                CollectionId = 1,
            }).Entity;

            poster131DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster131DK,
                    Tag = tag09
                },
                new PosterTag
                {
                    Poster = poster131DK,
                    Tag = tag16
                }
            };

            poster131DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster131DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster131DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster131DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster131DK,
                    Size = size06
                }
            };


            Poster poster130DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "PINE FOREST",
                PosterSku = "FF130DK",
                Path = "/assets/denmark-posters/FF130DK.png",
                CollectionId = 1,
            }).Entity;

            poster130DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster130DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster130DK,
                    Tag = tag20
                },
                new PosterTag
                {
                    Poster = poster130DK,
                    Tag = tag03
                }
            };

            poster130DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster130DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster130DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster130DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster130DK,
                    Size = size06
                }
            };


            Poster poster129DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "LANGELAND",
                PosterSku = "FF129DK",
                Path = "/assets/denmark-posters/FF129DK.png",
                CollectionId = 1,
            }).Entity;

            poster129DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster129DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster129DK,
                    Tag = tag16
                },
                new PosterTag
                {
                    Poster = poster129DK,
                    Tag = tag03
                }
            };

            poster129DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster129DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster129DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster129DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster129DK,
                    Size = size06
                }
            };


            Poster poster128DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "GLÆNØ",
                PosterSku = "FF128DK",
                Path = "/assets/denmark-posters/FF128DK.png",
                CollectionId = 1,
            }).Entity;

            poster128DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster128DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster128DK,
                    Tag = tag16
                },
                new PosterTag
                {
                    Poster = poster128DK,
                    Tag = tag19
                }
            };

            poster128DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster128DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster128DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster128DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster128DK,
                    Size = size06
                }
            };


            Poster poster127DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "SVINKLØV",
                PosterSku = "FF127DK",
                Path = "/assets/denmark-posters/FF127DK.png",
                CollectionId = 1,
            }).Entity;

            poster127DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster127DK,
                    Tag = tag08
                }
            };

            poster127DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster127DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster127DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster127DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster127DK,
                    Size = size06
                }
            };


            Poster poster125DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "TORNBY BEACH",
                PosterSku = "FF125DK",
                Path = "/assets/denmark-posters/FF125DK.png",
                CollectionId = 1,
            }).Entity;

            poster125DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster125DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster125DK,
                    Tag = tag16
                }
            };

            poster125DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster125DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster125DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster125DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster125DK,
                    Size = size06
                }
            };


            Poster poster126DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BEACH AT HIRTSHALS",
                PosterSku = "FF126DK",
                Path = "/assets/denmark-posters/FF126DK.png",
                CollectionId = 1,
            }).Entity;

            poster126DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster126DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster126DK,
                    Tag = tag16
                }
            };

            poster126DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster126DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster126DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster126DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster126DK,
                    Size = size06
                }
            };


            Poster poster123DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "RUBJERG KNUDE",
                PosterSku = "FF123DK",
                Path = "/assets/denmark-posters/FF123DK.png",
                CollectionId = 1,
            }).Entity;

            poster123DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster123DK,
                    Tag = tag08
                },
                 new PosterTag
                {
                    Poster = poster123DK,
                    Tag = tag12
                },
                new PosterTag
                {
                    Poster = poster123DK,
                    Tag = tag16
                }
            };

            poster123DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster123DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster123DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster123DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster123DK,
                    Size = size06
                }
            };


            Poster poster124DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "STEVNS KLINT",
                PosterSku = "FF124DK",
                Path = "/assets/denmark-posters/FF124DK.png",
                CollectionId = 1,
            }).Entity;

            poster124DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster124DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster124DK,
                    Tag = tag16
                }
            };

            poster124DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster124DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster124DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster124DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster124DK,
                    Size = size06
                }
            };


            Poster poster122DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "DUNES AT FANØ",
                PosterSku = "FF122DK",
                Path = "/assets/denmark-posters/FF122DK.png",
                CollectionId = 1,
            }).Entity;

            poster122DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster122DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster122DK,
                    Tag = tag12
                }
            };

            poster122DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster122DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster122DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster122DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster122DK,
                    Size = size06
                }
            };


            Poster poster121DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BICYCLE PATH AT FANØ",
                PosterSku = "FF121DK",
                Path = "/assets/denmark-posters/FF121DK.png",
                CollectionId = 1,
            }).Entity;

            poster121DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster121DK,
                    Tag = tag12
                }
            };

            poster121DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster121DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster121DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster121DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster121DK,
                    Size = size06
                }
            };


            Poster poster118DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BEECH FOREST",
                PosterSku = "FF118DK",
                Path = "/assets/denmark-posters/FF118DK.png",
                CollectionId = 1,
            }).Entity;

            poster118DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster118DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster118DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster118DK,
                    Tag = tag03
                }
            };

            poster118DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster118DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster118DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster118DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster118DK,
                    Size = size06
                }
            };


            Poster poster119DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BEECH TREE",
                PosterSku = "FF119DK",
                Path = "/assets/denmark-posters/FF119DK.png",
                CollectionId = 1,
            }).Entity;

            poster119DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster119DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster119DK,
                    Tag = tag03
                }
            };

            poster119DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster119DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster119DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster119DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster119DK,
                    Size = size06
                }
            };


            Poster poster120DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "MØNS KLINT",
                PosterSku = "FF120DK",
                Path = "/assets/denmark-posters/FF120DK.png",
                CollectionId = 1,
            }).Entity;

            poster120DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster120DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster120DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster120DK,
                    Tag = tag16
                }
            };

            poster120DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster120DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster120DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster120DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster120DK,
                    Size = size06
                }
            };


            Poster poster117DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "LØKKEN",
                PosterSku = "FF117DK",
                Path = "/assets/denmark-posters/FF117DK.png",
                CollectionId = 1,
            }).Entity;

            poster117DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster117DK,
                    Tag = tag09
                },
                new PosterTag
                {
                    Poster = poster117DK,
                    Tag = tag21
                }
            };

            poster117DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster117DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster117DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster117DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster117DK,
                    Size = size06
                }
            };


            Poster poster116DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "KOBBE RIVER",
                PosterSku = "FF116DK",
                Path = "/assets/denmark-posters/FF116DK.png",
                CollectionId = 1,
            }).Entity;

            poster116DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster116DK,
                    Tag = tag02
                }
            };

            poster116DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster116DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster116DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster116DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster116DK,
                    Size = size06
                }
            };


            Poster poster115DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "EKKODALEN",
                PosterSku = "FF115DK",
                Path = "/assets/denmark-posters/FF115DK.png",
                CollectionId = 1,
            }).Entity;

            poster115DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster115DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster115DK,
                    Tag = tag03
                }
            };

            poster115DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster115DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster115DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster115DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster115DK,
                    Size = size06
                }
            };


            Poster poster114DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "HELLIGDOMSKLIPPERNE",
                PosterSku = "FF114DK",
                Path = "/assets/denmark-posters/FF114DK.png",
                CollectionId = 1,
            }).Entity;

            poster114DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster114DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster114DK,
                    Tag = tag16
                },
                new PosterTag
                {
                    Poster = poster114DK,
                    Tag = tag19
                }
            };

            poster114DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster114DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster114DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster114DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster114DK,
                    Size = size06
                }
            };


            Poster poster113DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BLOKHUS BEACH",
                PosterSku = "FF113DK",
                Path = "/assets/denmark-posters/FF113DK.png",
                CollectionId = 1,
            }).Entity;

            poster113DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster113DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster113DK,
                    Tag = tag16
                }
            };

            poster113DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster113DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster113DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster113DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster113DK,
                    Size = size06
                }
            };


            Poster poster112DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "A JETTY AT BALLEN BEACH",
                PosterSku = "FF112DK",
                Path = "/assets/denmark-posters/FF112DK.png",
                CollectionId = 1,
            }).Entity;

            poster112DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster112DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster112DK,
                    Tag = tag16
                }
            };

            poster112DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster112DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster112DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster112DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster112DK,
                    Size = size06
                }
            };


            Poster poster111DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "SUNSET",
                PosterSku = "FF111DK",
                Path = "/assets/denmark-posters/FF111DK.png",
                CollectionId = 1,
            }).Entity;

            poster111DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster111DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster111DK,
                    Tag = tag19
                }
            };

            poster111DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster111DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster111DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster111DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster111DK,
                    Size = size06
                }
            };


            Poster poster110DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BOATS",
                PosterSku = "FF110DK",
                Path = "/assets/denmark-posters/FF110DK.png",
                CollectionId = 1,
            }).Entity;

            poster110DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster110DK,
                    Tag = tag10
                },
                new PosterTag
                {
                    Poster = poster110DK,
                    Tag = tag16
                }
            };

            poster110DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster110DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster110DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster110DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster110DK,
                    Size = size06
                }
            };


            Poster poster109DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "SLETTESTRAND",
                PosterSku = "FF109DK",
                Path = "/assets/denmark-posters/FF109DK.png",
                CollectionId = 1,
            }).Entity;

            poster109DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster109DK,
                    Tag = tag10
                },
                new PosterTag
                {
                    Poster = poster109DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster109DK,
                    Tag = tag16
                }
            };

            poster109DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster109DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster109DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster109DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster109DK,
                    Size = size06
                }
            };


            Poster poster108DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "THORUP STRAND",
                PosterSku = "FF108DK",
                Path = "/assets/denmark-posters/FF108DK.png",
                CollectionId = 1,
            }).Entity;

            poster108DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster108DK,
                    Tag = tag10
                },
                new PosterTag
                {
                    Poster = poster108DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster108DK,
                    Tag = tag09
                }
            };

            poster108DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster108DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster108DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster108DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster108DK,
                    Size = size06
                }
            };


            Poster poster107DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "THE SEA AT SKAGEN",
                PosterSku = "FF107DK",
                Path = "/assets/denmark-posters/FF107DK.png",
                CollectionId = 1,
            }).Entity;

            poster107DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster107DK,
                    Tag = tag16
                }
            };

            poster107DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster107DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster107DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster107DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster107DK,
                    Size = size06
                }
            };


            Poster poster106DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "SKAGEN’S DUNES",
                PosterSku = "FF106DK",
                Path = "/assets/denmark-posters/FF106DK.png",
                CollectionId = 1,
            }).Entity;

            poster106DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster106DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster106DK,
                    Tag = tag12
                },
                new PosterTag
                {
                    Poster = poster106DK,
                    Tag = tag16
                }
            };

            poster106DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster106DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster106DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster106DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster106DK,
                    Size = size06
                }
            };


            Poster poster105DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "TRACKS ON THE BEACH",
                PosterSku = "FF105DK",
                Path = "/assets/denmark-posters/FF105DK.png",
                CollectionId = 1,
            }).Entity;

            poster105DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster105DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster105DK,
                    Tag = tag09
                }
            };

            poster105DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster105DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster105DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster105DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster105DK,
                    Size = size06
                }
            };


            Poster poster104DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "SKAGEN PLANTATION",
                PosterSku = "FF104DK",
                Path = "/assets/denmark-posters/FF104DK.png",
                CollectionId = 1,
            }).Entity;

            poster104DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster104DK,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster104DK,
                    Tag = tag12
                }
            };

            poster104DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster104DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster104DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster104DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster104DK,
                    Size = size06
                }
            };


            Poster poster103DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "RÅBJERG MILE",
                PosterSku = "FF103DK",
                Path = "/assets/denmark-posters/FF103DK.png",
                CollectionId = 1,
            }).Entity;

            poster103DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster103DK,
                    Tag = tag12
                }
            };

            poster103DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster103DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster103DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster103DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster103DK,
                    Size = size06
                }
            };


            Poster poster102DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "SOIL",
                PosterSku = "FF102DK",
                Path = "/assets/denmark-posters/FF102DK.png",
                CollectionId = 1,
            }).Entity;

            poster102DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster102DK,
                    Tag = tag20
                }
            };

            poster102DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster102DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster102DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster102DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster102DK,
                    Size = size06
                }
            };


            Poster poster101DK = ctx.Posters.Add(new Poster()
            {
                PosterName = "BIRCH",
                PosterSku = "FF101DK",
                Path = "/assets/denmark-posters/FF101DK.png",
                CollectionId = 1,
            }).Entity;

            poster101DK.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster101DK,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster101DK,
                    Tag = tag03
                }
            };

            poster101DK.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster101DK,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster101DK,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster101DK,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster101DK,
                    Size = size06
                }
            };


            Poster poster107FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "THE NORTH ATLANTIC",
                PosterSku = "FF107FO",
                Path = "/assets/faroe-islands-posters/FF107FO.png",
                CollectionId = 2,
            }).Entity;

            poster107FO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster107FO,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster107FO,
                    Tag = tag16
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


            Poster poster106FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "COASTLINE",
                PosterSku = "FF106FO",
                Path = "/assets/faroe-islands-posters/FF106FO.png",
                CollectionId = 2,
            }).Entity;

            poster106FO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster106FO,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster106FO,
                    Tag = tag16
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


            Poster poster105FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "HOUSES",
                PosterSku = "FF105FO",
                Path = "/assets/faroe-islands-posters/FF105FO.png",
                CollectionId = 2,
            }).Entity;

            poster105FO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster105FO,
                    Tag = tag21
                }
            };

            poster105FO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster105FO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster105FO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster105FO,
                    Size = size06
                }
            };


            Poster poster104FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "HUT",
                PosterSku = "FF104FO",
                Path = "/assets/faroe-islands-posters/FF104FO.png",
                CollectionId = 2,
            }).Entity;

            poster104FO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster104FO,
                    Tag = tag21
                },
                new PosterTag
                {
                    Poster = poster104FO,
                    Tag = tag04
                }
            };

            poster104FO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster104FO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster104FO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster104FO,
                    Size = size06
                }
            };


            Poster poster103FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "ISLAND",
                PosterSku = "FF103FO",
                Path = "/assets/faroe-islands-posters/FF103FO.png",
                CollectionId = 2,
            }).Entity;

            poster103FO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster103FO,
                    Tag = tag16
                }
            };

            poster103FO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster103FO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster103FO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster103FO,
                    Size = size06
                }
            };


            Poster poster102FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "MIST",
                PosterSku = "FF102FO",
                Path = "/assets/faroe-islands-posters/FF102FO.png",
                CollectionId = 2,
            }).Entity;

            poster102FO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster102FO,
                    Tag = tag20
                },
                new PosterTag
                {
                    Poster = poster102FO,
                    Tag = tag13
                }
            };

            poster102FO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster102FO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster102FO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster102FO,
                    Size = size06
                }
            };


            Poster poster101FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "STORM",
                PosterSku = "FF101FO",
                Path = "/assets/faroe-islands-posters/FF101FO.png",
                CollectionId = 2,
            }).Entity;

            poster101FO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster101FO,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster101FO,
                    Tag = tag13
                },
                new PosterTag
                {
                    Poster = poster101FO,
                    Tag = tag16
                }
            };

            poster101FO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster101FO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster101FO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster101FO,
                    Size = size06
                }
            };


            Poster poster108FO = ctx.Posters.Add(new Poster()
            {
                PosterName = "MOUNTAIN",
                PosterSku = "FF108FO",
                Path = "/assets/faroe-islands-posters/FF108FO.png",
                CollectionId = 2,
            }).Entity;

            poster108FO.PosterTags = new List<PosterTag>
            {
                   new PosterTag
                {
                    Poster = poster108FO,
                    Tag = tag20
                }
            };

            poster108FO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster108FO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster108FO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster108FO,
                    Size = size06
                }
            };


            Poster poster101CPH = ctx.Posters.Add(new Poster()
                {
                    PosterName = "BIKE",
                    PosterSku = "FF101CPH",
                    Path = "/assets/copenhagen-posters/FF101CPH.png",
                    CollectionId = 3,
                }).Entity;

            poster101CPH.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster101CPH,
                    Tag = tag16
                },
                new PosterTag
                {
                    Poster = poster101CPH,
                    Tag = tag03
                },
                new PosterTag
                {
                    Poster = poster101CPH,
                    Tag = tag22
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
                    PosterName = "LAKESIDE",
                    PosterSku = "FF104CPH",
                    Path = "/assets/copenhagen-posters/FF104CPH.png",
                    CollectionId = 3,
                }).Entity;

            poster104CPH.PosterTags = new List<PosterTag>
            {
                 new PosterTag
                {
                    Poster = poster104CPH,
                    Tag = tag04
                },
                 new PosterTag
                {
                    Poster = poster104CPH,
                    Tag = tag03
                },
                new PosterTag
                {
                    Poster = poster104CPH,
                    Tag = tag22
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


            Poster poster103CPH = ctx.Posters.Add(new Poster()
            {
                PosterName = "BACKYARD",
                PosterSku = "FF103CPH",
                Path = "/assets/copenhagen-posters/FF103CPH.png",
                CollectionId = 3,
            }).Entity;

            poster103CPH.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster103CPH,
                    Tag = tag03
                },
                new PosterTag
                {
                    Poster = poster103CPH,
                    Tag = tag22
                }
            };

            poster103CPH.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster103CPH,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster103CPH,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster103CPH,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster103CPH,
                    Size = size06
                }
            };


            Poster poster105CPH = ctx.Posters.Add(new Poster()
            {
                PosterName = "HARBOUR",
                PosterSku = "FF105CPH",
                Path = "/assets/copenhagen-posters/FF105CPH.png",
                CollectionId = 3,
            }).Entity;

            poster105CPH.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster105CPH,
                    Tag = tag10
                },
                new PosterTag
                {
                    Poster = poster105CPH,
                    Tag = tag16
                },
                new PosterTag
                {
                    Poster = poster105CPH,
                    Tag = tag22
                }
            };

            poster105CPH.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster105CPH,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster105CPH,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster105CPH,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster105CPH,
                    Size = size06
                }
            };


            Poster poster102CPH = ctx.Posters.Add(new Poster()
            {
                PosterName = "BOAT",
                PosterSku = "FF102CPH",
                Path = "/assets/copenhagen-posters/FF102CPH.png",
                CollectionId = 3,
            }).Entity;

            poster102CPH.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster102CPH,
                    Tag = tag16
                },
                new PosterTag
                {
                    Poster = poster102CPH,
                    Tag = tag03
                },
                new PosterTag
                {
                    Poster = poster102CPH,
                    Tag = tag22
                }
            };

            poster102CPH.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster102CPH,
                    Size = size01
                },
                new PosterSize
                {
                    Poster = poster102CPH,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster102CPH,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster102CPH,
                    Size = size06
                }
            };


            Poster poster106BW = ctx.Posters.Add(new Poster()
                {
                    PosterName = "LONGING",
                    PosterSku = "FF106BW",
                    Path = "/assets/black-and-white-posters/FF106BW.png",
                    CollectionId = 4,
                }).Entity;

            poster106BW.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster106BW,
                    Tag = tag10
                },
                 new PosterTag
                {
                    Poster = poster106BW,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster106BW,
                    Tag = tag16
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


            Poster poster105BW = ctx.Posters.Add(new Poster()
            {
                PosterName = "SILENCE",
                PosterSku = "FF105BW",
                Path = "/assets/black-and-white-posters/FF105BW.png",
                CollectionId = 4,
            }).Entity;

            poster105BW.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster105BW,
                    Tag = tag08
                },
                 new PosterTag
                {
                    Poster = poster105BW,
                    Tag = tag12
                },
                new PosterTag
                {
                    Poster = poster105BW,
                    Tag = tag16
                }
            };

            poster105BW.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster105BW,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster105BW,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster105BW,
                    Size = size06
                }
            };


            Poster poster104BW = ctx.Posters.Add(new Poster()
            {
                PosterName = "LINE",
                PosterSku = "FF104BW",
                Path = "/assets/black-and-white-posters/FF104BW.png",
                CollectionId = 4,

            }).Entity;

            poster104BW.PosterTags = new List<PosterTag>
            {
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


            Poster poster103BW = ctx.Posters.Add(new Poster()
            {
                PosterName = "DAYDREAM",
                PosterSku = "FF103BW",
                Path = "/assets/black-and-white-posters/FF103BW.png",
                CollectionId = 4,
            }).Entity;

            poster103BW.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster103BW,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster103BW,
                    Tag = tag16
                }
            };

            poster103BW.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster103BW,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster103BW,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster103BW,
                    Size = size06
                }
            };


            Poster poster102BW = ctx.Posters.Add(new Poster()
            {
                PosterName = "CONTRAST",
                PosterSku = "FF102BW",
                Path = "/assets/black-and-white-posters/FF102BW.png",
                CollectionId = 4,
            }).Entity;

            poster102BW.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster102BW,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster102BW,
                    Tag = tag16
                }
            };

            poster102BW.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster102BW,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster102BW,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster102BW,
                    Size = size06
                }
            };


            Poster poster101BW = ctx.Posters.Add(new Poster()
            {
                PosterName = "EDGE",
                PosterSku = "FF101BW",
                Path = "/assets/black-and-white-posters/FF101BW.png",
                CollectionId = 4,
            }).Entity;

            poster101BW.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster101BW,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster101BW,
                    Tag = tag16
                }
            };

            poster101BW.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster101BW,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster101BW,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster101BW,
                    Size = size06
                }
            };


            Poster poster104SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "THE STORR",
                PosterSku = "FF104SCO",
                Path = "/assets/scotland-posters/FF104SCO.png",
                CollectionId = 5,
            }).Entity;

            poster104SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster104SCO,
                    Tag = tag13
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


            Poster poster110SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "MOUNTAINS",
                PosterSku = "FF110SCO",
                Path = "/assets/scotland-posters/FF110SCO.png",
                CollectionId = 5,
            }).Entity;

            poster110SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster110SCO,
                    Tag = tag13
                }
            };

            poster110SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster110SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster110SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster110SCO,
                    Size = size06
                }
            };


            Poster poster109SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "NEIST POINT",
                PosterSku = "FF109SCO",
                Path = "/assets/scotland-posters/FF109SCO.png",
                CollectionId = 5,
            }).Entity;

            poster109SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster109SCO,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster109SCO,
                    Tag = tag18
                }
            };

            poster109SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster109SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster109SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster109SCO,
                    Size = size06
                }
            };


            Poster poster102SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "FOREST",
                PosterSku = "FF102SCO",
                Path = "/assets/scotland-posters/FF102SCO.png",
                CollectionId = 5,
            }).Entity;

            poster102SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster102SCO,
                    Tag = tag02
                },
                new PosterTag
                {
                    Poster = poster102SCO,
                    Tag = tag03
                }
            };

            poster102SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster102SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster102SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster102SCO,
                    Size = size06
                }
            };


            Poster poster101SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "CAMPER",
                PosterSku = "FF101SCO",
                Path = "/assets/scotland-posters/FF101SCO.png",
                CollectionId = 5,
            }).Entity;

            poster101SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster101SCO,
                    Tag = tag08
                }
            };

            poster101SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster101SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster101SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster101SCO,
                    Size = size06
                }
            };


            Poster poster103SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "BEN NEVIS",
                PosterSku = "FF103SCO",
                Path = "/assets/scotland-posters/FF103SCO.png",
                CollectionId = 5,
            }).Entity;

            poster103SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster103SCO,
                    Tag = tag13
                }
            };

            poster103SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster103SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster103SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster103SCO,
                    Size = size06
                }
            };


            Poster poster105SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "OUTER HEBRIDES",
                PosterSku = "FF105SCO",
                Path = "/assets/scotland-posters/FF105SCO.png",
                CollectionId = 5,
            }).Entity;

            poster105SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster105SCO,
                    Tag = tag08
                }
            };

            poster105SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster105SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster105SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster105SCO,
                    Size = size06
                }
            };


            Poster poster106SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "NORWICK BEACH",
                PosterSku = "FF106SCO",
                Path = "/assets/scotland-posters/FF106SCO.png",
                CollectionId = 5,
            }).Entity;

            poster106SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster106SCO,
                    Tag = tag09
                },
                new PosterTag
                {
                    Poster = poster106SCO,
                    Tag = tag08
                }
            };

            poster106SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster106SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster106SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster106SCO,
                    Size = size06
                }
            };


            Poster poster107SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "YESNABY CASTLE",
                PosterSku = "FF107SCO",
                Path = "/assets/scotland-posters/FF107SCO.png",
                CollectionId = 5,
            }).Entity;

            poster107SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster107SCO,
                    Tag = tag08
                }
            };

            poster107SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster107SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster107SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster107SCO,
                    Size = size06
                }
            };


            Poster poster108SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "BLACK CUILLIN",
                PosterSku = "FF108SCO",
                Path = "/assets/scotland-posters/FF108SCO.png",
                CollectionId = 5,
            }).Entity;

            poster108SCO.PosterTags = new List<PosterTag>
            {
                   new PosterTag
                {
                    Poster = poster108SCO,
                    Tag = tag13
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


            Poster poster111SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "HERMANESS NATIONAL PARK",
                PosterSku = "FF111SCO",
                Path = "/assets/scotland-posters/FF111SCO.png",
                CollectionId = 5,
            }).Entity;

            poster111SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster111SCO,
                    Tag = tag08
                }
            };

            poster111SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster111SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster111SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster111SCO,
                    Size = size06
                }
            };


            Poster poster112SCO = ctx.Posters.Add(new Poster()
            {
                PosterName = "ISLE OF SCALPAY",
                PosterSku = "FF112SCO",
                Path = "/assets/scotland-posters/FF112SCO.png",
                CollectionId = 5,
            }).Entity;

            poster112SCO.PosterTags = new List<PosterTag>
            {
                new PosterTag
                {
                    Poster = poster112SCO,
                    Tag = tag08
                },
                new PosterTag
                {
                    Poster = poster112SCO,
                    Tag = tag18
                }
            };

            poster112SCO.PosterSizes = new List<PosterSize>
            {
                new PosterSize
                {
                    Poster = poster112SCO,
                    Size = size03
                },
                new PosterSize
                {
                    Poster = poster112SCO,
                    Size = size05
                },
                new PosterSize
                {
                    Poster = poster112SCO,
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

            WorkSpacePoster workSpacePoster1 = ctx.WorkSpacePosters.Add(new WorkSpacePoster
            {

                Poster = poster160DK,
                Frame = OAKNATURE, // add frame id here ? or just description
                XPos = 0,
                YPos = 0,
                Size = size01,

            }).Entity;

            WorkSpacePoster workSpacePoster2 = ctx.WorkSpacePosters.Add(new WorkSpacePoster
            {
                Poster = poster159DK,
                Frame = OAKBLACK,
                XPos = 700,
                YPos = 800,
                Size = size05,

            }).Entity;

            WorkSpacePoster workSpacePoster3 = ctx.WorkSpacePosters.Add(new WorkSpacePoster
            {
                Poster = poster155DK,
                Frame = WHITEALU,
                XPos = 650,
                YPos = 550,
                Size = size03,
            }).Entity;

            WorkSpacePoster workSpacePoster4 = ctx.WorkSpacePosters.Add(new WorkSpacePoster
            {
                Poster = poster155DK,
                Frame = ALUBLACK,
                XPos = 250,
                YPos = 300,
                Size = size06,
            }).Entity;

            WorkSpacePoster workSpacePoster5 = ctx.WorkSpacePosters.Add(new WorkSpacePoster
            {
                Poster = poster159DK,
                Frame = NOFRAME,
                XPos = 150,
                YPos = 100,
                Size = size04,

            }).Entity;

            WorkSpacePoster workSpacePoster6 = ctx.WorkSpacePosters.Add(new WorkSpacePoster
            {
                Poster = poster159DK,
                Frame = OAKDARK,
                XPos = 400,
                YPos = 500,
                Size = size03,

            }).Entity;

            string password = "1234";
            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashAdmin,
                out byte[] passwordSaltAdmin);

            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashUser,
                out byte[] passwordSaltUser);



            // create Users

            User admin = ctx.Users.Add(new User()
            {
                Username = "admin",
                PasswordHash = passwordHashAdmin,
                PasswordSalt = passwordSaltAdmin,
                IsAdmin = true,
               
            }).Entity;

            admin.Favourites = new List<Favourite>
            {
                new Favourite
                {
                User = admin,
                Poster = poster156DK
                },

                new Favourite
                {
                User = admin,
                Poster = poster157DK
                },

                new Favourite
                {
                User = admin,
                Poster = poster158DK
                }
            };

            User user = ctx.Users.Add(new User()
            {
                Username = "user",
                PasswordHash = passwordHashUser,
                PasswordSalt = passwordSaltUser,
                IsAdmin = false,
                
            }).Entity;

            user.Favourites = new List<Favourite>
            {
                new Favourite
                {
                User = user,
                Poster = poster153DK
                },

                new Favourite
                {
                User = user,
                Poster = poster154DK
                },

                new Favourite
                {
                User = user,
                Poster = poster156DK
                },

                new Favourite
                {
                User = user,
                Poster = poster104CPH
                },

                new Favourite
                {
                User = user,
                Poster = poster106BW
                },

                new Favourite
                {
                User = user,
                Poster = poster106FO
                }
            };



            // Create WorkSpace

            WorkSpace workSpace1 = ctx.WorkSpaces.Add(new WorkSpace
            {
                Name = "LivingRoom",
                WorkSpacePosters = new List<WorkSpacePoster>
                    {workSpacePoster1, workSpacePoster4, workSpacePoster2, workSpacePoster3},
                User = user
            }).Entity;

            WorkSpace workSpace2 = ctx.WorkSpaces.Add(new WorkSpace
            {
                Name = "Bedroom",
                WorkSpacePosters = new List<WorkSpacePoster> { workSpacePoster4, workSpacePoster5, workSpacePoster6 },
                User = user
            }).Entity;

            WorkSpace workSpace3 = ctx.WorkSpaces.Add(new WorkSpace
            {
                Name = "MasterBedroom",
                WorkSpacePosters = new List<WorkSpacePoster> { workSpacePoster2, workSpacePoster3, workSpacePoster4 },
                User = admin
            }).Entity;

            WorkSpace workSpace4 = ctx.WorkSpaces.Add(new WorkSpace
            {
                Name = "Kitchen",
                WorkSpacePosters = new List<WorkSpacePoster> { },
                User = admin
            }).Entity;

            WorkSpace workSpace5 = ctx.WorkSpaces.Add(new WorkSpace
            {
                Name = "Staircase",
                WorkSpacePosters = new List<WorkSpacePoster> { workSpacePoster4, workSpacePoster1, workSpacePoster3 },
                User =user
            }).Entity;


            ctx.SaveChanges();


            user.WorkSpaces.Add(workSpace1);
            user.WorkSpaces.Add(workSpace2);
            user.WorkSpaces.Add(workSpace5);
            admin.WorkSpaces.Add(workSpace3);
            admin.WorkSpaces.Add(workSpace4);

            ctx.SaveChanges();

        } // closese SeedDB

    }
}


        

    
