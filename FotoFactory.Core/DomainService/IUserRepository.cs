using System;
using System.Collections.Generic;
using System.Text;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.DomainService
{
   
    public interface IUserRepository
    {
        // Create User
        // No id when enter, id when exit
        User CreateUser(User user);

        // Read User(s)
        User ReadById(int id);
        IEnumerable<User> ReadAllUsers();

        // Update User
        User UpdateUser(User userUpdate);

        // Delete User
        User DeleteUser(int id);
    }

}
    