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
        public event Action<Seance> MovieInfo;

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

        /* public IEnumerable<Seance> Seance
         {
             get
             {
                 using (var context = new CinemasDB())
                     return context.Seances
                     .Include(s => s.CinemaFilm)
                     .Include(s=>s.Movie)                   
                     .ToList();
             }
         }*/

        

    }
}
