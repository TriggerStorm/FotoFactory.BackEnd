using System;
using Microsoft.EntityFrameworkCore;
using FotoFactory.CoreEntities;


namespace InfraStructure.SQLLite.Data
{
    public class FotoFactoryContext : DbContext
    {
        public FotoFactoryContext(DbContextOptions<FotoFactoryContext> opt) : base(opt) { }
        
      
   /*     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
   */
        public DbSet<User> Users { get; set; }

        public DbSet<Poster> Posters { get; set; }

        public DbSet<Frame> Frames { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<WorkSpace> WorkSpaces { get; set; }

        public DbSet<WorkSpacePoster> WorkSpacePosters { get; set; }
    }
}
