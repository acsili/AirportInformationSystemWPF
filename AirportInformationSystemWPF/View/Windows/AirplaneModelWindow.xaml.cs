using AirportInformationSystemWPF.Model;
using System.Windows;

namespace AirportInformationSystemWPF.View.Forms
{
    /// <summary>
    /// Interaction logic for AirplaneModelWindow.xaml
    /// </summary>
    public partial class AirplaneModelWindow : Window
    {
        public AirplaneModel AirplaneModel { get; set; }
        public AirplaneModelWindow(AirplaneModel airolaneModel)
        {
            InitializeComponent();
            AirplaneModel = airolaneModel;
            DataContext = AirplaneModel;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
