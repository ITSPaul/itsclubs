namespace ClubSignUp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClubSignUp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ClubSignUp.Models.ApplicationDbContext context)
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (roleManager.FindByName("Admin") == null)
                roleManager.Create(new IdentityRole { Name = "Admin" });
            if (roleManager.FindByName("Student") == null)
                roleManager.Create(new IdentityRole { Name = "Student" });
            if(manager != null)
            {
                if (manager.FindByEmail("powell.paul@itsligo.ie") == null)
                {
                    var Adminuser = new ApplicationUser()
                    {
                        Sid = "ppowell",
                        UserName = "powell.paul@itsligo.ie",
                        Email = "powell.paul@itsligo.ie",
                        EmailConfirmed = true,
                        Fname = "Paul",
                        Sname = "Powell",
                        PreferredPosition = "Centre Forward",
                        DOB = new DateTime(1965, 10, 26),
                        Course = "staff",
                        Club = "admin",
                        Year = 0,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    context.Users.AddOrUpdate(Adminuser);
                    context.SaveChanges();
                }
            var adminUser2 = manager.FindByEmail("powell.paul@itsligo.ie");
            if (adminUser2 != null)
                manager.AddToRoles(adminUser2.Id, new string[] { "Admin" });
            }

        }
    }
}
