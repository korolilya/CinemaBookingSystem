using CinemaBookingSystem.Entities;
using MainLogic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem
{
    class CinemasDB : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Seance> Seances { get; set; }

        public CinemasDB(): base("localsql"){}
    }
}
