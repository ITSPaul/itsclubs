namespace ClubSignUp.Migrations.ClubModelMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialiseClubsContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programme",
                c => new
                    {
                        ProgrammeCode = c.String(nullable: false, maxLength: 50),
                        ProgrammeName = c.String(),
                    })
                .PrimaryKey(t => t.ProgrammeCode);
            
            CreateTable(
                "dbo.TeamMember",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        ApplicationUserID = c.String(nullable: false, maxLength: 128),
                        TeamPanel_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.TeamId, t.ApplicationUserID })
                .ForeignKey("dbo.Team", t => t.TeamPanel_Id)
                .Index(t => t.TeamPanel_Id);
            
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
            DropForeignKey("dbo.TeamMember", "TeamPanel_Id", "dbo.Team");
            DropIndex("dbo.TeamMember", new[] { "TeamPanel_Id" });
            DropTable("dbo.Team");
            DropTable("dbo.TeamMember");
            DropTable("dbo.Programme");
        }
    }
}
