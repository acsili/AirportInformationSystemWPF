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
    /// Interaction logic for PassengerTicketWindow.xaml
    /// </summary>
    public partial class PassengerTicketWindow : Window
    {
        ApplicationContext context = new ApplicationContext();
        public PassengerTicketWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {


            var passenger = context.Passengers.Find(int.Parse(TextBoxPassenger.Text));
            var ticket = context.Tickets.Find(int.Parse(TextBoxTicket.Text));
            
            passenger.Tickets.Add(ticket);

            context.SaveChanges();

            MessageBox.Show("Билет оформлен");


        }
    }
}
