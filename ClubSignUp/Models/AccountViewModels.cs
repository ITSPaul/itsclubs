using System;   
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubSignUp.Models
{

    // Models returned by AccountController actions.
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Hometown")]
        public string Hometown { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }



    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Sname { get; set; }

        [Required]
        [Display(Name = "College ID", Prompt ="Enter your College ID (S00.....)")]
        [RegularExpression(@"^[S|s]\d{8}$",ErrorMessage = "College ID must start with an S followed by 8 digits")]
        public string Sid { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "IT Sligo Email",Prompt ="Enter your College ID (S00.....) followed by @mail.itsligo.ie")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Enter your Course Name")]
        public string Course { get; set; }

        [Required]
        [Display(Name ="Enter what year you are in ")]
        public int Year { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password,ErrorMessage ="Password must be have letters and at least one number ")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        
        [Display(Name = "Club Last Played For")]
        public string Club { get; set; }

        [Required]
        [Display(Name = "Preferred Position")]
        public string PreferredPosition { get; set; }

        [Required]
        [Display(Name = "Date Of Birth (dd/mm/yyyy)")]
        [DataType(DataType.Date,ErrorMessage ="Date of Birth must be in the format dd/mm/yyyy")]
        public DateTime DOB { get; set; }

        [Display(Name = "Mobile Number Irish Only E.G. 086-1234567")]
        [Phone]
        [RegularExpression(@"^08[35679]-\d{7}$",ErrorMessage = "Only Republic of Ireland Mobile Contact Numbers allowed")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Programme> Programmes { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
