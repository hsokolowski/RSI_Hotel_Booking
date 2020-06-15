using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationDto = RSI_Hotel_Booking.BookingService.bookingViewDto;
using ReservationClient = RSI_Hotel_Booking.BookingService.BookingWebServiceClient;
using Global = RSI_Hotel_Booking.Globals.Globals;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RSI_Hotel_Booking.Reservations
{
    public partial class ReservationForm : Form
    {
        ReservationDto[] resevations, resevationsIncoming;
        static HttpClient client2 = new HttpClient();

        public ReservationForm()
        {
            InitializeComponent();
            InitReservations();
        }

        public async void InitReservations()
        {
            ReservationClient client = new ReservationClient();
            using (new OperationContextScope(client.InnerChannel))
            {
                Program.AddAccessHeaders();
                Console.WriteLine("Reservations");
                //resevations = client.getBookingViewDtos((long) Globals.Globals.ID);
                resevations = await getReservationsTREST((long)Globals.Globals.ID);

                resevationsIncoming =
                    resevations.OrderBy(c => c.dateFrom).Where(r => r.dateTo >= DateTime.Now).ToArray();
            }

            SetReservation(resevationsIncoming);
        }

        private async Task<ReservationDto[]> getReservationsTREST(long id)
        {
            client2.BaseAddress = new Uri(Global.URL);
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //var response = await client2.GetAsync("/localization/localization/list?personId=" + Global.ID);
            var response = await client2.GetAsync("/booking/list?personId=" + id);

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ReservationDto[]>(json);

            ReservationDto[] localizationDtos = data;

            return localizationDtos;
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
                listItem.DateFromTo = "From: " + item.dateFrom.Date.ToString("dd/MM/yyyy") + " to " +
                                      item.dateTo.Date.ToString("dd/MM/yyyy");

                flowLayoutPanel1.Controls.Add(listItem);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
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