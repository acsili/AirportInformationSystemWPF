﻿using AirportInformationSystemWPF.DAL;
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
        ApplicationContext context = new ApplicationContext();
        public ChiefPilotPage()
        {
            InitializeComponent();

            context.ChiefPilots.Load();
            DataContext = context.ChiefPilots.Local.ToObservableCollection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ChiefPilotWindow chiefPilotWindow = new ChiefPilotWindow(new ChiefPilot());
            if (chiefPilotWindow.ShowDialog() == true)
            {
                ChiefPilot chiefPilot = chiefPilotWindow.ChiefPilot;
                context.ChiefPilots.Add(chiefPilot);
                context.SaveChanges();
                context.ChiefPilots.Load();
                DataContext = context.ChiefPilots.Local.ToObservableCollection();
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
