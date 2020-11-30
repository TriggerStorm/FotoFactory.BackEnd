using System;
namespace FotoFactory.CoreEntities
{
    public class Favourite
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int PosterId { get; set; }
        public Poster Poster { get; set; }
    }
}
