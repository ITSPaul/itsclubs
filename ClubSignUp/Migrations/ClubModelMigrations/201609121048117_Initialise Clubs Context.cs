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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Programme");
        }
    }
}
