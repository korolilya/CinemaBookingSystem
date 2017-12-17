using CinemaBookingSystem.Entities;
using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaBookingSystem
{
    /// <summary>
    /// Логика взаимодействия для NewSeance.xaml
    /// </summary>
    public partial class NewSeance : Page
    {
        Repository _repository;

        public NewSeance(Repository repository)
        {
            _repository = repository;
            InitializeComponent();
            listboxMovies.ItemsSource = repository.Movies;
            listboxCinemas.ItemsSource = repository.Cinemas;
        }

        private void listboxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var movie = listboxMovies.SelectedItem as Movie;
            textBoxMovie.Text = movie.Name;
        }

        private void listboxCinemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cinema = listboxCinemas.SelectedItem as Cinema;
            textBoxCinema.Text = cinema.Name;
        }
    }
}
