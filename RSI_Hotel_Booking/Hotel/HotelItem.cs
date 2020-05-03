using System.Windows.Forms;
using PlaceDto = RSI_Hotel_Booking.HotelService.placeDto;

namespace RSI_Hotel_Booking.Hotel
{
    public partial class HotelItem : UserControl
    {
        public HotelItem()
        {
            InitializeComponent();
        }

        private string _name;
        private string _adres;
        private string _info;
        private int _rate;
        private PlaceDto[] _placeDtos;

        public string NameHotel
        {
            get { return _name; }
            set { _name = value; }
        }

        public string AdresHotel
        {
            get { return _adres; }
            set { _adres = value; }
        }

        public string InfoHotel
        {
            get { return _info; }
            set { _info = value; }
        }

        public int RateHotel
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public PlaceDto[] PlacesHotel
        {
            get { return _placeDtos; }
            set { _placeDtos = value; }
        }

        //private void SetHotels()
        //{
        //    HotelServiceClient client = new HotelServiceClient();
        //    HotelListDto[] hotelDtos = client.getHotelListDto(_ID);

        //    foreach (var item in hotelDtos)
        //    {
        //        HotelItem listItem = new HotelItem();

        //        listItem.NameHotel = item.name;
        //        listItem.AdresHotel = item.address;
        //        listItem.InfoHotel = item.additionalInformations;
        //        listItem.RateHotel = item.rate;
        //        //listItem.PlacesHotel = item.nearbyPlaces;


        //        flowLayoutPanel1.Controls.Add(listItem);
        //    }
        //}
    }
}
