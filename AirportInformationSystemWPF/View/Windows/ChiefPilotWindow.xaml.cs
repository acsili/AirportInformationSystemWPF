using AirportInformationSystemWPF.Model;
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
    /// Interaction logic for ChiefPilotWindow.xaml
    /// </summary>
    public partial class ChiefPilotWindow : Window
    {
        public ChiefPilot ChiefPilot { get; private set; }
        public ChiefPilotWindow(ChiefPilot chiefPilot)
        {
            InitializeComponent();
            ChiefPilot = chiefPilot;
            DataContext = ChiefPilot;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
