namespace MainLogic.Migrations
{
    using CinemaBookingSystem.Entities;
    using System;
    using System.Collections.Generic;
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
            Server apiOMDB = new Server();

            Movie[] movies =
            {
                apiOMDB.requestMovieDataByName("Logan", 2017),
                apiOMDB.requestMovieDataByName("Mission: Impossible", 1996),
                apiOMDB.requestMovieDataByName("It", 2017),
                /*apiOMDB.requestMovieDataByName("Deadpool", 2016),
                apiOMDB.requestMovieDataByName("Star Wars: The Last Jedi", 2017),
                apiOMDB.requestMovieDataByName("Murder on the Orient Express", 2017),
                apiOMDB.requestMovieDataByName("Blade Runner 2049", 2017),
                apiOMDB.requestMovieDataByName("The Hitman's Bodyguard", 2017),*/
                
            };

            Cinema[] cinemas =
            {
               new Cinema
               {
                   Name="������",
                   Location="����� �����������",
                   Movies= new List<Seance>
                   {
                       new Seance
                       {
                           Time= new DateTime(2017, 11, 28, 13,40,0),
                   // Cinema= cinemas[0],
                    Movie= movies[2],
                    QuantityOfTickets=180,
                    PriceOfTickets= 450
                       }
                   }
                   //Movies={movies[2], movies[1]}
               },
               new Cinema
               {
                   Name="�������� ������",
                   Location="����� �����������",
                   //Movies={movies[2], movies[0]}
                   Movies= new List<Seance>
                   {
                   new Seance
                       {
                           Time= new DateTime(2017, 11, 28, 15,40,0),
                   // Cinema= cinemas[0],
                    Movie= movies[1],
                    QuantityOfTickets=180,
                    PriceOfTickets= 450
                       },
                   new Seance
                       {
                           Time= new DateTime(2017, 11, 28, 19,30,0),
                   // Cinema= cinemas[0],
                    Movie= movies[0],
                    QuantityOfTickets=180,
                    PriceOfTickets= 650
                       }
                   }
               },
              /* new Cinema
               {
                   Name="Kinostar",
                   Location="����� ������ ����",
                   Movies= new List<Seance>
                   {
                       new Seance
                       {
                           Time= new DateTime(2017, 12, 18, 11,25,0),                   
                    Movie= movies[6],
                    QuantityOfTickets=200,
                    PriceOfTickets= 250
                       },
                   new Seance
                   {
                    Time= new DateTime(2017, 12, 10, 20,15,0),
                    Movie= movies[4],
                    QuantityOfTickets=100,
                    PriceOfTickets= 850
                   }
                   }
                   
               }*/
            };
            

            context.Movies.AddOrUpdate(
               m => m.Name,
               movies
           );

            context.Cinemas.AddOrUpdate(
               c => c.Name,
               cinemas
           );

           /* context.Seances.AddOrUpdate(
               s=>s.Time,
               seances
           );*/
        }
    }
}
