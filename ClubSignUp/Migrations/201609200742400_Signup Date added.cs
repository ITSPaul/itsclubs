namespace ClubSignUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SignupDateadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SignupDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SignupDate");
        }
    }
}
