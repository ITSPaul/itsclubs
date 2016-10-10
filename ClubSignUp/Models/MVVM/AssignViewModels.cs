﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubSignUp.Models.ViewModels
{

    public class AssignViewModel
    {

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

        public TEAMASSIGNMENT Assigned { get; set; }

    }

}