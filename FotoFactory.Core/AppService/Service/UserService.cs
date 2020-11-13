using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FotoFactory.Core.DomainService;
using FotoFactory.Core.Helper;
using FotoFactory.CoreEntities;


namespace FotoFactory.Core.AppService.Service
{
   
    public class UserService : IUserService
    {
        private readonly IAuthenticationHelper _authenticationHelper;
        readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository, IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
            _userRepo = userRepository;
        }



        public User NewUser(string userName, byte[] passwordHash, byte[] passwordSalt, bool isAdmin)
        {
            var newUser = new User()
            {
                Username = userName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = isAdmin
            };
            return newUser;
        }



        public User CreateUser(User createdUser)
        {
            if (createdUser.Username == null || createdUser.Username == "")
                throw new InvalidDataException("To create a user you need to provide a name");
            if (createdUser.PasswordHash == null)
                throw new InvalidDataException("To create a user you need a password hash");
            if (createdUser.PasswordSalt == null)
                throw new InvalidDataException("To create a user you need to a password salt");
            if (createdUser.IsAdmin != false || createdUser.IsAdmin != true)
                throw new InvalidDataException("To create a user you need to specify if they are an admin or user");
            return _userRepo.CreateUser(createdUser);
        }



        public User FindUserById(int id)
        {
            return _userRepo.ReadById(id);
        }



        public IEnumerable<User> GetAllUsers()
        {
            return _userRepo.ReadAllUsers();
        }



        public User UpdateUser(User userUpdate)
        {
            return _userRepo.UpdateUser(userUpdate);
        }



        public User DeleteUser(int id)
        {
            return _userRepo.DeleteUser(id);
        }



        public User ValidateUser(LoginInputModel loginInputModel)
        {
            User user = _userRepo.ReadAllUsers().FirstOrDefault(u => u.Username == loginInputModel.Username);
            if (user == null)
            {
                throw new NullReferenceException("Invalid User");
            }
            if (!_authenticationHelper.VerifyPasswordHash(loginInputModel.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Invalid Password");
            }
            return user;
        }
    }


}


