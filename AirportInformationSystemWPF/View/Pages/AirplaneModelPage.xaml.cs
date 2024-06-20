using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.DAL.Repositories;
using AirportInformationSystemWPF.Model;
using AirportInformationSystemWPF.View.Forms;
using System.Windows;
using System.Windows.Controls;

namespace AirportInformationSystemWPF.View.Pages
{
    /// <summary>
    /// Interaction logic for AirplaneModelPage.xaml
    /// </summary>
    public partial class AirplaneModelPage : Page
    {
        IAirplaneModelRepository airplaneModelRepository = new AirplaneModelRepository();
        public AirplaneModelPage()
        {
            InitializeComponent();
            DataContext = airplaneModelRepository.GetAll();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AirplaneModelWindow airplaneModelWindow = new AirplaneModelWindow(new AirplaneModel());
            if (airplaneModelWindow.ShowDialog() == true)
            {
                AirplaneModel airplaneModel = airplaneModelWindow.AirplaneModel;
                airplaneModelRepository.Create(airplaneModel);
                airplaneModelRepository.Save();
                DataContext = airplaneModelRepository.GetAll();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AirplaneModel? airplaneModel = ListBoxView.SelectedItem as AirplaneModel;

            if (airplaneModel is null) return;

            AirplaneModelWindow airplaneModelWindow = new AirplaneModelWindow(new AirplaneModel()
            {
                Id = airplaneModel.Id,
                Name = airplaneModel.Name,
                AmountOfSeats = airplaneModel.AmountOfSeats,
                MaximumSpeed = airplaneModel.MaximumSpeed,
                RangeOfFlight = airplaneModel.RangeOfFlight,
                Weight = airplaneModel.Weight,
            });

            if (airplaneModelWindow.ShowDialog() == true)
            {
                airplaneModel = airplaneModelRepository.GetById(airplaneModelWindow.AirplaneModel.Id);
                if (airplaneModel != null)
                {
                    airplaneModel.Weight = airplaneModelWindow.AirplaneModel.Weight;
                    airplaneModel.RangeOfFlight = airplaneModelWindow.AirplaneModel.RangeOfFlight;
                    airplaneModel.MaximumSpeed = airplaneModelWindow.AirplaneModel.MaximumSpeed;
                    airplaneModel.Name = airplaneModelWindow.AirplaneModel.Name;
                    airplaneModel.AmountOfSeats = airplaneModelWindow.AirplaneModel.AmountOfSeats;
                }

                airplaneModelRepository.Save();

                ListBoxView.Items.Refresh();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            AirplaneModel? airplaneModel = ListBoxView.SelectedItem as AirplaneModel;

            if (airplaneModel is null) return;

            airplaneModelRepository.Delete(airplaneModel.Id);
            airplaneModelRepository.Save();

            DataContext = airplaneModelRepository.GetAll();
        }
    }
}
