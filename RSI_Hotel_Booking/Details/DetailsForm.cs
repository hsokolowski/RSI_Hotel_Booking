using System.Windows.Forms;
using RoomDto = RSI_Hotel_Booking.RoomService.roomDto;
using RommServiceClient = RSI_Hotel_Booking.RoomService.RoomWebServiceClient;
using Rule = RSI_Hotel_Booking.RoomService.ruleDto;
using UserRating = RSI_Hotel_Booking.RoomService.userRatingDto;
using BookingClient = RSI_Hotel_Booking.BookingService.BookingWebServiceClient;
using BookingDto = RSI_Hotel_Booking.BookingService.bookingDto;
using System.Drawing;
using System;

namespace RSI_Hotel_Booking.Details
{
    public partial class DetailsForm : Form
    {
        long _ID;
        RoomDto room;
        private ImageList myImageList;

        public DetailsForm(string title, long id)
        {
            InitializeComponent();
            this.Text = title;
            _ID = id;

            SetRoomDetails(id);

            Datepickers();
        }

        #region Setting Values Controls

        private void Datepickers()
        {
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker2.MinDate = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today.AddDays(1);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dddd - dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dddd - dd/MM/yyyy";
        }

        #endregion

        private void SetRoomDetails(long id)
        {
            RommServiceClient client = new RommServiceClient();
            room = client.getRoomDto(id);

            nameRoom.Text = room.name;
            description.Text = room.description;
            pricePerPerson.Text = "Price per person: " + room.pricePerPerson + "$";
            persons.Text = "Max persons: " + room.maxPersons;
            idTb.Text = _ID + ":" + room.id;
            if (room.equipments != null)
            {
                foreach (var item in room.equipments)
                {
                    listEq.Text += item + " ";
                }
            }

            if (room.photos != null)
            {
                pictureBox1.Image = GetBitmapFromUrl(room.photos[0]);

                listView1.View = View.Tile;
                listView1.TileSize = new Size(100, 100);

                myImageList = new ImageList();
                myImageList.ImageSize = new Size(90, 90);
                foreach (var item in room.photos)
                {
                    myImageList.Images.Add(GetBitmapFromUrl(item));
                }

                listView1.LargeImageList = myImageList;
                for (int j = 0; j < myImageList.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    listView1.Items.Add(item);
                }
            }

            if (room.rules != null)
            {
                foreach (var item in room.rules)
                {
                    rule.Text += "[" + item.name + " " + item.description + "]";
                }
            }

            if (room.userRatings != null)
            {
                foreach (var item in room.userRatings)
                {
                    userRate.Text += "[" + item.personName + " " + item.description + "]";
                }
            }

            price.Text = "Price: " +room.maxPersons * room.pricePerPerson + "$";
        }

        private Bitmap GetBitmapFromUrl(string url)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            Bitmap bitmap = new Bitmap(responseStream);

           return bitmap;
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {   
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                pictureBox1.Image = GetBitmapFromUrl(room.photos[listView1.SelectedItems[0].ImageIndex]);
            }
        }

        private void booking_Click(object sender, EventArgs e)
        {
            BookingDto booking = new BookingDto();
            booking.dateFrom = dateTimePicker1.Value.Date;
            booking.dateTo = dateTimePicker1.Value.Date;
            booking.numberDays = (dateTimePicker1.Value - dateTimePicker1.Value).Days;
            long? iD = Globals.Globals.ID;
            booking.personId = (long)iD;
            booking.roomId = _ID;

            //BookingClient client = new BookingClient();
            //client.checkAvailable(booking);

            MessageBox.Show("Selected Date: " + booking.dateFrom + " to "+ booking.dateTo + " numbers: " + booking.numberDays + " person: " + booking.personId + " room: " + booking.roomId, "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
