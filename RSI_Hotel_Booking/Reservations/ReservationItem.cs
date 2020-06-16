using System;
using System.IO;
using System.Net.Http;
using System.ServiceModel;
using System.Windows.Forms;
using RaportClient = RSI_Hotel_Booking.RaportService.BookingReportWebServiceClient;
using Global = RSI_Hotel_Booking.Globals.Globals;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RSI_Hotel_Booking.Reservations
{
    public partial class ReservationItem : UserControl
    {
        public ReservationItem()
        {
            InitializeComponent();
        }

        private string _city;
        private string _hotel;
        private string _room;
        private string _date;
        private long id;

        public long IdReservation
        {
            get { return id; }
            set { id = value; }
        }


        public string DateFromTo
        {
            get { return _date; }
            set
            {
                _date = value;
                date.Text = value;
            }
        }


        public string Room
        {
            get { return _room; }
            set
            {
                _room = value;
                room.Text = value;
            }
        }


        public string Hotel
        {
            get { return _hotel; }
            set
            {
                _hotel = value;
                hotel.Text = value;
            }
        }


        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                city.Text = value;
            }
        }

        static HttpClient client2 = new HttpClient();

        private async void raportBtn_Click(object sender, EventArgs e)
        {
            RaportClient client = new RaportClient();
            
            using (new OperationContextScope(client.InnerChannel))
            {
                Program.AddAccessHeaders();
                //byte[] array = client.getBookingConfirmation(id);
                byte[] array = await getReservationsRaportREST(id);


                if (ByteArrayToFile("Raport Reservation.pdf", array))
                {
                    MessageBox.Show("Raport succesfully download!", "Raport", MessageBoxButtons.OK);
                    //System.Diagnostics.Process.Start("C:/Users/Hubert/IdeaProjects/rsiprojecthotelreservation/bookingArchive/" );
                }
                else
                {
                    MessageBox.Show("Raport download failed!", "Raport", MessageBoxButtons.OK);
                }
            }
        }

        private async Task<byte[]> getReservationsRaportREST(long id)
        {
            client2.BaseAddress = new Uri(Global.URL);
            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //var response = await client2.GetAsync("/localization/localization/list?personId=" + Global.ID);
            var response = await client2.GetAsync("/report?bookingId=" + id);

            var json = await response.Content.ReadAsByteArrayAsync();
            // var data = JsonConvert.DeserializeObject<byte[]>(json);

            byte[] localizationDtos = json;

            return localizationDtos;
        }

        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                //File.WriteAllBytes(string path, byte[] bytes);
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    //File.WriteAllBytes(fileName, byteArray);
                    System.Diagnostics.Process.Start(fileName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
    }
}