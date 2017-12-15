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
        public ChooseSeatsPage()
        {
            InitializeComponent();
            AddToGrid(25, CreateButtons(25));
        }
        private Button[,] CreateButtons(int quantity)
        {
            Button[,] buttons = new Button[quantity, quantity];
            for (int i = 0; i < quantity; i++)
            {
                for (int j = 0; j < quantity; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 25;
                    buttons[i, j].Height = 25;
                    buttons[i, j].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    buttons[i, j].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    buttons[i, j].Margin = new Thickness(10);
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

    }
}
