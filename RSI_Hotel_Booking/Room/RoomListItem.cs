using RSI_Hotel_Booking.Details;
using System;
using System.Drawing;

using System.Windows.Forms;

namespace RSI_Hotel_Booking.Room
{
    public partial class RoomListItem : UserControl
    {
        public RoomListItem()
        {
            InitializeComponent();
        }

        private string _title;
        private long _sub;
        private Bitmap image;

        public string Title
        {
            get { return _title; }
            set { _title = value; label1.Text = value; }
        }

        public long Subtitle
        {
            get { return _sub; }
            set { _sub = value; }
        }

        public Bitmap Image
        {
            get { return image; }
            set { image = value; if (value != null) pictureBox1.Image = value; }
        }

        private void details_Click(object sender, EventArgs e)
        {
            DetailsForm sistema = new DetailsForm(Title, Subtitle);
            sistema.Show();
        }
    }
}
