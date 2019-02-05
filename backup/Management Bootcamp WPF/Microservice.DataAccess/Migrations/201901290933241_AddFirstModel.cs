namespace Microservice.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.students_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Dob = c.DateTimeOffset(nullable: false, precision: 7),
                        Pob = c.String(),
                        Gender = c.String(),
                        Religion = c.String(),
                        Address = c.String(),
                        RT = c.Int(nullable: false),
                        RW = c.Int(nullable: false),
                        Kelurahan = c.String(),
                        Kecamatan = c.String(),
                        Kabupaten = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Status = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        classes_Id = c.Int(),
                        placements_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.classes_Id)
                .ForeignKey("dbo.Placements", t => t.placements_Id)
                .Index(t => t.classes_Id)
                .Index(t => t.placements_Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        Batchs_Id = c.Int(),
                        Departments_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.Batchs_Id)
                .ForeignKey("dbo.Departments", t => t.Departments_Id)
                .Index(t => t.Batchs_Id)
                .Index(t => t.Departments_Id);
            
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Placements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        RT = c.Int(nullable: false),
                        RW = c.Int(nullable: false),
                        Kelurahan = c.String(),
                        Kecamatan = c.String(),
                        Kabupaten = c.String(),
                        Phone = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DailyScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Score1 = c.Double(nullable: false),
                        Score2 = c.Double(nullable: false),
                        Score3 = c.Double(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        Employees_Id = c.Int(),
                        Lessons_Id = c.Int(),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .ForeignKey("dbo.Lessons", t => t.Lessons_Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Employees_Id)
                .Index(t => t.Lessons_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Dob = c.DateTimeOffset(nullable: false, precision: 7),
                        Pob = c.String(),
                        Gender = c.String(),
                        Religion = c.String(),
                        Address = c.String(),
                        RT = c.Int(nullable: false),
                        RW = c.Int(nullable: false),
                        Kelurahan = c.String(),
                        Kecamatan = c.String(),
                        Kabupaten = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        level = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        Departements_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Departements_Id)
                .Index(t => t.Departements_Id);
            
            CreateTable(
                "dbo.DetailLessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        LinkFile = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        employees_Id = c.Int(),
                        lessons_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.employees_Id)
                .ForeignKey("dbo.Lessons", t => t.lessons_Id)
                .Index(t => t.employees_Id)
                .Index(t => t.lessons_Id);
            
            CreateTable(
                "dbo.ErrorBanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Description = c.String(),
                        Solution = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        departments_Id = c.Int(),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.departments_Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.departments_Id)
                .Index(t => t.students_Id);
            
            CreateTable(
                "dbo.HistoryDetailLessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        detailLessons_Id = c.Int(),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailLessons", t => t.detailLessons_Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.detailLessons_Id)
                .Index(t => t.students_Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        Description = c.String(),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.students_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        Location = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        classes_Id = c.Int(),
                        employees_Id = c.Int(),
                        lessons_Id = c.Int(),
                        room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.classes_Id)
                .ForeignKey("dbo.Employees", t => t.employees_Id)
                .ForeignKey("dbo.Lessons", t => t.lessons_Id)
                .ForeignKey("dbo.Rooms", t => t.room_Id)
                .Index(t => t.classes_Id)
                .Index(t => t.employees_Id)
                .Index(t => t.lessons_Id)
                .Index(t => t.room_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        Skills_Id = c.Int(),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skills_Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Skills_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.TaskScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Score1 = c.Double(nullable: false),
                        Score2 = c.Double(nullable: false),
                        Score3 = c.Double(nullable: false),
                        Score4 = c.Double(nullable: false),
                        Score5 = c.Double(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        employees_Id = c.Int(),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.employees_Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.employees_Id)
                .Index(t => t.students_Id);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Posision = c.String(),
                        Description = c.String(),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        isDelete = c.Boolean(nullable: false),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Students_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.TaskScores", "students_Id", "dbo.Students");
            DropForeignKey("dbo.TaskScores", "employees_Id", "dbo.Employees");
            DropForeignKey("dbo.SkillStudents", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.SkillStudents", "Skills_Id", "dbo.Skills");
            DropForeignKey("dbo.Schedules", "room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Schedules", "lessons_Id", "dbo.Lessons");
            DropForeignKey("dbo.Schedules", "employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Schedules", "classes_Id", "dbo.Classes");
            DropForeignKey("dbo.Organizations", "students_Id", "dbo.Students");
            DropForeignKey("dbo.HistoryDetailLessons", "students_Id", "dbo.Students");
            DropForeignKey("dbo.HistoryDetailLessons", "detailLessons_Id", "dbo.DetailLessons");
            DropForeignKey("dbo.ErrorBanks", "students_Id", "dbo.Students");
            DropForeignKey("dbo.ErrorBanks", "departments_Id", "dbo.Departments");
            DropForeignKey("dbo.DetailLessons", "lessons_Id", "dbo.Lessons");
            DropForeignKey("dbo.DetailLessons", "employees_Id", "dbo.Employees");
            DropForeignKey("dbo.DailyScores", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.DailyScores", "Lessons_Id", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "Departements_Id", "dbo.Departments");
            DropForeignKey("dbo.DailyScores", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Achievements", "students_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "placements_Id", "dbo.Placements");
            DropForeignKey("dbo.Students", "classes_Id", "dbo.Classes");
            DropForeignKey("dbo.Classes", "Departments_Id", "dbo.Departments");
            DropForeignKey("dbo.Classes", "Batchs_Id", "dbo.Batches");
            DropIndex("dbo.WorkExperiences", new[] { "Students_Id" });
            DropIndex("dbo.TaskScores", new[] { "students_Id" });
            DropIndex("dbo.TaskScores", new[] { "employees_Id" });
            DropIndex("dbo.SkillStudents", new[] { "Students_Id" });
            DropIndex("dbo.SkillStudents", new[] { "Skills_Id" });
            DropIndex("dbo.Schedules", new[] { "room_Id" });
            DropIndex("dbo.Schedules", new[] { "lessons_Id" });
            DropIndex("dbo.Schedules", new[] { "employees_Id" });
            DropIndex("dbo.Schedules", new[] { "classes_Id" });
            DropIndex("dbo.Organizations", new[] { "students_Id" });
            DropIndex("dbo.HistoryDetailLessons", new[] { "students_Id" });
            DropIndex("dbo.HistoryDetailLessons", new[] { "detailLessons_Id" });
            DropIndex("dbo.ErrorBanks", new[] { "students_Id" });
            DropIndex("dbo.ErrorBanks", new[] { "departments_Id" });
            DropIndex("dbo.DetailLessons", new[] { "lessons_Id" });
            DropIndex("dbo.DetailLessons", new[] { "employees_Id" });
            DropIndex("dbo.Lessons", new[] { "Departements_Id" });
            DropIndex("dbo.DailyScores", new[] { "Students_Id" });
            DropIndex("dbo.DailyScores", new[] { "Lessons_Id" });
            DropIndex("dbo.DailyScores", new[] { "Employees_Id" });
            DropIndex("dbo.Classes", new[] { "Departments_Id" });
            DropIndex("dbo.Classes", new[] { "Batchs_Id" });
            DropIndex("dbo.Students", new[] { "placements_Id" });
            DropIndex("dbo.Students", new[] { "classes_Id" });
            DropIndex("dbo.Achievements", new[] { "students_Id" });
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.TaskScores");
            DropTable("dbo.SkillStudents");
            DropTable("dbo.Skills");
            DropTable("dbo.Schedules");
            DropTable("dbo.Rooms");
            DropTable("dbo.Organizations");
            DropTable("dbo.HistoryDetailLessons");
            DropTable("dbo.ErrorBanks");
            DropTable("dbo.DetailLessons");
            DropTable("dbo.Lessons");
            DropTable("dbo.Employees");
            DropTable("dbo.DailyScores");
            DropTable("dbo.Placements");
            DropTable("dbo.Departments");
            DropTable("dbo.Batches");
            DropTable("dbo.Classes");
            DropTable("dbo.Students");
            DropTable("dbo.Achievements");
        }
    }
}
