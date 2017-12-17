using CinemaBookingSystem;
using CinemaBookingSystem.Entities;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Controls;
using System.Windows;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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

        public void AddPrepareToBookSeats(Seance seance, List<string> booked)
        {
            string json = File.ReadAllText("../../bookedSeats.json");
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj["prepareToBook"][seance.Id.ToString()] = JsonConvert.SerializeObject(booked);
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText("../../bookedSeats.json", output);
        }

        public void ReplacePreparedSeatsToBooked(Seance seance)
        {
            string json = File.ReadAllText("../../bookedSeats.json");
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            string preparedSeats = jsonObj["prepareToBook"][seance.Id.ToString()];
            jsonObj["prepareToBook"][seance.Id.ToString()] = "";
            jsonObj["bookedSeats"][seance.Id.ToString()] = preparedSeats;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText("../../bookedSeats.json", output);
        }

        public List<string> GetBookedSeats(Seance seance)
        {
            string json = File.ReadAllText("../../bookedSeats.json");
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            List<string> bookedSeats = new List<string>();
            if (jsonObj["bookedSeats"][seance.Id.ToString()] != null && jsonObj["bookedSeats"][seance.Id.ToString()] != "")
            {
                string[] stringWithSeats = jsonObj["bookedSeats"][seance.Id.ToString()].ToString().Split(',');
                foreach (string item in stringWithSeats)
                {
                    bookedSeats.Add(item.Replace("[", "").Replace("]", "").Replace("\"", string.Empty));
                }
            }
            return bookedSeats;
        }

    }
}
