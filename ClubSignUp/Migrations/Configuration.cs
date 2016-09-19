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
            //AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClubSignUp.Models.ApplicationDbContext context)
        {
            //AutomaticMigrationsEnabled = false;
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
            if (roleManager.FindByName("ClubAdmin") == null)
                roleManager.Create(new IdentityRole { Name = "ClubAdmin" });

            PasswordHasher phash = new PasswordHasher();

            if (manager != null)
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
                        PreferredPosition = "",
                        DOB = new DateTime(1965, 10, 26),
                        Course = "NA",
                        Club = "NA",
                        Year = 0,
                        PasswordHash = phash.HashPassword("ppowell$1"),
                        SecurityStamp = Guid.NewGuid().ToString()

                    };
                    context.Users.AddOrUpdate(Adminuser);
                }
                if (manager.FindByEmail("mullin.emma@itsligo.ie") == null)
                {
                    var clubAdmin1 = new ApplicationUser()
                    {
                        Sid = "emullin",
                        UserName = "mullin.emma@itsligo.ie",
                        Email = "mullin.emma@itsligo.ie",
                        EmailConfirmed = true,
                        Fname = "Emma",
                        Sname = "Mullin",
                        PreferredPosition = "NA",
                        DOB = new DateTime(1900, 01, 01),
                        Course = "NA",
                        Club = "NA",
                        Year = 0,
                        PasswordHash = phash.HashPassword("emullin$1"),
                        SecurityStamp = Guid.NewGuid().ToString()
                    };
                    context.Users.AddOrUpdate(clubAdmin1);
                }
                if (manager.FindByEmail("ciarankellysocceracademy@gmail.com") == null)
                {
                    var clubAdmin2 = new ApplicationUser()
                    {
                        Sid = "ckelly",
                        UserName = "ciarankellysocceracademy@gmail.com",
                        Email = "ciarankellysocceracademy@gmail.com",
                        EmailConfirmed = true,
                        Fname = "Ciaran",
                        Sname = "Kelly",
                        PreferredPosition = "NA",
                        DOB = new DateTime(1900, 01, 01),
                        Course = "NA",
                        Club = "NA",
                        Year = 0,
                        PasswordHash = phash.HashPassword("ckelly$1"),
                        SecurityStamp = Guid.NewGuid().ToString()
                    };
                    context.Users.AddOrUpdate(clubAdmin2);
                }
                if (manager.FindByEmail("colinfeehilysrfc@hotmail.com") == null)
                {
                    var clubAdmin3 = new ApplicationUser()
                    {
                        Sid = "cfeehily",
                        UserName = "colinfeehilysrfc@hotmail.com",
                        Email = "colinfeehilysrfc@hotmail.com",
                        EmailConfirmed = true,
                        Fname = "Colin",
                        Sname = "Feehily",
                        PreferredPosition = "NA",
                        DOB = new DateTime(1900, 01, 01),
                        Course = "NA",
                        Club = "NA",
                        Year = 0,
                        PasswordHash = phash.HashPassword("cfeehily$1"),
                        SecurityStamp = Guid.NewGuid().ToString()
                    };
                    context.Users.AddOrUpdate(clubAdmin3);
                }

                context.SaveChanges();
            }


            var adminUser2 = manager.FindByEmail("powell.paul@itsligo.ie");
            if (adminUser2 != null)
                manager.AddToRoles(adminUser2.Id, new string[] { "Admin" });

            ApplicationUser clubAdminRole;
            clubAdminRole = manager.FindByEmail("mullin.emma@itsligo.ie");
            if (clubAdminRole != null)
                manager.AddToRoles(clubAdminRole.Id, new string[] { "ClubAdmin" });

            clubAdminRole = manager.FindByEmail("ciarankellysocceracademy@gmail.com");
            if (clubAdminRole != null)
                manager.AddToRoles(clubAdminRole.Id, new string[] { "ClubAdmin" });
            //colinfeehilysrfc @hotmail.com
            clubAdminRole = manager.FindByEmail("colinfeehilysrfc @hotmail.com");
            if (clubAdminRole != null)
                manager.AddToRoles(clubAdminRole.Id, new string[] { "ClubAdmin" });



        }
    }
}
