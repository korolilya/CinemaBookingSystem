namespace MainLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Seances", name: "Cinema_Id", newName: "CinemaFilm_Id");
            RenameIndex(table: "dbo.Seances", name: "IX_Cinema_Id", newName: "IX_CinemaFilm_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Seances", name: "IX_CinemaFilm_Id", newName: "IX_Cinema_Id");
            RenameColumn(table: "dbo.Seances", name: "CinemaFilm_Id", newName: "Cinema_Id");
        }
    }
}
