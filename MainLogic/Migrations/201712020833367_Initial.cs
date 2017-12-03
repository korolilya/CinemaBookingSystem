namespace MainLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        Duration = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Cinema_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_Id)
                .Index(t => t.Cinema_Id);
            
            CreateTable(
                "dbo.Seances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        QuantityOfTickets = c.Int(nullable: false),
                        PriceOfTickets = c.Double(nullable: false),
                        Cinema_Id = c.Int(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Cinema_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seances", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Seances", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.Movies", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Seances", new[] { "Movie_Id" });
            DropIndex("dbo.Seances", new[] { "Cinema_Id" });
            DropIndex("dbo.Movies", new[] { "Cinema_Id" });
            DropTable("dbo.Seances");
            DropTable("dbo.Movies");
            DropTable("dbo.Cinemas");
        }
    }
}
