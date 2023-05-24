namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTasksTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "WorkerId", "dbo.Workers");
            DropIndex("dbo.Tasks", new[] { "WorkerId" });
            AlterColumn("dbo.Tasks", "WorkerId", c => c.Int());
            CreateIndex("dbo.Tasks", "WorkerId");
            AddForeignKey("dbo.Tasks", "WorkerId", "dbo.Workers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "WorkerId", "dbo.Workers");
            DropIndex("dbo.Tasks", new[] { "WorkerId" });
            AlterColumn("dbo.Tasks", "WorkerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "WorkerId");
            AddForeignKey("dbo.Tasks", "WorkerId", "dbo.Workers", "Id", cascadeDelete: true);
        }
    }
}
