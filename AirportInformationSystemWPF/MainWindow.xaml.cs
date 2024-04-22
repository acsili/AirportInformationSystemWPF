using AirportInformationSystemWPF.DAL;
using AirportInformationSystemWPF.View.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirportInformationSystemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MenuItemCashier.Click += MenuItemCashier_Click;
            MenuItemChiefPilot.Click += MenuItemChiefPilot_Click;
            MenuItemPassenger.Click += MenuItemPassenger_Click;
            MenuItemAirplaneModel.Click += MenuItemAirplaneModel_Click;
            MenuItemAirplane.Click += MenuItemAirplane_Click;
            MenuItemFlight.Click += MenuItemFlight_Click;
        }

        private void MenuItemCashier_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CashierPage();
            LabelTableName.Content = "Кассиры";
        }

        private void MenuItemChiefPilot_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ChiefPilotPage();
            LabelTableName.Content = "Главные пилоты";
        }

        private void MenuItemPassenger_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PassengerPage();
            LabelTableName.Content = "Пассажиры";
        }

        private void MenuItemAirplaneModel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AirplaneModelPage();
            LabelTableName.Content = "Модели самолетов";
        }

        private void MenuItemAirplane_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AirplanePage();
            LabelTableName.Content = "Самолеты";
        }

        private void MenuItemFlight_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new FlightPage();
            LabelTableName.Content = "Рейсы";
        }
    }
}