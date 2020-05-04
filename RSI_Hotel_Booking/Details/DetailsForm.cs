using System.Windows.Forms;
using RoomDto = RSI_Hotel_Booking.RoomService.roomDto;
using RommServiceClient = RSI_Hotel_Booking.RoomService.RoomWebServiceClient;
using Rule = RSI_Hotel_Booking.RoomService.ruleDto;
using UserRating = RSI_Hotel_Booking.RoomService.userRatingDto;
using BookingClient = RSI_Hotel_Booking.BookingService.BookingWebServiceClient;
using BookingDto = RSI_Hotel_Booking.BookingService.bookingDto;
using System.Drawing;
using System;
using System.Collections;

namespace RSI_Hotel_Booking.Details
{
    public partial class DetailsForm : Form
    {
        long _ID;
        RoomDto room;
        ImageList myImageList;


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
            descriptionTb.Text = room.description;
            pricePerPerson.Text = "Price per person: " + room.pricePerPerson + "$";
            persons.Text = "Max persons: " + room.maxPersons;
            idTb.Text = _ID + ":" + room.id;

            if (room.equipments != null)
            {
                listView2.View = View.List;
                
                foreach (var item in room.equipments)
                {
                    var listViewItem = new ListViewItem(item);
                    listView2.Items.Add(listViewItem);
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
                //listView3.View = View.Tile;
                //listView1.TileSize = new Size(100, 40);
                foreach (var item in room.rules)
                {
                    RuleItemcs rule = new RuleItemcs(item.name, item.description);
                    flowLayoutPanel1.Controls.Add(rule);
                    //TextBox lvi = new TextBox();
                    //lvi.Multiline = true;
                    //lvi.Width = 260;
                    //lvi.Text = "["+item.name+"] \n";
                    //lvi.Text += item.description;
                    //listView3.Items.Add(lvi);

                }
            }

            if (room.userRatings != null)
            {
                foreach (var item in room.userRatings)
                {
                    CommentItem comment = new CommentItem(item.personName, item.description);
                    flowLayoutPanel2.Controls.Add(comment);
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
            booking.dateFrom = new DateTimeOffset(dateTimePicker1.Value.Date).ToUnixTimeSeconds();
            booking.dateFromSpecified = true;
            booking.dateTo = new DateTimeOffset(dateTimePicker2.Value.Date).ToUnixTimeSeconds();
            booking.dateToSpecified = true;
            booking.numberDays = (dateTimePicker2.Value.Date - dateTimePicker1.Value.Date).Days;
            booking.numberDaysSpecified = true;
            long? iD = Globals.Globals.ID;
            //booking.personId = (long)iD;
            booking.personId = 181;
            booking.personIdSpecified = true;
            booking.roomId = _ID;
            booking.roomIdSpecified = true;
            booking.numberPersons = Convert.ToInt32(persons.Text.Split(' ')[2]);
            booking.numberPersonsSpecified = true;
            
            
            BookingClient client = new BookingClient();
            if(client.checkAvailable(booking))
            {
                string message = "Are you sure you want to rent this room?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, "Booking", buttons);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        client.booking(booking);
                        MessageBox.Show("Resevartion is OK!", "Booking", MessageBoxButtons.OK);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Something goes wrong :(", "Booking", MessageBoxButtons.OK);
                        MessageBox.Show(ex.Message, "Booking", MessageBoxButtons.OK);
                    }
                    
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Room in not avaible during this time! Please choose another date.", "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
