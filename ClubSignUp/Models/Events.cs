using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClubSignUp.Models
{
    public enum AttendanceType
    {
        Training, TeamMeeting, MatchDay
    }

    [Table("Fixture")]
    public class Fixture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FixtureId;
        public int TeamId;
        public string Opposition;
        public DateTime FixtureDate;
        public ICollection<TeamMember> Attendees;
    }

    [Table("Event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId;
        public int TeamId;
        public string Location;
        public DateTime StartDateTime;
        public DateTime EndDateTime;
        public virtual ICollection<TeamMember> Attendees { get; set; }
    }


    [Table("Event")]
    public class EventAttendance
    {
        [Key]
        public int EventId;
        public int MemberId;
        public string Location;
        public virtual DbSet<TeamMember> Attendees { get; set; }
    }


}