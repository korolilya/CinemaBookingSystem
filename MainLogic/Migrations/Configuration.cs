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
                   Name="Кронверк Синема",
                   Location="метро Семеновская",
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
               }
            };
            /*Seance[] seances =
            {
                new Seance
                {
                    Time= new DateTime(2017, 11, 28, 13,40,0),
                    Cinema= cinemas[0],
                    Movie= movies[2],
                    QuantityOfTickets=180,
                    PriceOfTickets= 450
                }
            };*/

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
