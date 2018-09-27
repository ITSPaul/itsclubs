using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubSignUp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using ClubSignUp.Models.ViewModels;

namespace ClubSignUp.Controllers
{
    [Authorize(Roles ="Admin,ClubAdmin")]
    public class AdminController : Controller
    {
        private ApplicationRoleManager roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return this.roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set { this.roleManager = value; }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private ApplicationDbContext db = new ApplicationDbContext();
        public ClubDbContext clubs = new ClubDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        // GET: Admin
        public async Task<ActionResult> Index()
        {
            var users = (from u in db.Users
                         from ur in u.Roles
                         join r in db.Roles on ur.RoleId equals r.Id
                         where r.Name.Equals("Student")
                         orderby u.Sname, u.Fname
                         select u);

            return View(await users.ToListAsync());
        }

        public async Task<ActionResult> ViewByDate()
        {
            var users = (from u in db.Users
                         from ur in u.Roles
                         join r in db.Roles on ur.RoleId equals r.Id
                         where r.Name.Equals("Student")
                         orderby u.SignupDate descending
                         select u);

            return View(await users.ToListAsync());
        }

        public ActionResult ViewByClass()
        {

            var prgs = clubs.Programmes.ToList();


            var users = (from u in db.Users
                                           from ur in u.Roles
                                           join r in db.Roles on ur.RoleId equals r.Id
                                           where r.Name.Equals("Student")
                                           select u).ToList();
            var user_class =
                (from u in users
                 join p in prgs on u.Course equals p.ProgrammeCode
                 select
                    new StudentProgrammeViewModel
                    {
                        Email = u.Email,
                        Fname = u.Fname,
                        Sname = u.Sname,
                        Contact = u.PhoneNumber,
                        Course = p.ProgrammeName,
                        Year = u.Year
                    }).ToList();

            return View(user_class);
        }

        // GET: Admin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            var applicationUser =  
                (await db.Users.Where(u => u.Id == id)
                .ToListAsync()).First();


            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProgrammeName = clubs.Programmes.FirstOrDefault(p => p.ProgrammeCode == applicationUser.Course).ProgrammeName;
            return View(applicationUser);
        }

        
        // GET: Admin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = (await db.Users.Where(u => u.Id == id).ToListAsync()).First();
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Club,Sid,Fname,Sname,PreferredPosition,DOB,Course,Year,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: Admin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = (await db.Users.Where(u => u.Id == id).ToListAsync()).First();
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = db.Users.Where(u => u.Id == id).First();
            db.Users.Remove(applicationUser);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
