namespace ClinicApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 100),
                        BirthDate = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        Address = c.String(maxLength: 1000),
                        Phone = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitTime = c.DateTime(),
                        VisitType = c.Int(nullable: false),
                        Diagnosis = c.String(maxLength: 2000),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "PatientId", "dbo.Patients");
            DropIndex("dbo.Visits", new[] { "PatientId" });
            DropTable("dbo.Visits");
            DropTable("dbo.Patients");
        }
    }
}
