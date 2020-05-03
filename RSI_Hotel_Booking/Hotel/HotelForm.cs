using System.Drawing;
using System.Windows.Forms;
using HotelListDto = RSI_Hotel_Booking.HotelService.hotelListDto;
using HotelServiceClient = RSI_Hotel_Booking.HotelService.HotelWebServiceClient;

namespace RSI_Hotel_Booking.Hotel
{
    public partial class HotelForm : Form
    {
        string _name;
        long _ID;

        public HotelForm(string name, long id)
        {
            InitializeComponent();
            this.Text = name;
            _ID = id;
            _name = name;

            SetHotels();
        }

        private void SetHotels()
        {
            HotelServiceClient client = new HotelServiceClient();
            HotelListDto[] hotelListDtos = client.getHotelListDto(_ID);

            if(hotelListDtos != null)
            {
                foreach (var item in hotelListDtos)
                {
                    HotelListItem listItem = new HotelListItem();

                    listItem.Title = item.name;
                    listItem.Subtitle = item.id;

                    if (item.exhibitionPhoto != null)
                    {
                        System.Net.WebRequest request = System.Net.WebRequest.Create(item.exhibitionPhoto);
                        System.Net.WebResponse response = request.GetResponse();
                        System.IO.Stream responseStream = response.GetResponseStream();
                        Bitmap bitmap = new Bitmap(responseStream);

                        listItem.Image = bitmap;
                    }


                    flowLayoutPanel1.Controls.Add(listItem);
                }
            }
  
        }
    }
}
