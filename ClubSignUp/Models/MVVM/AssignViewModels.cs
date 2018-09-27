using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubSignUp.Models.ViewModels
{

    public class AssignViewModel
    {
        [Required]
        [Display(Name = "User ID")]
        public string ApplicationUserID { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Sname { get; set; }

        [Required]
        [Display(Name = "Teams")]
        public List<SelectListItem> TeamAssignments;

        [Required]
        [Display(Name = "Assigned")]
        public TEAMASSIGNMENT Assigned { get; set; }

    }

    public class StudentProgrammeViewModel
    {

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Sname { get; set; }

        [Display(Name ="Course")]
        public string Course { get; set; }

        [Display(Name="Year")]
        public int Year { get; set; }

        [Display(Name ="Contact Number")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

    }
}