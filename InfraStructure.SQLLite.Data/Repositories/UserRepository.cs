using System;
using System.Collections.Generic;
using System.Linq;
using FotoFactory.Core.DomainService;
using FotoFactory.CoreEntities;

namespace InfraStructure.SQLLite.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
       
        readonly FotoFactoryContext _ctx;


        public UserRepository(FotoFactoryContext ctx)
        {
            _ctx = ctx;
        }


        public User CreateUser(User user)
        {
            User u = _ctx.Users.Add(user).Entity;
            _ctx.SaveChanges();
            return u;
        }



        public IEnumerable<User> ReadAllUsers()
        {
            return _ctx.Users;
        }



        public User ReadById(int id)
        {
            return _ctx.Users.FirstOrDefault(u => u.UserId == id);
        }



        // Remove later for UOW
        public User UpdateUser(User userUpdate)
        {
            var userFromDB = this.ReadById(userUpdate.UserId);
            if (userFromDB != null)
            {
                userFromDB.Username = userUpdate.Username;
                userFromDB.PasswordHash = userUpdate.PasswordHash;  // Needed???
                userFromDB.PasswordSalt = userUpdate.PasswordSalt;  // Needed???
                userFromDB.IsAdmin = userUpdate.IsAdmin;
                return userFromDB;
            }
            return null;
        }



        public User DeleteUser(int id)
        {
            var userRemoved = _ctx.Remove(new User { UserId = id }).Entity;
            _ctx.SaveChanges();
            return userRemoved;
        }


    }
}
