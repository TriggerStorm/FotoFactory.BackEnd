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


            ctx.Users.AddRange(users);
            ctx.SaveChanges();

        }

    }
}