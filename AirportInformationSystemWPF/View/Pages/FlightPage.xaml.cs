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
    /// Interaction logic for FlightPage.xaml
    /// </summary>
    public partial class FlightPage : Page
    {
        ApplicationContext context = new ApplicationContext();
        public FlightPage()
        {
            InitializeComponent();
            DataContext = context.Flights.Include(x => x.Airplane).Include(x => x.CheifPilot).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FlightWindow flightWindow = new FlightWindow(new Flight());
            if (flightWindow.ShowDialog() == true)
            {
                Flight flight = flightWindow.Flight;
                context.Flights.Add(flight);
                context.SaveChanges();
                ListBoxView.Items.Refresh();
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
