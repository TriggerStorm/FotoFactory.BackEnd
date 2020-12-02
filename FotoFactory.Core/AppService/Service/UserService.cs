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
        readonly IUserValidator _userValidator;
        readonly IUserRepository _userRepo;
        private readonly IAuthenticationHelper _authenticationHelper;

        public UserService(IUserValidator userValidator, IUserRepository userRepository, IAuthenticationHelper authenticationHelper)
        {
            _userValidator = userValidator ?? throw new NullReferenceException("Validator cannot be null");
            _userRepo = userRepository ?? throw new NullReferenceException("Repository cannot be null");
            _authenticationHelper = authenticationHelper ?? throw new NullReferenceException("AuthenticationHelper cannot be null");
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
            _userValidator.DefaultValidation(userUpdate);
            return _userRepo.UpdateUser(userUpdate);
        }



        public User DeleteUser(int id)
        {
            return _userRepo.DeleteUser(id);
        }



        public User ValidateUser(LoginInputModel loginInputModel)  // is this replaced with validator class??
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


