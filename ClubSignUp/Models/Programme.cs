using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubSignUp.Models
{
    [Table("Programme")]
    public partial class Programme
    {
        public Programme()
        {
            
        }

        [Key]
        [StringLength(50)]
        public string ProgrammeCode { get; set; }

        public string ProgrammeName { get; set; }


        //public virtual Department department { get; set; }

        //public virtual ICollection<AcademicYearProgramme> academicProgrammeYears { get; set; }

        //public virtual ICollection<ProgrammeStage> programmeStages { get; set; }
    }
}