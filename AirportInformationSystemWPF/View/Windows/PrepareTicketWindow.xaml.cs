using AirportInformationSystemWPF.DAL.Interfaces;
using AirportInformationSystemWPF.DAL.Repositories;
using AirportInformationSystemWPF.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for PrepareTicketWindow.xaml
    /// </summary>
    public partial class PrepareTicketWindow : Window
    {
        ITicketRepository ticketRepository = new TicketRepository();
        IPassengerRepository passengerRepository = new PassengerRepository();
        IFlightRepository flightRepository = new FlightRepository();
        int ticketId;
        int passengerId;
        public PrepareTicketWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            passengerId = int.Parse(PassengerIdTextBox.Text);
            var passengerTickets = passengerRepository.GetPassengerTickets(passengerId);
            DataContext = passengerTickets;
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedItem is Ticket ticketSelected)
            {
                ticketId = ticketSelected.Id;
            }
            DateTextBlock.Text = DateTime.Now.ToShortDateString();
            var passenger = passengerRepository.GetById(passengerId);
            PassengerTextBlock.Text = passenger.Name + " " + passenger.Surname;
            var ticket = ticketRepository.GetById(ticketId);
            FlightTextBlock.Text = ticket.FlightId.ToString();
            SeatTextBlock.Text = ticket.SeatNumber.ToString();
            var flight = flightRepository.GetById(ticket.FlightId);
            TextBlockFrom.Text = flight.DepartureCity;
            TextBlockIn.Text = flight.Destination;
            TimeTextBlock.Text = flight.DepartureDate.ToShortTimeString();
            TicketPassengerTextBlock.Text = "Билет № " + ticketId + " пассажира " + passenger.Name + " " + passenger.Surname;
        }

        
        private void SaveTicketButton_Click(object sender, RoutedEventArgs e)
        {
            Rect bounds = VisualTreeHelper.GetDescendantBounds(TicketCanvas);

            RenderTargetBitmap rtb = new RenderTargetBitmap((Int32)bounds.Width, (Int32)bounds.Height, 96d, 96d, PixelFormats.Pbgra32);

            DrawingVisual dv = new DrawingVisual();

            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(TicketCanvas);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }

            rtb.Render(dv);

            PngBitmapEncoder png = new PngBitmapEncoder();

            png.Frames.Add(BitmapFrame.Create(rtb));

            using (Stream stm = File.Create("D:\\C_Projs\\AirportInformationSystemWPF\\AirportInformationSystemWPF\\TicketImages\\ticket" + Guid.NewGuid() + ".png"))
            {
                png.Save(stm);
            }

            MessageBox.Show("Билет сохранен");
        }
    }
}
