using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubSignUp.Models.ViewModels
{
    public static class AssignMVVM
    {
        

        public static List<AssignViewModel> GetAssignees()
        {
            ClubDbContext clbModel = ClubDbContext.Create();
            // Find all the members assigned so far
            List<TeamMember> ExistingMember = clbModel.TeamMembers.ToList();
            List<AssignViewModel> assignees = new List<AssignViewModel>();
            List<SelectListItem> TeamAssignList = new List<SelectListItem>();
            int i = 0;
            foreach (var item in Enum.GetValues(typeof(TEAMASSIGNMENT)))
            {
                TeamAssignList.Add(new SelectListItem
                {
                    Value = (i++).ToString(),
                    Text = item.ToString()
                });
            }
            // don't hog the application db context
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<ApplicationUser> users = db.Users.ToList();
                // Find all the users not assigned so far
                List<ApplicationUser> notAssigned = (from n in users where
                                                     !(from e in ExistingMember
                                                       select e.ApplicationUserID).Contains(n.Id)
                                                        select n).ToList();
                // return them for assignment
                foreach (var assignee in notAssigned)
                {
                    assignees.Add(
                        new AssignViewModel {
                            ApplicationUserID = assignee.Id,
                            Email = assignee.Email,
                            Fname = assignee.Fname,
                            Sname = assignee.Sname,
                             TeamAssignments = TeamAssignList,
                            Assigned = Models.TEAMASSIGNMENT.Unassigned
                        });
                }
                return assignees;
            }
    }

        internal static bool Assigned(AssignViewModel assignee)
        {
            using (ClubDbContext db = new ClubDbContext())
            {
                if (db.TeamMembers.Where(
                    m => m.ApplicationUserID == assignee.ApplicationUserID).Count() > 0)
                    return true;
            }
            return false;
        }

        public static void PutAssignees(AssignViewModel assignee)
        {
            // Select the Team with the Team Type assigned to the Assignee View Model
            using (ClubDbContext db = new ClubDbContext())
            {
                    TeamPanel team = db.Teams.FirstOrDefault(t => t.TeamType == assignee.Assigned);
                // Add the Application USer to the Team Member
                if (team != null)
                {
                    db.TeamMembers.Add(
                        new TeamMember
                        {
                            TeamId = team.Id,
                            ApplicationUserID = assignee.ApplicationUserID,
                        });
                    db.SaveChanges();
                }
            }
        }

    }
}