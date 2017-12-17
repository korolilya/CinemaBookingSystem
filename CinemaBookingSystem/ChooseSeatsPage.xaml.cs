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
        public ChooseSeatsPage(Repository repository, Seance seance)
        {
            InitializeComponent();
            _seance = seance;
            _repository = repository;
            AddToGrid(25, CreateButtons(25));          
            textBlockPrice.Text = $"{seance.PriceOfTickets}";
        }

       
        private Button[,] CreateButtons(int quantity)
        {
            Button[,] buttons = new Button[quantity, quantity];
            for (int i = 0; i < quantity; i++)
            {
                for (int j = 0; j < quantity; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 35;
                    buttons[i, j].Height = 35;
                    buttons[i, j].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    buttons[i, j].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    buttons[i, j].Margin = new Thickness(5);
                    buttons[i, j].Background = Brushes.Green;
                    buttons[i, j].Click += (object sender, RoutedEventArgs e) =>
                    {
                        textBlockQuantity.Text = (Int32.Parse(textBlockQuantity.Text) + 1).ToString();
                        textBlockTotalPrice.Text = ((Int32.Parse(textBlockTotalPrice.Text) + Int32.Parse(textBlockPrice.Text)).ToString());
                        (sender as Button).Background = Brushes.Red;
                        (sender as Button).IsHitTestVisible = false;
                    };
                }
            }
            return buttons;
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
            NavigationService.Navigate(new PayPage(_seance, this, _repository));
        }
    }
}
