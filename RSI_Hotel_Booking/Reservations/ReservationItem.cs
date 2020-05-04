using System;
using System.IO;
using System.Windows.Forms;
using RaportClient = RSI_Hotel_Booking.RaportService.BookingReportWebServiceClient;

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
            set { _date = value; date.Text = value; }
        }


        public string Room
        {
            get { return _room; }
            set { _room = value; room.Text = value; }
        }


        public string Hotel
        {
            get { return _hotel; }
            set { _hotel = value; hotel.Text = value; }
        }


        public string City
        {
            get { return _city; }
            set { _city = value; city.Text = value; }
        }

        private void raportBtn_Click(object sender, EventArgs e)
        {
            RaportClient client = new RaportClient();

            byte[] array = client.getBookingConfirmation(id);


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
