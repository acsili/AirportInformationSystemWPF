using AirportInformationSystemWPF.DAL;
using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.DAL.Repositories;
using AirportInformationSystemWPF.Model;
using AirportInformationSystemWPF.View.Forms;
using Microsoft.EntityFrameworkCore;
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

namespace AirportInformationSystemWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for FlightPage.xaml
    /// </summary>
    public partial class FlightPage : Page
    {
        IFlightRepository flightRepository = new FlightRepository();
        public FlightPage()
        {
            InitializeComponent();
            DataContext = flightRepository.GetAll();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FlightWindow flightWindow = new FlightWindow(new Flight());
            if (flightWindow.ShowDialog() == true)
            {
                Flight flight = flightWindow.Flight;
                flightRepository.Create(flight);
                flightRepository.Save();
                DataContext = flightRepository.GetAll();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Flight? flight = ListBoxView.SelectedItem as Flight;

            if (flight is null) return;

            FlightWindow flightWindow = new FlightWindow(new Flight
            {
                Id = flight.Id,
                Destination = flight.Destination,
                DepartureCity = flight.DepartureCity,
                DepartureDate = flight.DepartureDate,
                ArrivalDate = flight.ArrivalDate,
                AirplaneId = flight.AirplaneId,
                ChiefPilotId = flight.ChiefPilotId,
            });

            if (flightWindow.ShowDialog() == true)
            {
                flight = flightRepository.GetById(flightWindow.Flight.Id);
                if (flight != null)
                {
                    flight.Destination = flightWindow.Flight.Destination;
                    flight.DepartureCity = flightWindow.Flight.DepartureCity;
                    flight.ArrivalDate = flightWindow.Flight.ArrivalDate;
                    flight.AirplaneId = flightWindow.Flight.AirplaneId;
                    flight.DepartureDate = flightWindow.Flight.DepartureDate;
                    flight.ChiefPilotId = flightWindow.Flight.ChiefPilotId;

                    flightRepository.Save();

                    ListBoxView.Items.Refresh();
                }
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Flight? flight = ListBoxView.SelectedItem as Flight;

            if (flight is null) return;

            flightRepository.Delete(flight.Id);
            flightRepository.Save();

            DataContext = flightRepository.GetAll();

        }
    }
}
