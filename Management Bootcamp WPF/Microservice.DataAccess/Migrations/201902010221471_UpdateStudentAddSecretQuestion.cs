namespace Microservice.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentAddSecretQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "SecretQuestion", c => c.String());
            AddColumn("dbo.Students", "SecretAnswer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "SecretAnswer");
            DropColumn("dbo.Students", "SecretQuestion");
        }
    }
}
