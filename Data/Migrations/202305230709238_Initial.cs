namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Revenue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Status = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.TaskId);
            
            CreateTable(
                "dbo.TaskToWorkers",
                c => new
                    {
                        WorkerId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkerId, t.TaskId })
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        StartedWorkingOn = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaskId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.WorkerId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId)
                .Index(t => t.TaskId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskToWorkers", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.Workers", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Workers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.TaskToWorkers", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Workers", new[] { "CompanyId" });
            DropIndex("dbo.Workers", new[] { "TaskId" });
            DropIndex("dbo.TaskToWorkers", new[] { "TaskId" });
            DropIndex("dbo.TaskToWorkers", new[] { "WorkerId" });
            DropTable("dbo.Workers");
            DropTable("dbo.TaskToWorkers");
            DropTable("dbo.Tasks");
            DropTable("dbo.Companies");
        }
    }
}
