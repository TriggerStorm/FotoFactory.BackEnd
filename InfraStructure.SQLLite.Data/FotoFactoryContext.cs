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
                .HasMany(p => p.Tags);

            modelBuilder.Entity<Poster>()
                .HasMany(p => p.Sizes);

            modelBuilder.Entity<User>()
                .HasMany(u => u.WorkSpaces);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Favourites);
               
            modelBuilder.Entity<WorkSpace>()
               .HasMany(ws => ws.WorkSpacePosters);

            modelBuilder.Entity<WorkSpacePoster>()
               .HasOne(wsp => wsp.Poster);

            modelBuilder.Entity<WorkSpacePoster>()
               .HasOne(wsp => wsp.Frame);

            modelBuilder.Entity<WorkSpacePoster>()
               .HasOne(wsp => wsp.Size);
        }


        public DbSet<Poster> Posters { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkSpace> WorkSpaces { get; set; }
        public DbSet<WorkSpacePoster> WorkSpacePosters { get; set; }


    }
}
