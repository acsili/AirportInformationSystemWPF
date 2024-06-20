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
    /// Interaction logic for TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        ITicketRepository ticketRepository = new TicketRepository();
        public TicketPage()
        {
            InitializeComponent();
            DataContext = ticketRepository.GetAll();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TicketWindow ticketWindow = new TicketWindow(new Ticket());
            if (ticketWindow.ShowDialog() == true) 
            {
                Ticket ticket = ticketWindow.Ticket;
                ticketRepository.Create(ticket);
                ticketRepository.Save();
                DataContext = ticketRepository.GetAll();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Ticket? ticket = ListBoxView.SelectedItem as Ticket;

            if (ticket is null) return;

            TicketWindow ticketWindow = new TicketWindow(new Ticket
            {
                Id = ticket.Id,
                Price = ticket.Price,
                CashierId = ticket.CashierId,
                FlightId = ticket.FlightId,
            });

            if (ticketWindow.ShowDialog() == true)
            {
                ticket = ticketRepository.GetById(ticketWindow.Ticket.Id);
                if (ticket != null)
                {
                    ticket.Price = ticketWindow.Ticket.Price;
                    ticket.CashierId = ticketWindow.Ticket.CashierId;
                    ticket.FlightId = ticketWindow.Ticket.FlightId;

                    ticketRepository.Save();

                    ListBoxView.Items.Refresh();
                }
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Ticket? ticket = ListBoxView.SelectedItem as Ticket;

            if (ticket is null) return;

            ticketRepository.Delete(ticket.Id);
            ticketRepository.Save();

            DataContext = ticketRepository.GetAll();
        }
    }
}
