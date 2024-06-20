
using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.DAL.Repositories;
using AirportInformationSystemWPF.Model;
using System.Windows;
using System.Windows.Controls;

namespace AirportInformationSystemWPF.View.Forms
{
    /// <summary>
    /// Interaction logic for AirplaneWindow.xaml
    /// </summary>
    public partial class AirplaneWindow : Window
    {
        IAirplaneModelRepository airplaneModelRepository = new AirplaneModelRepository();
        public Airplane Airplane { get; set; }
        public AirplaneWindow(Airplane airplane)
        {
            InitializeComponent();
            Airplane = airplane;
            DataContext = Airplane;
            ComboBoxAirplaneModels.DataContext = airplaneModelRepository.GetAll();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ComboBoxAirplaneModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxAirplaneModels.SelectedItem is AirplaneModel airplaneModel)
            {
                Airplane.AirplaneModelId = airplaneModel.Id;
            }
        }
    }
}
