using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Entities
{
    public class Seance
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Cinema CinemaFilm { get; set; }
        public Movie Movie { get; set; }
        public int QuantityOfTickets { get; set; }
        public double PriceOfTickets { get; set; }

        public string Info
        {
            get
            {
                return $"{CinemaFilm}";
            }
        }
    }
}
