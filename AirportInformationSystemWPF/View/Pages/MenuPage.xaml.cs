using AirportInformationSystemWPF.DAL;
using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.DAL.Repositories;
using AirportInformationSystemWPF.Model;
using AirportInformationSystemWPF.View.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        ICashierRepository cashierRepository = new CashierRepository();
        public MenuPage()
        {
            InitializeComponent();

            cashierRepository.Load();

            DataContext = cashierRepository.ToObservableCollection();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CashierWindow CashierWindow = new CashierWindow(new Cashier());
            if (CashierWindow.ShowDialog() == true)
            {
                Cashier Cashier = CashierWindow.Cashier;
                cashierRepository.Create(Cashier);
                cashierRepository.Save();
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
