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
       

    }
}
