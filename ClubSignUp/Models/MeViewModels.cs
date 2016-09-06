using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubSignUp.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string Fname { get; set; }
        public string Sname { get; set; }
    }
}