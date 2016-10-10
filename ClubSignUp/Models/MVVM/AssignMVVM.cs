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
            List<AssignViewModel> assignees = new List<AssignViewModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                foreach (var assignee in db.Users )
                {
                    assignees.Add(
                        new AssignViewModel { Email = assignee.Email,
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