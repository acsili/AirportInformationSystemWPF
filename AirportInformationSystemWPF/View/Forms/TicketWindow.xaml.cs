using AirportInformationSystemWPF.DAL;
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
    /// Interaction logic for TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        ApplicationContext context = new ApplicationContext();
        public Ticket Ticket { get; set; }
        public TicketWindow(Ticket ticket)
        {
            InitializeComponent();
            Ticket = ticket;
            DataContext = Ticket;
            ComboBoxFlights.DataContext = context.Flights.Include(x => x.Airplane).Include(x => x.CheifPilot).ToList();
            ComboBoxCashiers.DataContext = context.Cashiers.ToList();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ComboBoxFlights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFlights.SelectedItem is Flight flight)
            {
                Ticket.FlightId = flight.Id;
            }
        }

        private void ComboBoxCashiers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxCashiers.SelectedItem is Cashier cashier)
            {
                Ticket.CashierId = cashier.Id;
            }
        }
    }
}
