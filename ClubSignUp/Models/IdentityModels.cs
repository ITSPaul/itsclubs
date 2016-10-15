using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClubSignUp.Models
{
   

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {   [Display(Name = "Last Club Played for")]
        public string Club { get; set; }
        [Display(Name = "College ID")]
        public string Sid { get; set; }
        [Display(Name = "First Name")]
        public string Fname { get; set; }
        [Display(Name = "Family Name")]
        public string Sname { get; set; }
        [Display(Name = "Preferred Position")]
        public string PreferredPosition { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Display(Name = "Course of study")]
        public string Course { get; set; }
        [Display(Name = "Year (1,2,3,4)")]
        public int Year { get; set; }
        [Display(Name = "Sign Up Date")]
        public DateTime SignupDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            base.OnModelCreating(modelBuilder);

        }
        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }

    }
}