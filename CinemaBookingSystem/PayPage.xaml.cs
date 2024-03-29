﻿using CinemaBookingSystem.Entities;
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
            textblockQuantOfTick.Text = $"{ chooseSeatsPage.textBlockQuantity.Text}";
            textblockTotalPrice.Text = $"{chooseSeatsPage.textBlockTotalPrice.Text}";
        }

        private void buttonPayByCah_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Show this code in the bar to get your tickets \nCode: {_repository.RandomString()}");
            _repository.ReplacePreparedSeatsToBooked(_seance);
            _repository.RemoveQuantOfTickets(_seance, int.Parse(textblockQuantOfTick.Text));
            NavigationService.Navigate(_bp);
        }

        

        private void buttonPay_Click(object sender, RoutedEventArgs e)
        {
            if (TextboxCardNumber.Text.Count() != 16)
            {
                MessageBox.Show(($"Your card number must include 16 numbers"));
                return;
            }
            Int64 n;
            if (!Int64.TryParse(TextboxCardNumber.Text, out n))
            {
                MessageBox.Show(($"Your card number must include only numbers"), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TextboxCode.Text.Count() != 3)
            {
                MessageBox.Show(($"Your security code must include 3 numbers"));
                return;
            }
            int c;
            if (!int.TryParse(TextboxCode.Text, out c))
            {
                MessageBox.Show(($"Your security code must include only numbers"), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show(($"You payment was done successfully! Take your tickets at the cashbox."));
            _repository.ReplacePreparedSeatsToBooked(_seance);
            _repository.RemoveQuantOfTickets(_seance, int.Parse(textblockQuantOfTick.Text));           
            NavigationService.Navigate(_bp);
        }
    }
}

