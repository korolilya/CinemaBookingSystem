namespace MainLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Movies", new[] { "Cinema_Id" });
            DropColumn("dbo.Movies", "Cinema_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Cinema_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Cinema_Id");
            AddForeignKey("dbo.Movies", "Cinema_Id", "dbo.Cinemas", "Id");
        }
    }
}
