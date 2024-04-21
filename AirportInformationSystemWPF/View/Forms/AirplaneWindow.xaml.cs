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
    /// Interaction logic for AirplaneWindow.xaml
    /// </summary>
    public partial class AirplaneWindow : Window
    {
        ApplicationContext context = new ApplicationContext();
        public Airplane Airplane { get; set; }
        public AirplaneWindow(Airplane airplane)
        {
            InitializeComponent();
            Airplane = airplane;
            DataContext = Airplane;
            ComboBoxAirplaneModels.DataContext = context.AirplaneModels.ToList();
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
