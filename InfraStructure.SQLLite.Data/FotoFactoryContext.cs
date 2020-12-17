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
        // POSTERTAG OK
        public DbSet<PosterTag> PosterTags { get; set; }
        // POSTERSIZE OK
        public DbSet<PosterSize> PosterSizes { get; set; }
        // FAVOURITES OK
        public DbSet<Favourite> Favourites { get; set; }
        //OK
        public DbSet<WorkSpace> WorkSpaces { get; set; }
        // WorkSPACEPoser POSTER OK
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
                .HasForeignKey(f => f.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Favourite>()
               .HasOne(f => f.Poster)
               .WithMany(u => u.Favourites)
               .HasForeignKey(f => f.PosterId)
              .OnDelete(DeleteBehavior.NoAction);
            // OnDelete??

            modelBuilder.Entity<WorkSpace>()
                .HasOne<User>(ws => ws.User)
                .WithMany(u => u.WorkSpaces)
                .HasForeignKey(ws => ws.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            //  Create WorkSpace relatons

            




            // Create WorkSpacePoster relations

            modelBuilder.Entity<WorkSpacePoster>()
                .HasOne<Poster>(wsp => wsp.Poster)
                .WithMany(p => p.WorkSpacePosters)
               .HasForeignKey(wsp => wsp.PosterId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WorkSpacePoster>()
                .HasOne<Frame>(wsp => wsp.Frame)
                .WithMany(p => p.WorkSpacePosters)
               .HasForeignKey(wsp => wsp.FrameId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WorkSpacePoster>()
                .HasOne(wsp => wsp.Size)
                .WithMany(p => p.WorkSpacePosters)
               .HasForeignKey(wsp => wsp.SizeId)
              .OnDelete(DeleteBehavior.NoAction);

            



        }

    }
}
