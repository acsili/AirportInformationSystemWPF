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
    /// Interaction logic for PassengerPage.xaml
    /// </summary>
    public partial class PassengerPage : Page
    {
        ApplicationContext context = new ApplicationContext();
        public PassengerPage()
        {
            InitializeComponent();

            context.Passengers.Load();
            DataContext = context.Passengers.Local.ToObservableCollection();
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PassengerWindow passengerWindow = new PassengerWindow(new Passenger() { PassengerPassport = new PassengerPassport() });
            if (passengerWindow.ShowDialog() == true)
            {
                Passenger passenger = passengerWindow.Passenger;
                context.PassengerPassports.Add(passenger.PassengerPassport);
                context.Passengers.Add(passenger);
                context.SaveChanges();
                context.Passengers.Load();
                DataContext = context.Passengers.Local.ToObservableCollection();
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
