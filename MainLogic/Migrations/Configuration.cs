namespace MainLogic.Migrations
{
    using CinemaBookingSystem.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaBookingSystem.CinemasDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaBookingSystem.CinemasDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Movie[] movies =
            {
                new Movie
                {
                    Name="Logan",
                    Genre="Drama",
                    Duration=186,
                    Year= 2017
                },
                 new Movie
                {
                    Name="Mission Impossible",
                    Genre="Action",
                    Duration=120,
                    Year= 2003
                },
                  new Movie
                {
                    Name="It",
                    Genre="Horror",
                    Duration=100,
                    Year= 2017
                }
            };

            Cinema[] cinemas =
            {
               new Cinema
               {
                   Name="Родина",
                   Location="метро Семеновская",
                   Movies={movies[2], movies[1]}
               },
               new Cinema
               {
                   Name="Кронверк Синема",
                   Location="метро Семеновская",
                   Movies={movies[2], movies[0]}
               }
            };
            Seance[] seances =
            {
                new Seance
                {
                    Time= new DateTime(2017, 11, 28, 13,40,0),
                    Cinema= cinemas[0],
                    Movie=cinemas[0].Movies[0],
                    QuantityOfTickets=180,
                    PriceOfTickets= 450
                }
            };

            context.Movies.AddOrUpdate(
               m => m.Name,
               movies
           );

            context.Cinemas.AddOrUpdate(
               c => c.Name,
               cinemas
           );

            context.Seances.AddOrUpdate(
               s=>s.Time,
               seances
           );
        }
    }
}
