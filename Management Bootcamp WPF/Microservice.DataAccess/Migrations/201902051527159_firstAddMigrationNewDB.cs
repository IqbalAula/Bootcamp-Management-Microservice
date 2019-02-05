namespace Microservice.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstAddMigrationNewDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
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
                        FirstName = c.String(),
                        LastName = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Pob = c.String(),
                        Gender = c.String(),
                        Religion = c.String(),
                        Address = c.String(),
                        RT = c.Int(nullable: false),
                        RW = c.Int(nullable: false),
                        Village = c.String(),
                        District = c.String(),
                        Regencie = c.String(),
                        Provience = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Status = c.String(),
                        SecretQuestion = c.String(),
                        SecretAnswer = c.String(),
                        AccessCard = c.String(),
                        HiringLocation = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        classes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.classes_Id)
                .Index(t => t.classes_Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        batchs_Id = c.Int(),
                        Departments_Id = c.Int(),
                        employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.batchs_Id)
                .ForeignKey("dbo.Departments", t => t.Departments_Id)
                .ForeignKey("dbo.Employees", t => t.employees_Id)
                .Index(t => t.batchs_Id)
                .Index(t => t.Departments_Id)
                .Index(t => t.employees_Id);
            
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
                        IsDelete = c.Boolean(nullable: false),
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
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Pob = c.String(),
                        Gender = c.String(),
                        Religion = c.String(),
                        Address = c.String(),
                        RT = c.Int(nullable: false),
                        RW = c.Int(nullable: false),
                        Village = c.String(),
                        District = c.String(),
                        Regencies = c.String(),
                        Provience = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        SecretQuestion = c.String(),
                        AnswerQuestion = c.String(),
                        AccessCard = c.String(),
                        Role = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
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
                        IsDelete = c.Boolean(nullable: false),
                        employees_Id = c.Int(),
                        lessons_Id = c.Int(),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.employees_Id)
                .ForeignKey("dbo.Lessons", t => t.lessons_Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.employees_Id)
                .Index(t => t.lessons_Id)
                .Index(t => t.students_Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.String(),
                        LinkFile = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        departements_Id = c.Int(),
                        employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.departements_Id)
                .ForeignKey("dbo.Employees", t => t.employees_Id)
                .Index(t => t.departements_Id)
                .Index(t => t.employees_Id);
            
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
                        IsDelete = c.Boolean(nullable: false),
                        departments_Id = c.Int(),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.departments_Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.departments_Id)
                .Index(t => t.students_Id);
            
            CreateTable(
                "dbo.HistoryEducations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Degree = c.String(),
                        StudyProgram = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Ipk = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        students_Id = c.Int(),
                        universitys_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .ForeignKey("dbo.Universities", t => t.universitys_Id)
                .Index(t => t.students_Id)
                .Index(t => t.universitys_Id);
            
            CreateTable(
                "dbo.Universities",
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
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoryPlacements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        Description = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        placements_Id = c.Int(),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Placements", t => t.placements_Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.placements_Id)
                .Index(t => t.students_Id);
            
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
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lockers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.employees_Id)
                .Index(t => t.employees_Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        Description = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
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
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        classes_Id = c.Int(),
                        lessons_Id = c.Int(),
                        room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.classes_Id)
                .ForeignKey("dbo.Lessons", t => t.lessons_Id)
                .ForeignKey("dbo.Rooms", t => t.room_Id)
                .Index(t => t.classes_Id)
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
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        skills_Id = c.Int(),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.skills_Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.skills_Id)
                .Index(t => t.students_Id);
            
            CreateTable(
                "dbo.WeeklyScores",
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
                        IsDelete = c.Boolean(nullable: false),
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
                        Position = c.String(),
                        Description = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.students_Id)
                .Index(t => t.students_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "students_Id", "dbo.Students");
            DropForeignKey("dbo.WeeklyScores", "students_Id", "dbo.Students");
            DropForeignKey("dbo.WeeklyScores", "employees_Id", "dbo.Employees");
            DropForeignKey("dbo.SkillStudents", "students_Id", "dbo.Students");
            DropForeignKey("dbo.SkillStudents", "skills_Id", "dbo.Skills");
            DropForeignKey("dbo.Schedules", "room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Schedules", "lessons_Id", "dbo.Lessons");
            DropForeignKey("dbo.Schedules", "classes_Id", "dbo.Classes");
            DropForeignKey("dbo.Organizations", "students_Id", "dbo.Students");
            DropForeignKey("dbo.Lockers", "employees_Id", "dbo.Employees");
            DropForeignKey("dbo.HistoryPlacements", "students_Id", "dbo.Students");
            DropForeignKey("dbo.HistoryPlacements", "placements_Id", "dbo.Placements");
            DropForeignKey("dbo.HistoryEducations", "universitys_Id", "dbo.Universities");
            DropForeignKey("dbo.HistoryEducations", "students_Id", "dbo.Students");
            DropForeignKey("dbo.ErrorBanks", "students_Id", "dbo.Students");
            DropForeignKey("dbo.ErrorBanks", "departments_Id", "dbo.Departments");
            DropForeignKey("dbo.DailyScores", "students_Id", "dbo.Students");
            DropForeignKey("dbo.DailyScores", "lessons_Id", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Lessons", "departements_Id", "dbo.Departments");
            DropForeignKey("dbo.DailyScores", "employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Achievements", "students_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "classes_Id", "dbo.Classes");
            DropForeignKey("dbo.Classes", "employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Classes", "Departments_Id", "dbo.Departments");
            DropForeignKey("dbo.Classes", "batchs_Id", "dbo.Batches");
            DropIndex("dbo.WorkExperiences", new[] { "students_Id" });
            DropIndex("dbo.WeeklyScores", new[] { "students_Id" });
            DropIndex("dbo.WeeklyScores", new[] { "employees_Id" });
            DropIndex("dbo.SkillStudents", new[] { "students_Id" });
            DropIndex("dbo.SkillStudents", new[] { "skills_Id" });
            DropIndex("dbo.Schedules", new[] { "room_Id" });
            DropIndex("dbo.Schedules", new[] { "lessons_Id" });
            DropIndex("dbo.Schedules", new[] { "classes_Id" });
            DropIndex("dbo.Organizations", new[] { "students_Id" });
            DropIndex("dbo.Lockers", new[] { "employees_Id" });
            DropIndex("dbo.HistoryPlacements", new[] { "students_Id" });
            DropIndex("dbo.HistoryPlacements", new[] { "placements_Id" });
            DropIndex("dbo.HistoryEducations", new[] { "universitys_Id" });
            DropIndex("dbo.HistoryEducations", new[] { "students_Id" });
            DropIndex("dbo.ErrorBanks", new[] { "students_Id" });
            DropIndex("dbo.ErrorBanks", new[] { "departments_Id" });
            DropIndex("dbo.Lessons", new[] { "employees_Id" });
            DropIndex("dbo.Lessons", new[] { "departements_Id" });
            DropIndex("dbo.DailyScores", new[] { "students_Id" });
            DropIndex("dbo.DailyScores", new[] { "lessons_Id" });
            DropIndex("dbo.DailyScores", new[] { "employees_Id" });
            DropIndex("dbo.Classes", new[] { "employees_Id" });
            DropIndex("dbo.Classes", new[] { "Departments_Id" });
            DropIndex("dbo.Classes", new[] { "batchs_Id" });
            DropIndex("dbo.Students", new[] { "classes_Id" });
            DropIndex("dbo.Achievements", new[] { "students_Id" });
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.WeeklyScores");
            DropTable("dbo.SkillStudents");
            DropTable("dbo.Skills");
            DropTable("dbo.Schedules");
            DropTable("dbo.Rooms");
            DropTable("dbo.Organizations");
            DropTable("dbo.Lockers");
            DropTable("dbo.Placements");
            DropTable("dbo.HistoryPlacements");
            DropTable("dbo.Universities");
            DropTable("dbo.HistoryEducations");
            DropTable("dbo.ErrorBanks");
            DropTable("dbo.Lessons");
            DropTable("dbo.DailyScores");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Batches");
            DropTable("dbo.Classes");
            DropTable("dbo.Students");
            DropTable("dbo.Achievements");
        }
    }
}
