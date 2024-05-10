using AirportInformationSystemWPF.DAL;
using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.DAL.Repositories;
using AirportInformationSystemWPF.Model;
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
using System.Windows.Shapes;

namespace AirportInformationSystemWPF.View.Forms
{
    /// <summary>
    /// Interaction logic for FlightWindow.xaml
    /// </summary>
    public partial class FlightWindow : Window
    {
        public Flight Flight { get; set; }
        IAirplaneRepository airplaneRepository = new AirplaneRepository();
        IChiefPilotRepository chiefPilotRepository = new ChiefPilotRepository();
        public FlightWindow(Flight flight)
        {
            InitializeComponent();
            Flight = flight;
            DataContext = Flight;
            ComboBoxAirplanes.DataContext = airplaneRepository.GetAll();
            ComboBoxChiefPilots.DataContext = chiefPilotRepository.GetAll();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ComboBoxAirplanes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxAirplanes.SelectedItem is Airplane airplane)
            {
                Flight.AirplaneId = airplane.Id;
            }
        }

        private void ComboBoxChiefPilots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxChiefPilots.SelectedItem is ChiefPilot chiefPilot)
            {
                Flight.ChiefPilotId = chiefPilot.Id;
            }
        }

    }
}
