namespace MainLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlotToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Plot", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Plot");
        }
    }
}
