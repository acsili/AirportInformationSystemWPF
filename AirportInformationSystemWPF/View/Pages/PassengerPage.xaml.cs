using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.DAL.Repositories;
using AirportInformationSystemWPF.Model;
using AirportInformationSystemWPF.View.Forms;
using System.Windows;
using System.Windows.Controls;

namespace AirportInformationSystemWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for PassengerPage.xaml
    /// </summary>
    public partial class PassengerPage : Page
    {
        IPassengerRepository passengerRepository = new PassengerRepository();
        public PassengerPage()
        {
            InitializeComponent();

            DataContext = passengerRepository.GetAll();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PassengerWindow passengerWindow = new PassengerWindow(new Passenger() { PassengerPassport = new PassengerPassport() });
            if (passengerWindow.ShowDialog() == true)
            {
                Passenger passenger = passengerWindow.Passenger;
                passengerRepository.Create(passenger);
                passengerRepository.Save();
                DataContext = passengerRepository.GetAll();
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Passenger? passenger = ListBoxView.SelectedItem as Passenger;

            if (passenger is null) return;

            PassengerWindow passengerWindow = new PassengerWindow(new Passenger
            {
                Id = passenger.Id,
                Name = passenger.Name,
                Surname = passenger.Surname,
                Age = passenger.Age,
                PassengerPassport = passengerRepository.GetPassengerPassport(passenger.PassengerPassportId),
            });

            if (passengerWindow.ShowDialog() == true)
            {
                passenger = passengerRepository.GetById(passengerWindow.Passenger.Id);
                PassengerPassport passengerPassport = passengerRepository.GetPassengerPassport(passenger.PassengerPassportId);
                if (passenger != null)
                {
                    passenger.Name = passengerWindow.Passenger.Name;
                    passenger.Surname = passengerWindow.Passenger.Surname;
                    passenger.Age = passengerWindow.Passenger.Age;
                    passenger.PassengerPassport = passengerWindow.Passenger.PassengerPassport;

                    passengerPassport.Series = passengerWindow.Passenger.PassengerPassport.Series;
                    passengerPassport.Number = passengerWindow.Passenger.PassengerPassport.Number;

                    passengerRepository.Save();

                    ListBoxView.Items.Refresh();
                }
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Passenger? passenger = ListBoxView.SelectedItem as Passenger;

            if (passenger is null) return;

            passengerRepository.Delete(passenger.Id);
            passengerRepository.Save();

            DataContext = passengerRepository.GetAll();

        }
    }
}
