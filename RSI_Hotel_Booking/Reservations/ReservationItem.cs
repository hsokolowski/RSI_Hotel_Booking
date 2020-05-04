using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

    }
}
