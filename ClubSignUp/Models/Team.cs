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
        public int Id { get; set; }
        public TEAMASSIGNMENT TeamType { get; set; }
        public string description { get; set; }
        public virtual ICollection<TeamMember> members { get; set; }
    }



    [Table("TeamMember")]
    public class TeamMember
    {
        [Key]
        [Column(Order =1)]
        public int TeamId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("UserMember")]
        public string ApplicationUserID { get; set; }

        public virtual ApplicationUser UserMember { get; set; }

    }


}