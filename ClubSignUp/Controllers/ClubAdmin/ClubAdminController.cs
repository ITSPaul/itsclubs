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
        
        // GET: ClubAdmin
        public ActionResult Index()
        {
            return View(AssignMVVM.GetAssignees());
        }

        [HttpPost]
        public ActionResult PutAssignments(List<AssignViewModel> assignees)
        {
            foreach (var assignee in assignees)
            {
                if (!AssignMVVM.Assigned(assignee))
                {
                    if (assignee.Assigned != Models.TEAMASSIGNMENT.Unassigned)
                    {
                        AssignMVVM.PutAssignees(assignee);
                    }
                }
            }
                // TeamAssignment assigned in the view using a popdown list
                //if(!AssignMVVM.Assigned(assignee))
                //    if(assignee.Assigned != Models.TEAMASSIGNMENT.Unassigned)
                //    AssignMVVM.PutAssignees( assignee);

            return RedirectToAction("Index");
        }
    }
}