﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSI_Hotel_Booking.Hotel;

namespace RSI_Hotel_Booking
{
    public partial class Form1ListItem : UserControl
    {
        public Form1ListItem()
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
            set { image = value; if(value != null ) pictureBox1.Image = value; }
        }

        private void reservationBtn_Click(object sender, EventArgs e)
        {
            HotelForm sistema = new HotelForm(Title,Subtitle);
            sistema.Show();
        }
    }
}
