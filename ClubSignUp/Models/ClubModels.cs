using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClubSignUp.Models
{
    public class ClubModels : DbContext
    {

        public ClubModels() : base("name=DefaultConnection")
        {
            
        }
        public static DbContext Create()
        {

            return new ClubModels();
        }

        public virtual DbSet<Programme> Programmes { get; set; }
    }
}