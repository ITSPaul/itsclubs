using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClubSignUp.Models
{
    public class ClubDbContext : DbContext
    {

        public ClubDbContext() : base("name=DefaultConnection")
        {
            // Eager Loading is the default
            // Lazy loading loads related entities that are marked as virtual
            // Lazy Loading and serialization do not mix well
            Configuration.LazyLoadingEnabled = true;
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<TeamPanel>().HasKey<int>(team => team.Id);
        //    //modelBuilder.Entity<TeamMember>().HasKey(r => new { r.TeamId, r.ApplicationUserID } );
        //    //modelBuilder.Entity<Programme>().HasKey(p =>p.ProgrammeCode);

        //    base.OnModelCreating(modelBuilder);

        //}
        public static ClubDbContext Create()
        {

            return new ClubDbContext();
        }

        public DbSet<Programme> Programmes { get; set; }
        public DbSet<TeamPanel> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
    }
}