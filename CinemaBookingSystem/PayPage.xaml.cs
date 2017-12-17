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
    /// Логика взаимодействия для PayPage.xaml
    /// </summary>
    public partial class PayPage : Page
    {
        Repository _repository;
        Seance _seance;
        BookingPage _bp;
        public PayPage(Seance seance, ChooseSeatsPage chooseSeatsPage, Repository repository, BookingPage bp)
        {
            InitializeComponent();
            _seance = seance;
            _repository = repository;
            _bp = bp;
            textblockTime.Text = $"{seance.Time}";
            textblockFilm.Text = $"{seance.Movie.Name}";
            textblockQuantOfTick.Text =$"{ chooseSeatsPage.textBlockQuantity.Text}";
            textblockTotalPrice.Text = $"{chooseSeatsPage.textBlockTotalPrice.Text}";
        }
       
        private void buttonPayByCah_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Show this code in the bar to get your tickets{_repository.RandomString()}");
            _repository.RemoveQuantOfTickets(_seance, int.Parse(textblockQuantOfTick.Text));
            NavigationService.Navigate(_bp);
        }

        private void buttonPay_Click(object sender, RoutedEventArgs e)
        {
            _repository.RemoveQuantOfTickets(_seance, int.Parse(textblockQuantOfTick.Text));
            NavigationService.Navigate(_bp);
        }
    }
}
