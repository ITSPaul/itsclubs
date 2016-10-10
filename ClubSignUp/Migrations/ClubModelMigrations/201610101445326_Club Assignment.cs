namespace ClubSignUp.Migrations.ClubModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClubAssignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamMember",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        ApplicationUserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TeamId, t.ApplicationUserID });
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamType = c.Int(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Team");
            DropTable("dbo.TeamMember");
        }
    }
}
