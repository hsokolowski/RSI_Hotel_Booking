using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationDto = RSI_Hotel_Booking.BookingService.bookingViewDto;
using ReservationClient = RSI_Hotel_Booking.BookingService.BookingWebServiceClient;

namespace RSI_Hotel_Booking.Reservations
{
    public partial class ReservationForm : Form
    {
        ReservationDto[] resevations, resevationsIncoming;
        public ReservationForm()
        {
            InitializeComponent();

            ReservationClient client = new ReservationClient();
            resevations = client.getBookingViewDtos((long)Globals.Globals.ID);

            resevationsIncoming = resevations.OrderBy(c => c.dateFrom).Where(r => r.dateTo > DateTime.Now).ToArray();

            SetReservation(resevationsIncoming);
        }

        private void SetReservation(ReservationDto[] resevations)
        {
            flowLayoutPanel1.Controls.Clear();
            
            foreach (var item in resevations)
            {
                ReservationItem listItem = new ReservationItem();
                listItem.City = item.localizationName;
                listItem.IdReservation = item.id;
                listItem.Hotel = item.hotelName;
                listItem.Room = item.roomName;
                listItem.DateFromTo = "From: " + item.dateFrom.Date.ToString("dd/MM/yyyy") + " to " + item.dateTo.Date.ToString("dd/MM/yyyy");

                flowLayoutPanel1.Controls.Add(listItem);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                SetReservation(resevations);
            }
            else
            {
                SetReservation(resevationsIncoming);
            }
        }
    }
}
