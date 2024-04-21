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
        ApplicationContext context = new ApplicationContext();
        public AirplanePage()
        {
            InitializeComponent();
            //context.Airplanes.Load();
            //context.Airplanes.Include(x => x.AirplaneModelId);
            DataContext = context.Airplanes.Include(x => x.AirplaneModel).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AirplaneWindow airplaneWindow = new AirplaneWindow(new Airplane());
            if (airplaneWindow.ShowDialog() == true)
            {
                Airplane airplane = airplaneWindow.Airplane;
                airplane.AirplaneModel = context.AirplaneModels.Find(airplane.AirplaneModelId);
                context.Airplanes.Add(airplane);
                context.SaveChanges();
                //context.Airplanes.Load();
                DataContext = context.Airplanes.Include(x => x.AirplaneModel).ToList();
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
