using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClubSignUp.Models.ViewModels;

namespace ClubSignUp.Controllers.ClubAdmin
{
    public class ClubAdminController : Controller
    {
        AssignMVVM assignManager = new AssignMVVM();
        // GET: ClubAdmin
        public ActionResult Index()
        {

            
            return View(assignManager.GetAssignees());
        }

        [HttpPost]
        public void PutAssignments(IEnumerable<ClubSignUp.Models.ViewModels.AssignViewModel> model)
        {
            foreach (AssignViewModel item in model)
            {
                assignManager.PutAssignees(item.Assigned, item);                
            }
        }
    }
}