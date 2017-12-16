using CinemaBookingSystem.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace MainLogic
{
    public class Server
    {
        private const string apiKey = "55bff0a0";
        private string apiUrl = String.Format("http://www.omdbapi.com/?apikey={0}&plot=full&", apiKey);

        /// <summary>Datab
        /// Request for cinema data through OMDB Api.
        /// https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-request-data-using-the-webrequest-class
        /// </summary>
        public Movie requestMovieDataByName(string filmName, int filmYear)
        {
            string requestUrl = String.Format("{0}t={1}&y={2}", apiUrl, filmName, filmYear);
            WebRequest request = WebRequest.Create(requestUrl);
            WebResponse response = request.GetResponse();

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK) {
                Stream dataStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(dataStream);

                // https://stackoverflow.com/a/20030888
                var result = JsonConvert.DeserializeObject<dynamic>(sr.ReadToEnd());
                if (result.Response == "True")
                {
                    Movie requestedMovie = new Movie
                    {
                        Name = result.Title,
                        Genre = result.Genre,
                        Duration = int.Parse(result.Runtime.ToString().Split()[0]),
                        Year = int.Parse(result.Year.ToString()),
                        Plot = result.Plot
                    };

                    response.Close();
                    return requestedMovie;
                } else
                {
                    response.Close();
                    throw new HttpListenerException((int)HttpStatusCode.NotFound, "The film wasn't found.");
                }
               
            } else {
                throw new HttpListenerException((int)HttpStatusCode.NotFound, "The film wasn't found.");
            }
        }
    }
}
