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
    /// Логика взаимодействия для ChooseSeatsPage.xaml
    /// </summary>
    public partial class ChooseSeatsPage : Page
    {
        Repository _repository;
        Seance _seance;
        BookingPage _bp;
        List<string> _bookedSeats;
        public ChooseSeatsPage(Repository repository, Seance seance, BookingPage bp)
        {
            InitializeComponent();
            _seance = seance;
            _repository = repository;
            _bp = bp;
            _bookedSeats = _repository.GetBookedSeats(_seance);
            textBlockPrice.Text = $"{seance.PriceOfTickets}";
            AddToGrid(25, CreateButtons(25));
        }

       
        private Button[,] CreateButtons(int quantity)
        {
            Button[,] buttons = new Button[quantity, quantity];
            for (int i = 0; i < quantity; i++)
            {
                for (int j = 0; j < quantity; j++)
                {
                    string seatNumber = String.Format("{0}+{1}", i, j);
                    buttons[i, j] = new Button();
                    buttons[i, j].Tag = seatNumber;
                    buttons[i, j].Width = 35;
                    buttons[i, j].Height = 35;
                    buttons[i, j].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    buttons[i, j].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    buttons[i, j].Margin = new Thickness(5);
                    buttons[i, j].Background = Brushes.Green;
                    buttons[i, j].Click += (object sender, RoutedEventArgs e) =>
                    {
                        (sender as Button).IsEnabled = false;
                        textBlockQuantity.Text = (Int32.Parse(textBlockQuantity.Text) + 1).ToString();
                        textBlockTotalPrice.Text = ((Int32.Parse(textBlockTotalPrice.Text) + Int32.Parse(textBlockPrice.Text)).ToString());
                        _bookedSeats.Add(((Button)sender).Tag.ToString());
                        //(sender as Button).Foreground = Brushes.Red;
                    };
                    if (_bookedSeats.Contains(seatNumber))
                    {
                        madeButtonClicked(buttons[i, j]);
                    }
                }
            }
            return buttons;
        }

        private void madeButtonClicked(object sender)
        {
            (sender as Button).IsEnabled = false;
        }

        private void AddToGrid(int quantity, Button[,] buttons)
        {
            for (int i = 0; i < quantity; i++)
            {
                for (int j = 0; j < quantity; j++)
                {
                    Grid.SetColumn(buttons[i, j], j);
                    Grid.SetRow(buttons[i, j], i);
                    Seats.Children.Add(buttons[i, j]);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToUInt32(textBlockQuantity.Text) != 0)
            {
                _repository.AddPrepareToBookSeats(_seance, _bookedSeats);
                NavigationService.Navigate(new PayPage(_seance, this, _repository, _bp));
            }
            else
                MessageBox.Show($"Please, choose the seats");
        }
    }
}
