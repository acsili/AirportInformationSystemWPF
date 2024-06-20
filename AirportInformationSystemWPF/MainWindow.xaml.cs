using AirportInformationSystemWPF.DAL;
using AirportInformationSystemWPF.View.Forms;
using AirportInformationSystemWPF.View.Pages;
using AirportInformationSystemWPF.View.Windows;
using System.Text;
using System.Windows;

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
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            ApplicationContext context = new ApplicationContext();
            MenuItemCashier.Click += MenuItemCashier_Click;
            MenuItemChiefPilot.Click += MenuItemChiefPilot_Click;
            MenuItemPassenger.Click += MenuItemPassenger_Click;
            MenuItemAirplaneModel.Click += MenuItemAirplaneModel_Click;
            MenuItemAirplane.Click += MenuItemAirplane_Click;
            MenuItemFlight.Click += MenuItemFlight_Click;
            MenuItemTicket.Click += MenuItemTicket_Click;
            MenuItemPassengerTicket.Click += MenuItemPassengerTicket_Click;
            MenuItemPrepareTicket.Click += MenuItemPrepareTicket_Click;
            MenuItemPassengerFlight.Click += MenuItemPassengerFlight_Click;
            MenuItemInfo.Click += MenuItemMenuItemInfo_Click;
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

        private void MenuItemTicket_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TicketPage();
            LabelTableName.Content = "Билеты";
        }

        private void MenuItemPassengerTicket_Click(object sender, RoutedEventArgs e)
        {
            var ptw = new PassengerTicketWindow();
            ptw.Show();
        }

        private void MenuItemPrepareTicket_Click(object sender, RoutedEventArgs e)
        {
            var ptw = new PrepareTicketWindow();
            ptw.Show();
        }

        private void MenuItemPassengerFlight_Click(object sender, RoutedEventArgs e)
        {
            var fpw = new FlightPassengersWindow();
            fpw.Show();
        }

        private void MenuItemMenuItemInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Справка по приложению \n" +
                "Основные функции данной информационной системы включают в себя:\r\n" +
                "1. Управление данными: добавление, изменение, удаление данных.\r\n" +
                "2. Оформление билета: в соответствующем окне можно ввести id пассажира и id билета.\r\n" +
                "3. Просмотр билетов паасажиров: в соответствующем окне можно ввести id пассажира и увидеть список имеющихся у него билетов, затем выбрав билет из списка можно получить в полном виде этого билета и сохранить его.\r\n" +
                "4. Просмотр пассажиров рейса: в соответствующем окне можно ввести id рейса и увидеть список всех пассажиров этого рейса.");
        }
    }
}