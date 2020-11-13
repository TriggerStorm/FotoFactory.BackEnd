using System;
using System.Collections.Generic;
using System.Text;

namespace FotoFactory.CoreEntities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
        //  public List<WorkSpace> WorkSpaces { get; set; }
        //  public List<int> Favorites { get; set; }*/

    }
}
