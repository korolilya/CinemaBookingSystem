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
    /// Логика взаимодействия для BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        Repository _repository = new Repository();
       

        public BookingPage()
        {
            InitializeComponent();
            ListBoxFilms.ItemsSource = null;
            ComboBoxCinemas.ItemsSource = null; 
            ComboBoxCinemas.ItemsSource = _repository.Cinemas.ToList();
            //these two lines were taken from https://stackoverflow.com/questions/4821163/how-absolutely-set-tooltipservice-showdurationproperty
            ToolTipService.ShowDurationProperty.OverrideMetadata(
            typeof(DependencyObject), new FrameworkPropertyMetadata(Int32.MaxValue));
        }

        private void ListBoxFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            
        }

        private void ComboBoxCinemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cinema = ComboBoxCinemas.SelectedItem as Cinema;
            ListBoxFilms.ItemsSource = cinema.Movies; 
           
        }
        
        private void ButtonBook_Click(object sender, RoutedEventArgs e)
        {
            var movie = ListBoxFilms.SelectedItem as Seance;
            if(movie!=null)
            {
            NavigationService.Navigate(new ChooseSeatsPage(_repository, movie, this));
            }
            else
            {
                MessageBox.Show("Please, choose a seance!");
            }
        }

        
    }
}
