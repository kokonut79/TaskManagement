namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondTaskChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
