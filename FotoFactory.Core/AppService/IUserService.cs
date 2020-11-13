using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
   
    public interface IUserService
    {

        // Create
        User CreateUser(User createdUser);

        // Read
        User FindUserById(int id);
        IEnumerable<User> GetAllUsers();

        // Update
        User UpdateUser(User userUpdate);

        // Delete
        User DeleteUser(int id);

        //Validate
        User ValidateUser(LoginInputModel loginInputModel);
    }

}
