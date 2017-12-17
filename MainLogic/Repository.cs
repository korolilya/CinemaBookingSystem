using CinemaBookingSystem;
using CinemaBookingSystem.Entities;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Controls;
using System.Windows;

namespace MainLogic
{
    public class Repository
    {
        

        public IEnumerable<Cinema> Cinemas
        {
            get
            {
                using (var context = new CinemasDB())
                    return context.Cinemas                   
                    .Include(c=>c.Movies.Select(m=>m.Movie))
                    .ToList();
            }
        }

        public IEnumerable<Movie> Movies
        {
            get
            {
                using (var context = new CinemasDB())
                    return context.Movies                   
                    .ToList();
            }
        }

        
         public void RemoveQuantOfTickets (Seance seance, int TotalQuantityOfTickets)
        {
            using (var context= new CinemasDB())
            {
                var seanceFromDB = context.Seances.Find(seance.Id);

                seanceFromDB.QuantityOfTickets -= TotalQuantityOfTickets;
                context.SaveChanges();
            }
        }

        private static Random random = new Random();
        public string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

       


    }
}
