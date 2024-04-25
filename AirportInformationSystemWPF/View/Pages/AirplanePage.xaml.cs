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
    /// Interaction logic for AirplanePage.xaml
    /// </summary>
    public partial class AirplanePage : Page
    {
        IAirplaneRepository airplaneRepository = new AirplaneRepository();
        public AirplanePage()
        {
            InitializeComponent();
            DataContext = airplaneRepository.GetAll();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AirplaneWindow airplaneWindow = new AirplaneWindow(new Airplane());
            if (airplaneWindow.ShowDialog() == true)
            {
                Airplane airplane = airplaneWindow.Airplane;
                airplaneRepository.Create(airplane);
                airplaneRepository.Save();
                DataContext = airplaneRepository.GetAll();
            }


        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Airplane? airplane = ListBoxView.SelectedItem as Airplane;

            if (airplane is null) return;

            AirplaneWindow airplaneWindow = new AirplaneWindow(new Airplane()
            {
                Id = airplane.Id,
                AirplaneModelId = airplane.Id,
            });

            if (airplaneWindow.ShowDialog() == true)
            {
                airplane = airplaneRepository.GetById(airplaneWindow.Airplane.Id);
                if (airplane != null)
                {
                    airplane.Id = airplaneWindow.Airplane.Id;
                    airplane.AirplaneModelId = airplaneWindow.Airplane.Id;

                    airplaneRepository.Save();

                    ListBoxView.Items.Refresh();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Airplane? airplane = ListBoxView.SelectedItem as Airplane;

            if (airplane is null) return;

            airplaneRepository.Delete(airplane.Id);
            airplaneRepository.Save();

            DataContext = airplaneRepository.GetAll();

        }
    }
}
