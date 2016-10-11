using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubSignUp.Models.ViewModels
{
    public class AssignMVVM
    {
        

        public List<AssignViewModel> GetAssignees()
        {
            ClubModels clbModel = new ClubModels();
            // Find all the members assigned so far
            List<string> ExistingMemberIDs = clbModel.TeamMembers.Select(m => m.ApplicationUserID).ToList();

            List<AssignViewModel> assignees = new List<AssignViewModel>();
            // don't hog the application db context
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Find all the users not assigned so far
                List<ApplicationUser> notAssigned = (from n in db.Users where
                                                     !(from e in ExistingMemberIDs select e).Contains(n.Id)
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
                            Assigned = TEAMASSIGNMENT.UNASSIGNED });
                }
                return assignees;
            }
    }
        public void PutAssignees(TEAMASSIGNMENT teamType, List<AssignViewModel> mvvm)
        {

            using (ClubModels db = new ClubModels())
            {
                foreach (var assignee in mvvm)
                {
                    TeamPanel team = db.Teams.FirstOrDefault(t => t.TeamType == teamType);
                    db.TeamMembers.Add(new TeamMember { TeamId = team.Id, ApplicationUserID = assignee.ApplicationUserID });
 
                }
                db.SaveChanges();
            }
        }

    }
}