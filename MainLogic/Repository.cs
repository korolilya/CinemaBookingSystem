using CinemaBookingSystem;
using CinemaBookingSystem.Entities;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;


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
                    .Include(c=>c.Movies)
                    .ToList();
            }
        }

        public IEnumerable<Movie> Movies
        {
            get
            {
                using (var context = new CinemasDB())
                    return context.Movies
                    /*.Include(m => m.Name)
                    .Include(m => m.Genre)
                    .Include(m => m.Duration)
                    .Include(m => m.Year)*/
                    .ToList();
            }
        }

        public IEnumerable<Seance> Seance
        {
            get
            {
                using (var context = new CinemasDB())
                    return context.Seances
                    .Include(s => s.CinemaFilm)
                    .Include(s=>s.Movie)                   
                    .ToList();
            }
        }

    }
}
