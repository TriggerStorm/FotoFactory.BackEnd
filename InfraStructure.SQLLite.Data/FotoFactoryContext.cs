using System;
using Microsoft.EntityFrameworkCore;
using FotoFactory.CoreEntities;

namespace InfraStructure.SQLLite.Data
{
    public class FotoFactoryContext : DbContext
    {
        public FotoFactoryContext(DbContextOptions<FotoFactoryContext> opt) : base(opt) { }



        public DbSet<Poster> Posters { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<PosterTag> PosterTags { get; set; }
        public DbSet<PosterSize> PosterSizes { get; set; }


        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<WorkSpace> WorkSpaces { get; set; }
        public DbSet<WorkSpacePoster> WorkSpacePosters { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //  Create PosterTag relations
            modelBuilder.Entity<PosterTag>()
                .HasKey(pt => new { pt.PosterId, pt.TagId });

            modelBuilder.Entity<PosterTag>()
               .HasOne(pt => pt.Poster)
               .WithMany(p => p.PosterTags)
               .HasForeignKey(pt => pt.PosterId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PosterTag>()
               .HasOne(pt => pt.Tag)
               .WithMany(t => t.PosterTags)
               .HasForeignKey(pt => pt.TagId)
               .OnDelete(DeleteBehavior.NoAction);


            //  Create PosterSize relations
            modelBuilder.Entity<PosterSize>()
                .HasKey(ps => new { ps.PosterId, ps.SizeId });

            modelBuilder.Entity<PosterSize>()
               .HasOne(ps => ps.Poster)
               .WithMany(p => p.PosterSizes)
               .HasForeignKey(ps => ps.PosterId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PosterSize>()

               .HasOne(ps => ps.Size)
               .WithMany(s => s.PosterSizes)
               .HasForeignKey(ps => ps.SizeId)
               .OnDelete(DeleteBehavior.NoAction);


            //  Create Favourite relations
            modelBuilder.Entity<Favourite>()
              .HasKey(f => new { f.UserId, f.PosterId });

            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favourites)
                .HasForeignKey(f => f.UserId);
            // OnDelete??


            //  Create WorkSpace relatons

            modelBuilder.Entity<WorkSpace>()
                .HasMany(ws => ws.WorkSpacePosters);
                //workspaceposterid is the foreign key.

            modelBuilder.Entity<WorkSpace>()
                .HasOne(user => user.User) // should be user
                .WithMany(u => u.WorkSpaces); //need workspace entity here;


        }

    }
}
