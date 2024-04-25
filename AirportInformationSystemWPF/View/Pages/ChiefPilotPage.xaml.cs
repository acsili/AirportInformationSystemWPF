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
    /// Interaction logic for ChiefPilotPage.xaml
    /// </summary>
    public partial class ChiefPilotPage : Page
    {
        IChiefPilotRepository chiefPilotRepository = new ChiefPilotRepository();
        public ChiefPilotPage()
        {
            InitializeComponent();

            DataContext = chiefPilotRepository.GetAll();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ChiefPilotWindow chiefPilotWindow = new ChiefPilotWindow(new ChiefPilot());
            if (chiefPilotWindow.ShowDialog() == true)
            {
                ChiefPilot chiefPilot = chiefPilotWindow.ChiefPilot;
                chiefPilotRepository.Create(chiefPilot);
                chiefPilotRepository.Save();
                DataContext = chiefPilotRepository.GetAll();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ChiefPilot? chiefPilot = ListBoxView.SelectedItem as ChiefPilot;
            if (chiefPilot is null) return;

            ChiefPilotWindow chiefPilotWindow = new ChiefPilotWindow(new ChiefPilot()
            {
                Id = chiefPilot.Id,
                Name = chiefPilot.Name,
                Surname = chiefPilot.Surname,
                Age = chiefPilot.Age,
                Experience = chiefPilot.Experience,
            });

            if (chiefPilotWindow.ShowDialog() == true)
            {
                chiefPilot = chiefPilotRepository.GetById(chiefPilotWindow.ChiefPilot.Id);
                
                if (chiefPilot != null)
                {
                    chiefPilot.Surname = chiefPilotWindow.ChiefPilot.Surname;
                    chiefPilot.Name = chiefPilotWindow.ChiefPilot.Name;
                    chiefPilot.Experience = chiefPilotWindow.ChiefPilot.Experience;
                    chiefPilot.Age = chiefPilotWindow.ChiefPilot.Age;
                }

                chiefPilotRepository.Save();

                ListBoxView.Items.Refresh();
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ChiefPilot? chiefPilot = ListBoxView.SelectedItem as ChiefPilot;

            if (chiefPilot is null) return;

            chiefPilotRepository.Delete(chiefPilot.Id);
            chiefPilotRepository.Save();

            DataContext = chiefPilotRepository.GetAll();
        }
    }
}
