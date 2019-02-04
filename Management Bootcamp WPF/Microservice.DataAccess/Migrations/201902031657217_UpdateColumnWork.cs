namespace Microservice.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnWork : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DailyScores", new[] { "Employees_Id" });
            DropIndex("dbo.DailyScores", new[] { "Lessons_Id" });
            DropIndex("dbo.DailyScores", new[] { "Students_Id" });
            DropIndex("dbo.WorkExperiences", new[] { "Students_Id" });
            AddColumn("dbo.WorkExperiences", "Position", c => c.String());
            CreateIndex("dbo.DailyScores", "employees_Id");
            CreateIndex("dbo.DailyScores", "lessons_Id");
            CreateIndex("dbo.DailyScores", "students_Id");
            CreateIndex("dbo.WorkExperiences", "students_Id");
            DropColumn("dbo.WorkExperiences", "Posision");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkExperiences", "Posision", c => c.String());
            DropIndex("dbo.WorkExperiences", new[] { "students_Id" });
            DropIndex("dbo.DailyScores", new[] { "students_Id" });
            DropIndex("dbo.DailyScores", new[] { "lessons_Id" });
            DropIndex("dbo.DailyScores", new[] { "employees_Id" });
            DropColumn("dbo.WorkExperiences", "Position");
            CreateIndex("dbo.WorkExperiences", "Students_Id");
            CreateIndex("dbo.DailyScores", "Students_Id");
            CreateIndex("dbo.DailyScores", "Lessons_Id");
            CreateIndex("dbo.DailyScores", "Employees_Id");
        }
    }
}
