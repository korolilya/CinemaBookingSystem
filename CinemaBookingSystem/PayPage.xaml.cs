using CinemaBookingSystem.Entities;
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

        public PayPage(Seance seance, ChooseSeatsPage chooseSeatsPage)
        {
            InitializeComponent();
            textblockTime.Text = $"{seance.Time}";
            textblockFilm.Text = $"{seance.Movie.Name}";
            textblockQuantOfTick.Text =$"{ chooseSeatsPage.textBlockQuantity.Text}";
            textblockTotalPrice.Text = $"{chooseSeatsPage.textBlockTotalPrice.Text}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
