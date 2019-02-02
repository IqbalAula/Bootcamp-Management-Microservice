namespace Microservice.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatetimeoffsetToDatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Achievements", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "Dob", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Organizations", "DateStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Organizations", "DateEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "DateStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "DateEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WorkExperiences", "DateStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WorkExperiences", "DateEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkExperiences", "DateEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.WorkExperiences", "DateStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "DateEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Schedules", "DateStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Organizations", "DateEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Organizations", "DateStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Students", "Dob", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Achievements", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
