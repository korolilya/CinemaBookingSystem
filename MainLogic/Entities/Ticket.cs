using CinemaBookingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLogic.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public Seance TicketForTheSeance { get; set; }
    }
}
