using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubSignUp.Models
{
    [Table("Team")]
    public class TeamPanel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;
        public string TeamName;

    }

    [Table("TeamMember")]
    public class TeamMember
    {
        [Key]
        [Column(Order =1)]
        public int TeamId;
        [Key]
        [Column(Order = 2)]
        string ApplicationUserID;

    }


}