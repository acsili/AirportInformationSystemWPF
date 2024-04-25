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
    /// Interaction logic for CashierPage.xaml
    /// </summary>
    public partial class CashierPage : Page
    {
        ICashierRepository cashierRepository = new CashierRepository();
        public CashierPage()
        {
            InitializeComponent();

            DataContext = cashierRepository.GetAll();


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CashierWindow сashierWindow = new CashierWindow(new Cashier());
            if (сashierWindow.ShowDialog() == true)
            {
                Cashier Cashier = сashierWindow.Cashier;
                cashierRepository.Create(Cashier);
                cashierRepository.Save();
                DataContext = cashierRepository.GetAll();
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Cashier? сashier = ListBoxView.SelectedItem as Cashier;

            if (сashier is null) return;

            CashierWindow cashierWindow = new CashierWindow(new Cashier
            {
                Id = сashier.Id,
                Name = сashier.Name,
                Surname = сashier.Surname
            });

            if (cashierWindow.ShowDialog() == true)
            {
                сashier = cashierRepository.GetById(cashierWindow.Cashier.Id);
                if (сashier != null)
                {
                    сashier.Name = cashierWindow.Cashier.Name;
                    сashier.Surname = cashierWindow.Cashier.Surname;

                    cashierRepository.Save();

                    ListBoxView.Items.Refresh();
                }
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            Cashier? сashier = ListBoxView.SelectedItem as Cashier;

            if (сashier is null) return;

            cashierRepository.Delete(сashier.Id);
            cashierRepository.Save();

            DataContext = cashierRepository.GetAll();

        }
    }
}
