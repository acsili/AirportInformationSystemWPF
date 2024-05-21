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

namespace AirportInformationSystemWPF.View.Forms
{
    /// <summary>
    /// Interaction logic for PrepareTicketWindow.xaml
    /// </summary>
    public partial class PrepareTicketWindow : Window
    {
        ITicketRepository ticketRepository = new TicketRepository();
        IPassengerRepository passengerRepository = new PassengerRepository();
        int ticketId;
        public PrepareTicketWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var passengerTickets = passengerRepository.GetPassengerTickets(int.Parse(PassengerIdTextBox.Text));
            DataContext = passengerTickets;
        }

        private void ShowTicketButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedItem is Ticket ticket)
            {
                ticketId = ticket.Id;
            }
        }
    }
}
