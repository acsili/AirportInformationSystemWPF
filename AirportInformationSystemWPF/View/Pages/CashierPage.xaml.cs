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

        ApplicationContext applicationContext = new ApplicationContext();
        public CashierPage()
        {
            InitializeComponent();

            applicationContext.Cashiers.Load();

            //cashierRepository.Load();

            //DataContext = cashierRepository.ToObservableCollection();

            DataContext = applicationContext.Cashiers.Local.ToObservableCollection();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CashierWindow сashierWindow = new CashierWindow(new Cashier());
            if (сashierWindow.ShowDialog() == true)
            {
                Cashier Cashier = сashierWindow.Cashier;
                cashierRepository.Create(Cashier);
                cashierRepository.Save();
                applicationContext.Cashiers.Load();
                DataContext = applicationContext.Cashiers.Local.ToObservableCollection();
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Cashier? сashier = CashierList.SelectedItem as Cashier;

            if (сashier is null) return;

            CashierWindow cashierWindow = new CashierWindow(new Cashier
            {
                Id = сashier.Id,
                Name = сashier.Name,
                Surname = сashier.Surname
            });

            if (cashierWindow.ShowDialog() == true)
            {
                сashier = applicationContext.Cashiers.Find(cashierWindow.Cashier.Id);
                if (сashier != null)
                {
                    сashier.Name = cashierWindow.Cashier.Name;
                    сashier.Surname = cashierWindow.Cashier.Surname;
                    
                    applicationContext.SaveChanges();
                    CashierList.Items.Refresh();
                }
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            Cashier? сashier = CashierList.SelectedItem as Cashier;

            if (сashier is null) return;

            applicationContext.Cashiers.Remove(сashier);
            applicationContext.SaveChanges();

            /*cashierRepository.Delete(сashier.Id);
            cashierRepository.Save();*/
        }
    }
}
