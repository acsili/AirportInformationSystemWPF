using AirportInformationSystemWPF.DAL;
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
        ApplicationContext context = new ApplicationContext();
        public TicketPage()
        {
            InitializeComponent();
            DataContext = context.Tickets.Include(x => x.Cashier).Include(x => x.Flight).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TicketWindow ticketWindow = new TicketWindow(new Ticket());
            if (ticketWindow.ShowDialog() == true) 
            {
                Ticket ticket = ticketWindow.Ticket;
                context.Tickets.Add(ticket);
                context.SaveChanges();
                DataContext = context.Tickets.Include(x => x.Cashier).Include(x => x.Flight).ToList();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
