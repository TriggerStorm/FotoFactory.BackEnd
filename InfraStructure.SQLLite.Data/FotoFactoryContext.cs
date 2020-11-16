using System;
using Microsoft.EntityFrameworkCore;
using FotoFactory.CoreEntities;

namespace InfraStructure.SQLLite.Data
{
    public class FotoFactoryContext : DbContext
    {
        public FotoFactoryContext(DbContextOptions<FotoFactoryContext> opt) : base(opt) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Do we need this?
            modelBuilder.Entity<Poster>()
                .HasMany(t => t.Tags);

            modelBuilder.Entity<Poster>()
                .HasMany(s => s.Sizes);


            /*     modelBuilder.Entity<User>()
                 .HasMany(u => u.WorkSpaces)
                     .WithMany(wsp => wsp.WorkSpacePosters)
                     .OnDelete(DeleteBehavior.SetNull); ;
            */
            modelBuilder.Entity<Poster>()
                .HasMany(s => s.Sizes);
        }


        public DbSet<Tag> Tags { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkSpace> WorkSpaces { get; set; }
        public DbSet<WorkSpacePoster> WorkSpacePosters { get; set; }


    }
}
