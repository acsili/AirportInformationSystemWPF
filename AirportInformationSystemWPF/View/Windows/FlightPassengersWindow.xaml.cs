using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.DAL.Repositories;
using AirportInformationSystemWPF.Model;
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
using System.Windows.Shapes;

namespace AirportInformationSystemWPF.View.Windows
{
    /// <summary>
    /// Interaction logic for FlightPassengersWindow.xaml
    /// </summary>
    public partial class FlightPassengersWindow : Window
    {
        IFlightRepository flightRepository = new FlightRepository();
        ITicketRepository ticketRepository = new TicketRepository();
        IPassengerRepository passengerRepository = new PassengerRepository();
        public FlightPassengersWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tickets = flightRepository.GetById(int.Parse(FlightIdTextBox.Text)).Tickets;
            var passengers = new List<Passenger>();
            foreach (var ticket in tickets)
            {
                passengers.AddRange(ticket.Passengers);
            }
            ShowTextBlock.Text = "Список пассажиров рейса номер " + FlightIdTextBox.Text;
            DataContext = passengers;
        }
    }
}
