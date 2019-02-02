namespace Microservice.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableSkillStudent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SkillStudents", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SkillStudents", "Name", c => c.String());
        }
    }
}
